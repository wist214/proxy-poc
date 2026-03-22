using DnsProxyPoc.Content;
using DnsProxyPoc.Services;

namespace DnsProxyPoc.Endpoints;

public static class BotContentEndpoints
{
    private static readonly string[] GetHead = ["GET", "HEAD"];

    public static WebApplication MapBotEndpoints(this WebApplication app, string proxyTarget, Uri targetUri)
    {
        app.MapMethods("/llms.txt", GetHead, async (HttpContext ctx) =>
        {
            var baseUrl = (string)ctx.Items["BaseUrl"]!;
            ctx.Response.ContentType = "text/plain; charset=utf-8";
            await ctx.Response.WriteAsync(SeoFileGenerator.LlmsTxt(baseUrl));
        });

        app.MapMethods("/llms-full.txt", GetHead, async (HttpContext ctx) =>
        {
            var baseUrl = (string)ctx.Items["BaseUrl"]!;
            ctx.Response.ContentType = "text/plain; charset=utf-8";
            await ctx.Response.WriteAsync(SeoFileGenerator.LlmsFullTxt(baseUrl));
        });

        app.Map("{**path}", async (HttpContext ctx, ReverseProxyHandler proxyHandler) =>
        {
            var path = ctx.Request.Path.ToString().ToLowerInvariant().TrimEnd('/');
            var baseUrl = (string)ctx.Items["BaseUrl"]!;

            if (path == "/robots.txt")
            {
                ctx.Response.ContentType = "text/plain";
                await ctx.Response.WriteAsync(SeoFileGenerator.RobotsTxt(baseUrl));
                return;
            }
            if (path == "/sitemap.xml")
            {
                ctx.Response.ContentType = "application/xml";
                await ctx.Response.WriteAsync(SeoFileGenerator.SitemapXml(baseUrl));
                return;
            }

            var page = BotPageRegistry.GetPage(path);
            if (page is not null)
            {
                ctx.Response.ContentType = "text/html; charset=utf-8";
                await ctx.Response.WriteAsync(BotContentRenderer.RenderPage(page, baseUrl));
                return;
            }

            await proxyHandler.ProxyRequestAsync(ctx, proxyTarget, targetUri);
        });

        return app;
    }
}
