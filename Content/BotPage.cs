namespace DnsProxyPoc.Content;

public record BotPage(
    string Path,
    string Title,
    string MetaDescription,
    (string Question, string Answer)[] FaqItems,
    string BodyHtml,
    string SitemapPriority = "0.7",
    string SitemapChangeFreq = "monthly");
