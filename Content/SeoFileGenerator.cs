using System.Text;
using DnsProxyPoc.Services;

namespace DnsProxyPoc.Content;

public static class SeoFileGenerator
{
    private static readonly (string Path, string ShortTitle, string Summary)[] PageMeta =
    [
        ("/",                               "Home",                     "BrightPixel — premium addressable LED pixel products, controllers, power supplies, and expert guides."),
        ("/products/ws2812b-led-strips",     "WS2812B LED Strips",       "Individually addressable 5V RGB strips in 30, 60, 144 LEDs/m densities. IP30/IP65/IP67 options."),
        ("/products/ws2811-pixel-nodes",     "WS2811 Pixel Nodes",       "12V waterproof bullet and square pixel modules for signage, building outlines, and holiday displays."),
        ("/products/apa102-led-strips",      "APA102 DotStar Strips",    "High-speed SPI LED strips with 19.2 kHz flicker-free PWM for video, film, and POV applications."),
        ("/products/pixel-controllers",      "Pixel Controllers",        "ESP32 WLED boards, Teensy 4.1, Falcon F16/F48 professional controllers for 300 to 100,000+ pixels."),
        ("/products/led-matrix-panels",      "LED Matrix Panels",        "HUB75 RGB matrix panels from P2.5 to P10 pitch for video walls, scoreboards, and signage."),
        ("/products/power-supplies",         "Power Supplies",           "UL/CE certified Meanwell 5V and 12V power supplies sized for LED pixel workloads."),
        ("/products/connectors-accessories", "Connectors & Accessories", "JST connectors, aluminum channels, level shifters, signal amplifiers, and mounting hardware."),
        ("/products/outdoor-waterproof",     "Outdoor Waterproof",       "IP67/IP68 UV-stabilized LED pixels tested from -40°C to 80°C for permanent outdoor installations."),
        ("/products/neon-flex",              "LED Neon Flex",            "Addressable WS2812B/WS2811 silicone neon rope light — dot-free illumination in top, side, and 360° profiles."),
        ("/products/pixel-art-frames",       "Pixel Art Frames",         "16x16 (256px) and 32x32 (1024px) wall-mountable WLED displays for retro art and dashboards."),
        ("/guides/getting-started",          "Getting Started",          "Step-by-step beginner guide: components, wiring, WLED setup, first animation."),
        ("/guides/choosing-pixels",          "Choosing Pixels",          "WS2812B vs APA102 vs WS2811 vs SK6812 comparison — voltage, speed, cost, and use case guide."),
        ("/guides/power-calculation",        "Power Calculator",         "Formulas, wire gauge charts, and real-world examples for sizing LED pixel power supplies."),
        ("/guides/installation",             "Installation Guide",       "Surface preparation, indoor/outdoor mounting, weatherproofing, and wiring best practices."),
        ("/guides/programming",              "Programming Tutorial",     "Arduino, ESP32, FastLED, WLED — code your first animation, sound reactivity, and network control."),
        ("/learn/pixel-technology",          "Pixel Technology",         "How addressable LED pixels work: IC architecture, PWM dimming, signal propagation, voltage drop."),
        ("/learn/protocols",                 "LED Protocols",            "WS2812B NRZ, APA102 SPI, DMX512, E1.31 sACN, Art-Net, and DDP protocols compared."),
        ("/learn/color-mixing",              "RGB Color Mixing",         "Additive RGB mixing, HSV color space for animation, gamma correction, CRI, and RGBW pixels."),
        ("/resources",                       "Resources",                "WLED, xLights, FastLED, FPP, LedFx — firmware, software, libraries, community links, and tools."),
        ("/about",                           "About BrightPixel",        "Our story, tested-product commitment, technical support team, and wholesale program.")
    ];

