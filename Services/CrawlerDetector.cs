namespace DnsProxyPoc.Services;

public static class CrawlerDetector
{
    public static readonly IReadOnlyList<string> CrawlerPatterns =
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

        // ── Google tools (Rich Results Test, URL Inspection, etc.) ────────
        "Google-InspectionTool",

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
