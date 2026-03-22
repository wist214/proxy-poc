using System.Net.Http.Headers;

namespace DnsProxyPoc.Services;

public sealed class ReverseProxyHandler
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReverseProxyHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task ProxyRequestAsync(HttpContext ctx, string proxyTarget, Uri targetUri)
    {
        var client = _httpClientFactory.CreateClient("proxy");
        var targetUrl = $"{proxyTarget.TrimEnd('/')}{ctx.Request.Path}{ctx.Request.QueryString}";

        try
        {
            using var proxyReq = new HttpRequestMessage(new HttpMethod(ctx.Request.Method), targetUrl);

            foreach (var header in ctx.Request.Headers)
            {
                if (!IsHopByHopHeader(header.Key))
                    proxyReq.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }
            proxyReq.Headers.Host = targetUri.Host;

            if (HttpMethods.IsPost(ctx.Request.Method) ||
                HttpMethods.IsPut(ctx.Request.Method) ||
                HttpMethods.IsPatch(ctx.Request.Method))
            {
                proxyReq.Content = new StreamContent(ctx.Request.Body);
                if (ctx.Request.ContentType is not null)
                    proxyReq.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(ctx.Request.ContentType);
            }

            using var proxyResp = await client.SendAsync(
                proxyReq, HttpCompletionOption.ResponseHeadersRead, ctx.RequestAborted);

            ctx.Response.StatusCode = (int)proxyResp.StatusCode;

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

            await proxyResp.Content.CopyToAsync(ctx.Response.Body);
        }
        catch (HttpRequestException)
        {
            ctx.Response.StatusCode = StatusCodes.Status502BadGateway;
            await ctx.Response.WriteAsync("Bad Gateway");
        }
        catch (TaskCanceledException)
        {
            ctx.Response.StatusCode = StatusCodes.Status504GatewayTimeout;
            await ctx.Response.WriteAsync("Gateway Timeout");
        }
    }

    private static bool IsHopByHopHeader(string name) =>
        name.Equals("Connection", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("Keep-Alive", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("Transfer-Encoding", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("TE", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("Trailer", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("Upgrade", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("Proxy-Authorization", StringComparison.OrdinalIgnoreCase) ||
        name.Equals("Proxy-Authenticate", StringComparison.OrdinalIgnoreCase);
}