    public static string RobotsTxt(string baseUrl)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"# {BotPageRegistry.SiteName} — robots.txt");
        sb.AppendLine($"# Updated: {BotPageRegistry.DateModified}");
        sb.AppendLine();

        sb.AppendLine("# ── All crawlers ──────────────────────────────────────────────────────────");
        sb.AppendLine("User-agent: *");
        sb.AppendLine("Allow: /");
        sb.AppendLine("Crawl-delay: 1");
        sb.AppendLine();

        foreach (var pattern in CrawlerDetector.CrawlerPatterns)
        {
            sb.AppendLine($"User-agent: {pattern}");
            sb.AppendLine("Allow: /");
            sb.AppendLine();
        }

        sb.AppendLine("# ── Sitemaps ──────────────────────────────────────────────────────────────");
        sb.AppendLine($"Sitemap: {baseUrl}/sitemap.xml");
        sb.AppendLine();
        sb.AppendLine("# ── LLM readability files ─────────────────────────────────────────────────");
        sb.AppendLine($"# AI-friendly content index:   {baseUrl}/llms.txt");
        sb.Append($"# Full content for LLMs:       {baseUrl}/llms-full.txt");

        return sb.ToString();
    }

    public static string SitemapXml(string baseUrl)
    {
        var urls = string.Join("\n", BotPageRegistry.AllPages.Select(p => $"""
  <url>
    <loc>{baseUrl}{p.Path}</loc>
    <lastmod>{BotPageRegistry.DateModified}</lastmod>
    <changefreq>{p.SitemapChangeFreq}</changefreq>
    <priority>{p.SitemapPriority}</priority>
  </url>
"""));

        return $"""
<?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
{urls}
</urlset>
""";
    }

    public static string LlmsTxt(string baseUrl) => $"""
# {BotPageRegistry.SiteName}

> {BotPageRegistry.SiteDescription}

{BotPageRegistry.SiteName} is a specialist supplier of addressable LED pixel products — individually controllable RGB strips, pixel nodes, matrix panels, controllers, power supplies, and accessories. We also publish comprehensive guides on installation, programming, power calculation, and LED pixel technology.

Published: {BotPageRegistry.DatePublished} | Last updated: {BotPageRegistry.DateModified}

## Products

- [WS2812B LED Strips]({baseUrl}/products/ws2812b-led-strips): Individually addressable 5V RGB strips — 30, 60, 144 LEDs/m — IP30/IP65/IP67 — the most popular pixel LED.
- [WS2811 Pixel Nodes]({baseUrl}/products/ws2811-pixel-nodes): 12V waterproof bullet and square modules for signage, building outlines, and holiday pixel displays.
- [APA102 DotStar Strips]({baseUrl}/products/apa102-led-strips): High-speed SPI LED strips with 19.2 kHz flicker-free PWM for video, POV, and professional applications.
- [Pixel Controllers]({baseUrl}/products/pixel-controllers): ESP32 WLED boards, Teensy 4.1, Falcon F16/F48 — controllers for 300 to 100,000+ pixels.
- [LED Matrix Panels]({baseUrl}/products/led-matrix-panels): HUB75 RGB panels from P2.5 to P10 pitch for video walls, scoreboards, and information displays.
- [Power Supplies]({baseUrl}/products/power-supplies): Meanwell 5V/12V UL/CE certified supplies properly sized for LED pixel workloads.
- [Connectors & Accessories]({baseUrl}/products/connectors-accessories): JST connectors, aluminum channels, level shifters, signal amplifiers, and mounting hardware.
- [Outdoor Waterproof]({baseUrl}/products/outdoor-waterproof): IP67/IP68 UV-stabilized pixels rated for -40°C to 80°C permanent outdoor installations.
- [LED Neon Flex]({baseUrl}/products/neon-flex): Addressable pixel neon rope — dot-free smooth illumination in top, side, and 360° profiles.
- [Pixel Art Frames]({baseUrl}/products/pixel-art-frames): 16x16 and 32x32 wall-mountable WLED displays for pixel art, notifications, and dashboards.

## Guides

- [Getting Started]({baseUrl}/guides/getting-started): Beginner guide — components, wiring, WLED setup, your first animation.
- [Choosing Pixels]({baseUrl}/guides/choosing-pixels): WS2812B vs APA102 vs WS2811 vs SK6812 — voltage, speed, cost, best use case.
- [Power Calculator]({baseUrl}/guides/power-calculation): Sizing formulas, wire gauge charts, and real-world examples for LED power supplies.
- [Installation Guide]({baseUrl}/guides/installation): Mounting, weatherproofing, wiring best practices for indoor and outdoor installs.
- [Programming Tutorial]({baseUrl}/guides/programming): Arduino, ESP32, FastLED, WLED — code animations, sound reactivity, network control.

## Learn

- [Pixel Technology]({baseUrl}/learn/pixel-technology): How addressable LEDs work — IC architecture, PWM dimming, signal propagation, voltage drop.
- [LED Protocols]({baseUrl}/learn/protocols): WS2812B NRZ, APA102 SPI, DMX512, E1.31 sACN, Art-Net, and DDP compared.
- [RGB Color Mixing]({baseUrl}/learn/color-mixing): Additive RGB, HSV color space, gamma correction, color temperature, CRI, RGBW pixels.

## References

- [Resources]({baseUrl}/resources): WLED, xLights, FastLED, FPP, community links, wire calculators, and design tools.
- [About BrightPixel]({baseUrl}/about): Our story, tested-product philosophy, technical support, and wholesale program.

## Optional

- [LLMs Full Content]({baseUrl}/llms-full.txt): Complete page text for LLM context loading.
""";

    public static string LlmsFullTxt(string baseUrl)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"# {BotPageRegistry.SiteName} — Full Content");
        sb.AppendLine($"> {BotPageRegistry.SiteDescription}");
        sb.AppendLine($"> Published: {BotPageRegistry.DatePublished} | Updated: {BotPageRegistry.DateModified}");
        sb.AppendLine();

        foreach (var (path, title, summary) in PageMeta)
        {
            sb.AppendLine($"## {title}");
            sb.AppendLine($"URL: {baseUrl}{path}");
            sb.AppendLine(summary);
            sb.AppendLine();
        }

        sb.AppendLine("---");
        sb.AppendLine("Key facts:");
        sb.AppendLine("- WS2812B: 5V, single-wire 800Kbps, 60mA/pixel, 30/60/144 LEDs/m, most popular addressable LED");
        sb.AppendLine("- APA102: 5V, SPI up to 20MHz, 19.2kHz flicker-free PWM, ideal for video/POV applications");
        sb.AppendLine("- WS2811: 12V, supports long cable runs, available as bullet and square pixel nodes");
        sb.AppendLine("- SK6812: 5V, RGBW variant adds dedicated white LED for CRI 80+ white light");
        sb.AppendLine("- Power formula: Amps = pixel_count × current_per_pixel × 1.2 safety margin");
        sb.AppendLine("- WS2812B power injection: every 2.5m (60 LEDs/m) or 0.5m (144 LEDs/m)");
        sb.AppendLine("- WLED: open-source ESP32 firmware, 100+ effects, Wi-Fi, E1.31, Art-Net, Home Assistant");
        sb.AppendLine("- E1.31 sACN: DMX over Ethernet, up to 63,999 universes, standard for large pixel shows");
        sb.AppendLine("- HUB75 panels: P2.5 (close viewing) to P10 (outdoor signage), driven by ESP32 or Linsn/Colorlight cards");
        sb.AppendLine("- Gamma correction: γ=2.2-2.8 curve maps linear PWM to perceptually uniform brightness");

        return sb.ToString();
    }
}
