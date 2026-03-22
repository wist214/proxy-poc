using DnsProxyPoc.Services;

namespace DnsProxyPoc.Middleware;

public sealed class CrawlerDetectionMiddleware
{
    private readonly RequestDelegate _next;

    public CrawlerDetectionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, VisitorLog visitorLog)
    {
        var userAgent = context.Request.Headers.UserAgent.ToString();
        var isCrawler = CrawlerDetector.IsCrawler(userAgent);
        var baseUrl = $"{context.Request.Scheme}://{context.Request.Host}";

        context.Items["IsCrawler"] = isCrawler;
        context.Items["BaseUrl"] = baseUrl;

        visitorLog.Log(new VisitorEntry(
            Time: DateTime.UtcNow.ToString("o"),
            Path: context.Request.Path.ToString(),
            Method: context.Request.Method,
            UserAgent: userAgent,
            IsCrawler: isCrawler,
            Ip: context.Connection.RemoteIpAddress?.ToString()
        ));

        context.Response.OnStarting(() =>
        {
            context.Response.Headers["X-Served-By"] = "dns-proxy-poc";
            context.Response.Headers["X-Crawler-Detected"] = isCrawler.ToString().ToLowerInvariant();
            context.Response.Headers["Vary"] = "User-Agent";
            context.Response.Headers["Cache-Control"] = "private, no-store";
            if (isCrawler)
            {
                context.Response.Headers["X-Robots-Tag"] = "index, follow";
                context.Response.Headers["Link"] =
                    "</sitemap.xml>; rel=\"sitemap\", " +
                    "</llms.txt>; rel=\"alternate\"; type=\"text/plain\"; title=\"LLMs.txt\"";
            }
            return Task.CompletedTask;
        });

        await _next(context);
    }
}
