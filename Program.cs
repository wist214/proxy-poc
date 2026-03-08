using DnsProxyPoc;
using System.Collections.Concurrent;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// HttpClient for reverse proxying to target site
builder.Services.AddHttpClient("proxy", client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AllowAutoRedirect = false,
    AutomaticDecompression = System.Net.DecompressionMethods.None
});

var app = builder.Build();

// ── Proxy target configuration ──────────────────────────────────────
var proxyTarget = app.Configuration["ProxyTarget"]
    ?? throw new InvalidOperationException("ProxyTarget is not configured. Set it in appsettings.json.");

if (!Uri.TryCreate(proxyTarget, UriKind.Absolute, out var targetUri) ||
    (targetUri.Scheme != "https" && targetUri.Scheme != "http"))
{
    throw new InvalidOperationException($"Invalid ProxyTarget URL: {proxyTarget}");
}

var visitorLog = new ConcurrentQueue<object>();

app.UseHttpsRedirection();

// ── Crawler detection middleware ────────────────────────────────────
app.Use(async (context, next) =>
{
    var userAgent = context.Request.Headers.UserAgent.ToString();
    var isCrawler = CrawlerDetector.IsCrawler(userAgent);

    context.Items["IsCrawler"] = isCrawler;

    visitorLog.Enqueue(new
    {
        time = DateTime.UtcNow.ToString("o"),
        path = context.Request.Path.ToString(),
        method = context.Request.Method,
        userAgent,
        isCrawler,
        ip = context.Connection.RemoteIpAddress?.ToString()
    });
    while (visitorLog.Count > 50) visitorLog.TryDequeue(out _);

    context.Response.OnStarting(() =>
    {
        context.Response.Headers["X-Served-By"] = "dns-proxy-poc";
        context.Response.Headers["X-Crawler-Detected"] = isCrawler.ToString().ToLowerInvariant();
        context.Response.Headers["Vary"] = "User-Agent";
        if (isCrawler)
        {
            context.Response.Headers["X-Robots-Tag"] = "index, follow";
            context.Response.Headers["Link"] =
                "</sitemap.xml>; rel=\"sitemap\", " +
                "</llms.txt>; rel=\"alternate\"; type=\"text/plain\"; title=\"LLMs.txt\"";
        }
        return Task.CompletedTask;
    });

    await next();
});

// ── Public AI readability files (served to all visitors) ───────────
string[] getHead = ["GET", "HEAD"];

app.MapMethods("/llms.txt", getHead, async (HttpContext ctx) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";
    ctx.Response.ContentType = "text/plain; charset=utf-8";
    await ctx.Response.WriteAsync(BotContent.LlmsTxt(baseUrl));
});

app.MapMethods("/llms-full.txt", getHead, async (HttpContext ctx) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";
    ctx.Response.ContentType = "text/plain; charset=utf-8";
    await ctx.Response.WriteAsync(BotContent.LlmsFullTxt(baseUrl));
});

// ── Diagnostic endpoints (/_proxy/ prefix to avoid clashing with target) ──

app.MapMethods("/_proxy/debug", getHead, (HttpContext ctx) =>
{
    var userAgent = ctx.Request.Headers.UserAgent.ToString();
    var isCrawler = (bool)ctx.Items["IsCrawler"]!;
    var headers = ctx.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
    return Results.Json(new
    {
        userAgent,
        isCrawler,
        proxyTarget,
        mode = isCrawler ? "bot-content" : "proxy-passthrough",
        ip = ctx.Connection.RemoteIpAddress?.ToString(),
        allHeaders = headers
    });
});

app.MapMethods("/_proxy/log", getHead, () => Results.Json(visitorLog.ToArray()));

// ── Catch-all: bots → custom content, humans → reverse proxy ───────
app.Map("{**path}", async (HttpContext ctx, IHttpClientFactory httpClientFactory) =>
{
    var isCrawler = (bool)ctx.Items["IsCrawler"]!;

    if (isCrawler)
    {
        var path = ctx.Request.Path.ToString().ToLowerInvariant().TrimEnd('/');
        var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";

        // Bots: serve custom robots.txt / sitemap.xml
        if (path == "/robots.txt")
        {
            ctx.Response.ContentType = "text/plain";
            await ctx.Response.WriteAsync(BotContent.RobotsTxt(baseUrl));
            return;
        }
        if (path == "/sitemap.xml")
        {
            ctx.Response.ContentType = "application/xml";
            await ctx.Response.WriteAsync(BotContent.SitemapXml(baseUrl));
            return;
        }

        // Bots: serve custom HTML for known pages
        var botHtml = BotContent.GetPage(path, baseUrl);
        if (botHtml is not null)
        {
            ctx.Response.ContentType = "text/html; charset=utf-8";
            await ctx.Response.WriteAsync(botHtml);
            return;
        }

        // Unknown bot path → fall through to proxy (CSS, JS, images, etc.)
    }

    // ── Reverse proxy to target site ────────────────────────────────
    var client = httpClientFactory.CreateClient("proxy");
    var targetUrl = $"{proxyTarget.TrimEnd('/')}{ctx.Request.Path}{ctx.Request.QueryString}";

    using var proxyReq = new HttpRequestMessage(new HttpMethod(ctx.Request.Method), targetUrl);

    // Forward request headers (skip hop-by-hop)
    foreach (var header in ctx.Request.Headers)
    {
        if (!IsHopByHopHeader(header.Key))
            proxyReq.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
    }
    proxyReq.Headers.Host = targetUri.Host;

    // Forward request body (POST, PUT, PATCH)
    if (HttpMethods.IsPost(ctx.Request.Method) ||
        HttpMethods.IsPut(ctx.Request.Method) ||
        HttpMethods.IsPatch(ctx.Request.Method))
    {
        proxyReq.Content = new StreamContent(ctx.Request.Body);
        if (ctx.Request.ContentType is not null)
            proxyReq.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(ctx.Request.ContentType);
    }

    using var proxyResp = await client.SendAsync(proxyReq, HttpCompletionOption.ResponseHeadersRead);

    // Copy response status
    ctx.Response.StatusCode = (int)proxyResp.StatusCode;

    // Copy response headers
    foreach (var header in proxyResp.Headers)
    {
        if (!IsHopByHopHeader(header.Key))
            ctx.Response.Headers[header.Key] = header.Value.ToArray();
    }
    foreach (var header in proxyResp.Content.Headers)
    {
        ctx.Response.Headers[header.Key] = header.Value.ToArray();
    }
    ctx.Response.Headers.Remove("transfer-encoding");

    // Stream response body through
    await proxyResp.Content.CopyToAsync(ctx.Response.Body);
});

