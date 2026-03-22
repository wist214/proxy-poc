using DnsProxyPoc.Endpoints;
using DnsProxyPoc.Middleware;
using DnsProxyPoc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("proxy", client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AllowAutoRedirect = false,
    AutomaticDecompression = System.Net.DecompressionMethods.None
});

builder.Services.AddSingleton<VisitorLog>();
builder.Services.AddSingleton<ReverseProxyHandler>();

var app = builder.Build();

// ── Proxy target configuration ──────────────────────────────────────
var proxyTarget = app.Configuration["ProxyTarget"]
    ?? throw new InvalidOperationException("ProxyTarget is not configured. Set it in appsettings.json.");

if (!Uri.TryCreate(proxyTarget, UriKind.Absolute, out var targetUri) ||
    (targetUri.Scheme != "https" && targetUri.Scheme != "http"))
{
    throw new InvalidOperationException($"Invalid ProxyTarget URL: {proxyTarget}");
}

app.UseHttpsRedirection();
app.UseMiddleware<CrawlerDetectionMiddleware>();

app.MapDiagnosticEndpoints(proxyTarget);
app.MapBotEndpoints(proxyTarget, targetUri);

app.Run();
