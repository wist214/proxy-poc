using System.Net;

namespace DnsProxyPoc.Content;

public static class BotContentRenderer
{
    public static string RenderPage(BotPage page, string baseUrl)
    {
        var canonicalUrl = Encode(baseUrl + page.Path);
        var isHome = page.Path is "/" or "";

        var webPageJson = JsonLdGenerator.WebPageSchema(page, baseUrl, isHome);
        var webSiteJson = isHome ? JsonLdGenerator.WebSiteSchema(baseUrl) : null;
        var breadcrumbJson = !isHome ? JsonLdGenerator.BreadcrumbSchema(page.Path, baseUrl) : null;
        var faqJson = page.FaqItems.Length > 0 ? JsonLdGenerator.FaqPageSchema(page.FaqItems) : null;

        var websiteSchema = webSiteJson is not null ? $"""

    <script type="application/ld+json">
    {webSiteJson}
    </script>
""" : "";

        var breadcrumbSchema = breadcrumbJson is not null ? $"""

    <script type="application/ld+json">
    {breadcrumbJson}
    </script>
""" : "";

        var faqSchema = faqJson is not null ? $"""

    <script type="application/ld+json">
    {faqJson}
    </script>
""" : "";

        return $$"""
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>{{Encode(page.Title)}}</title>
    <meta name="description" content="{{Encode(page.MetaDescription)}}">
    <meta name="robots" content="index, follow">
    <link rel="canonical" href="{{canonicalUrl}}">

    <!-- Open Graph -->
    <meta property="og:type" content="{{(isHome ? "website" : "article")}}">
    <meta property="og:url" content="{{canonicalUrl}}">
    <meta property="og:title" content="{{Encode(page.Title)}}">
    <meta property="og:description" content="{{Encode(page.MetaDescription)}}">
    <meta property="og:site_name" content="{{Encode(BotPageRegistry.SiteName)}}">
    <meta property="og:locale" content="en_US">

    <!-- Twitter Card -->
    <meta name="twitter:card" content="summary">
    <meta name="twitter:title" content="{{Encode(page.Title)}}">
    <meta name="twitter:description" content="{{Encode(page.MetaDescription)}}">

    <!-- Structured Data: Page -->
    <script type="application/ld+json">
    {{webPageJson}}
    </script>
    {{websiteSchema}}{{breadcrumbSchema}}{{faqSchema}}
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            font-family: system-ui, -apple-system, 'Segoe UI', Roboto, sans-serif;
            background: {{BotPageRegistry.Bg}};
            color: {{BotPageRegistry.Text}};
            line-height: 1.7;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }
        nav {
            background: {{BotPageRegistry.Accent}};
            padding: 1rem 2rem;
            display: flex;
            gap: 1.5rem;
            align-items: center;
            flex-wrap: wrap;
        }
        nav a { color: #fff; text-decoration: none; font-weight: 600; font-size: 0.95rem; }
        nav a:hover { text-decoration: underline; }
        nav .brand { font-size: 1.2rem; margin-right: auto; }
        main { max-width: 48rem; margin: 2rem auto; padding: 2rem; flex: 1; }
        main h1 { margin-bottom: 1rem; font-size: 2rem; }
        main h2 { margin-top: 1.5rem; margin-bottom: 0.75rem; }
        main p { margin-bottom: 1rem; }
        main ul { margin: 0.5rem 0 1rem 1.5rem; }
        main li { margin-bottom: 0.4rem; }
        main a { color: {{BotPageRegistry.Accent}}; }
        .faq { margin-top: 2rem; }
        .faq details { border-left: 3px solid {{BotPageRegistry.Accent}}; padding-left: 1rem; margin-bottom: 0.75rem; }
        .faq summary { cursor: pointer; padding: 0.5rem 0; }
        .faq details p { margin-top: 0.5rem; margin-bottom: 0.25rem; }
        footer {
            background: {{BotPageRegistry.Accent}};
            color: rgba(255,255,255,0.85);
            text-align: center;
            padding: 1rem 2rem;
            font-size: 0.85rem;
            margin-top: auto;
        }
    </style>
</head>
<body>
    <nav>
        <a href="/" class="brand">BrightPixel</a>
        <a href="/products/ws2812b-led-strips">WS2812B</a>
        <a href="/products/pixel-controllers">Controllers</a>
        <a href="/products/led-matrix-panels">Panels</a>
        <a href="/guides/getting-started">Get Started</a>
        <a href="/guides/choosing-pixels">Choose Pixels</a>
        <a href="/learn/pixel-technology">Learn</a>
        <a href="/resources">Resources</a>
        <a href="/about">About</a>
    </nav>
    <main>
        {{page.BodyHtml}}
    </main>
    <footer>
        &copy; <time datetime="{{BotPageRegistry.DateModified}}">2026</time> {{Encode(BotPageRegistry.SiteName)}} — Premium addressable LED pixel products &amp; guides.
        &nbsp;|&nbsp; <a href="/llms.txt" style="color:rgba(255,255,255,0.7)">llms.txt</a>
    </footer>
</body>
</html>
""";
    }

    private static string Encode(string value) => WebUtility.HtmlEncode(value);
}