app.Run();

// ── Helpers ──────────────────────────────────────────────────────────

static bool IsHopByHopHeader(string name) =>
    name.Equals("Connection", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("Keep-Alive", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("Transfer-Encoding", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("TE", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("Trailer", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("Upgrade", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("Proxy-Authorization", StringComparison.OrdinalIgnoreCase) ||
    name.Equals("Proxy-Authenticate", StringComparison.OrdinalIgnoreCase);

static class CrawlerDetector
{
    private static readonly string[] CrawlerPatterns =
    [
        // ── Traditional search engines ────────────────────────────────────
        "Googlebot", "bingbot", "Slurp", "DuckDuckBot",
        "Baiduspider", "YandexBot", "Qwantify",

        // ── Social / messaging ────────────────────────────────────────────
        "facebookexternalhit", "Twitterbot", "LinkedInBot",
        "WhatsApp", "TelegramBot",

        // ── OpenAI (ChatGPT / SearchGPT) ──────────────────────────────────
        "GPTBot", "ChatGPT-User", "OAI-SearchBot",

        // ── Anthropic (Claude) ────────────────────────────────────────────
        "ClaudeBot", "Claude-User", "Claude-SearchBot", "Claude-Web", "anthropic-ai", "Anthropic",

        // ── Google AI (Gemini, AI Overviews, Vertex, NotebookLM) ──────────
        "Google-Extended", "Google-CloudVertexBot", "Google-NotebookLM", "Gemini-Deep-Research",

        // ── Microsoft / Bing (Copilot uses bingbot index) ─────────────────
        // covered by "bingbot" above

        // ── Meta AI ───────────────────────────────────────────────────────
        "Meta-ExternalAgent", "meta-externalagent", "meta-webindexer", "Bytespider",

        // ── xAI / Grok ────────────────────────────────────────────────────
        "xAI", "GrokBot",

        // ── Perplexity ────────────────────────────────────────────────────
        "PerplexityBot", "Perplexity-User",

        // ── Apple (Spotlight, Siri, Apple Intelligence) ───────────────────
        "Applebot",                  // matches Applebot and Applebot-Extended

        // ── Amazon (Alexa AI, Kiro) ───────────────────────────────────────
        "Amazonbot",

        // ── Allen Institute for AI (OLMo, Dolma dataset) ─────────────────
        "AI2Bot",                    // matches AI2Bot, Ai2Bot-Dolma, Ai2Bot-DeepResearchEval

        // ── Cohere ────────────────────────────────────────────────────────
        "cohere-ai",

        // ── Diffbot (AI knowledge graph) ──────────────────────────────────
        "Diffbot",

        // ── DuckDuckGo AI Answers ─────────────────────────────────────────
        "DuckAssistBot",

        // ── Common Crawl (widely used for LLM training) ───────────────────
        "CCBot",

        // ── Mistral AI (Le Chat web browsing) ────────────────────────────
        "MistralAI-User",

        // ── DeepSeek ─────────────────────────────────────────────────────
        "DeepseekBot",

        // ── You.com AI search ────────────────────────────────────────────
        "YouBot",

        // ── Brave Search ─────────────────────────────────────────────────
        "Bravebot",

        // ── Kagi ─────────────────────────────────────────────────────────
        "kagi-fetcher",

        // ── HuggingFace ──────────────────────────────────────────────────
        "HuggingFace-Bot",

        // ── Firecrawl / Tavily (AI agent web tools) ──────────────────────
        "FirecrawlAgent", "TavilyBot",

        // ── SEO tools (signal content quality to AI systems) ─────────────
        "AhrefsBot", "SemrushBot", "serpstatbot", "DataForSeoBot",

        // ── Other AI crawlers ─────────────────────────────────────────────
        "magpie-crawler", "Timpibot", "omgili", "iaskspider"
    ];

    public static bool IsCrawler(string userAgent)
        => !string.IsNullOrEmpty(userAgent) &&
           CrawlerPatterns.Any(p => userAgent.Contains(p, StringComparison.OrdinalIgnoreCase));
}
