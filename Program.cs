using DnsProxyPoc;
using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory visitor log (last 50 requests)
var visitorLog = new ConcurrentQueue<object>();

app.UseHttpsRedirection();

// Crawler detection middleware — runs before all routes
app.Use(async (context, next) =>
{
    var userAgent = context.Request.Headers.UserAgent.ToString();
    var isCrawler = CrawlerDetector.IsCrawler(userAgent);

    context.Items["IsCrawler"] = isCrawler;

    // Log visitor
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
        return Task.CompletedTask;
    });

    await next();
});

// ── Routes ───────────────────────────────────────────────────────────

string[] getHead = ["GET", "HEAD"];

app.MapMethods("/", getHead, (HttpContext ctx) =>
{
    var isCrawler = (bool)ctx.Items["IsCrawler"]!;
    return Results.Content(ContentPages.HomePage(isCrawler), "text/html");
});

app.MapMethods("/about", getHead, (HttpContext ctx) =>
{
    var isCrawler = (bool)ctx.Items["IsCrawler"]!;
    return Results.Content(ContentPages.AboutPage(isCrawler), "text/html");
});

app.MapMethods("/articles/{slug}", getHead, (string slug, HttpContext ctx) =>
{
    var isCrawler = (bool)ctx.Items["IsCrawler"]!;
    var html = ContentPages.ArticlePage(slug, isCrawler);
    return html is not null
        ? Results.Content(html, "text/html")
        : Results.Content(ContentPages.NotFoundPage(isCrawler), "text/html", statusCode: 404);
});

app.MapMethods("/robots.txt", getHead, (HttpContext ctx) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";
    return Results.Text($"""
        User-agent: *
        Allow: /

        User-agent: ChatGPT-User
        Allow: /

        User-agent: GPTBot
        Allow: /

        Sitemap: {baseUrl}/sitemap.xml
        """.Replace("        ", ""), "text/plain");
});

app.MapMethods("/sitemap.xml", getHead, (HttpContext ctx) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";
    string[] paths = ["/", "/about", "/articles/psychology", "/articles/in-nature", "/articles/history"];

    var urls = string.Join("\n", paths.Select(p => $"""
          <url>
            <loc>{baseUrl}{p}</loc>
          </url>
        """));

    var xml = $"""
        <?xml version="1.0" encoding="UTF-8"?>
        <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
        {urls}
        </urlset>
        """;

    return Results.Content(xml, "application/xml");
});

app.MapMethods("/debug", getHead, (HttpContext ctx) =>
{
    var userAgent = ctx.Request.Headers.UserAgent.ToString();
    var isCrawler = (bool)ctx.Items["IsCrawler"]!;
    var headers = ctx.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
    return Results.Json(new
    {
        userAgent,
        isCrawler,
        theme = isCrawler ? "red" : "blue",
        ip = ctx.Connection.RemoteIpAddress?.ToString(),
        allHeaders = headers
    });
});

app.MapMethods("/log", getHead, (HttpContext ctx) =>
{
    return Results.Json(visitorLog.ToArray());
});

app.Run();

static class CrawlerDetector
{
    private static readonly string[] CrawlerPatterns =
    [
        "Googlebot", "Bingbot", "Slurp", "DuckDuckBot",
        "Baiduspider", "YandexBot", "facebookexternalhit", "Twitterbot",
        "LinkedInBot", "WhatsApp", "TelegramBot", "ChatGPT-User",
        "GPTBot", "OAI-SearchBot", "ClaudeBot", "Anthropic",
        "PerplexityBot", "Google-Extended", "CCBot", "Applebot",
        "AhrefsBot", "Bytespider", "cohere-ai", "Meta-ExternalAgent"
    ];

    public static bool IsCrawler(string userAgent)
        => !string.IsNullOrEmpty(userAgent) &&
           CrawlerPatterns.Any(p => userAgent.Contains(p, StringComparison.OrdinalIgnoreCase));
}
