using DnsProxyPoc.Services;

namespace DnsProxyPoc.Endpoints;

public static class DiagnosticEndpoints
{
    private static readonly string[] GetHead = ["GET", "HEAD"];

    public static WebApplication MapDiagnosticEndpoints(this WebApplication app, string proxyTarget)
    {
        app.MapMethods("/_proxy/debug", GetHead, (HttpContext ctx) =>
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

        app.MapMethods("/_proxy/log", GetHead, (VisitorLog log) =>
            Results.Json(log.GetEntries()));

        return app;
    }
}
