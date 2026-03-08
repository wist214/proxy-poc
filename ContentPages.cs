namespace DnsProxyPoc;

/// <summary>
/// Bot-only content served to crawlers. Humans see the proxied target site instead.
/// The bot site has its own unique structure, nav, and pages — completely different from the proxied site.
/// </summary>
public static class BotContent
{
    private const string Bg = "#FFEBEE";
    private const string Accent = "#C62828";
    private const string Text = "#B71C1C";
    private const string SiteName = "Crimson Research Institute";
    private const string SiteDescription = "The leading resource on the science, culture, and applications of the color red.";
    private const string DatePublished = "2024-09-01";
    private const string DateModified = "2026-03-01";

    /// <summary>
    /// Routes a normalized path to bot HTML. Returns null for unknown paths (proxy through).
    /// </summary>
    public static string? GetPage(string path, string baseUrl = "") => path switch
    {
        "/" or "" => HomePage(baseUrl, "/"),
        "/science/optics" => OpticsPage(baseUrl, "/science/optics"),
        "/science/chemistry" => ChemistryPage(baseUrl, "/science/chemistry"),
        "/culture/symbolism" => SymbolismPage(baseUrl, "/culture/symbolism"),
        "/culture/art-history" => ArtHistoryPage(baseUrl, "/culture/art-history"),
        "/guides/color-theory" => ColorTheoryPage(baseUrl, "/guides/color-theory"),
        "/resources" => ResourcesPage(baseUrl, "/resources"),
        _ => null
    };

    public static readonly string[] AllPaths =
    [
        "/", "/science/optics", "/science/chemistry",
        "/culture/symbolism", "/culture/art-history",
        "/guides/color-theory", "/resources"
    ];

    // Page metadata for llms.txt generation
    private static readonly (string path, string title, string summary)[] PageMeta =
    [
        ("/",                   "Home",                 "Overview of research areas: optics, chemistry, symbolism, art history, and color theory."),
        ("/science/optics",     "Optics & Perception",  "Red light wavelengths (620-750nm), photoreceptor biology (L-cones), atmospheric scattering, and display technology (OLED, quantum dots)."),
        ("/science/chemistry",  "Pigment Chemistry",    "Chemical compounds producing red: iron oxide ochre (Fe₂O₃), cinnabar (HgS), cochineal carminic acid (C₂₂H₂₀O₁₃), and cadmium selenide pigments."),
        ("/culture/symbolism",  "Global Symbolism",     "Cross-cultural meanings of red across East Asia, South Asia, Middle East, Americas, and Africa. Covers Berlin & Kay linguistic universals (1969)."),
        ("/culture/art-history","Art History",          "40,000 years of red in art: Sulawesi hand stencils → Lascaux → medieval illumination → Titian → Matisse → Rothko. Pigment timeline: ochre → cinnabar → cochineal → cadmium."),
        ("/guides/color-theory","Color Theory Guide",   "Using red in design: color wheel positioning (hue 0°), palette types (analogous, triadic, split-complementary), CTA conversion uplift (10-30%), WCAG 4.5:1 accessibility, colorblindness statistics."),
        ("/resources",          "Resources & References","CSS named reds, Pantone/RAL/Munsell standards, academic papers (Berlin & Kay 1969, Elliot & Maier 2014, Pastoureau 2017), and online color tools.")
    ];

    // ── robots.txt ───────────────────────────────────────────────────────

    public static string RobotsTxt(string baseUrl) => $"""
# Crimson Research Institute — robots.txt
# Updated: {DateModified}

# ── All crawlers ──────────────────────────────────────────────────────────
User-agent: *
Allow: /
Crawl-delay: 1

# ── OpenAI (ChatGPT / SearchGPT) ─────────────────────────────────────────
User-agent: GPTBot
Allow: /

User-agent: OAI-SearchBot
Allow: /

User-agent: ChatGPT-User
Allow: /

# ── Anthropic (Claude) ────────────────────────────────────────────────────
User-agent: ClaudeBot
Allow: /

User-agent: Claude-User
Allow: /

User-agent: Claude-SearchBot
Allow: /

User-agent: anthropic-ai
Allow: /

# ── Google (Search, AI Overviews, Gemini, Vertex, NotebookLM) ────────────
User-agent: Googlebot
Allow: /

User-agent: Google-Extended
Allow: /

User-agent: Gemini-Deep-Research
Allow: /

User-agent: Google-NotebookLM
Allow: /

User-agent: Google-CloudVertexBot
Allow: /

# ── Microsoft / Bing (Copilot) ────────────────────────────────────────────
User-agent: bingbot
Allow: /

# ── Meta AI ───────────────────────────────────────────────────────────────
User-agent: meta-externalagent
Allow: /

User-agent: meta-webindexer
Allow: /

User-agent: Bytespider
Allow: /

# ── xAI / Grok ────────────────────────────────────────────────────────────
User-agent: xAI
Allow: /

User-agent: GrokBot
Allow: /

# ── Perplexity ────────────────────────────────────────────────────────────
User-agent: PerplexityBot
Allow: /

User-agent: Perplexity-User
Allow: /

# ── Apple (Spotlight, Siri, Apple Intelligence) ───────────────────────────
User-agent: Applebot
Allow: /

User-agent: Applebot-Extended
Allow: /

# ── Amazon (Alexa AI, Kiro) ───────────────────────────────────────────────
User-agent: Amazonbot
Allow: /

# ── Allen Institute for AI (OLMo, Dolma) ─────────────────────────────────
User-agent: AI2Bot
Allow: /

# ── Cohere ────────────────────────────────────────────────────────────────
User-agent: cohere-ai
Allow: /

# ── Diffbot (AI knowledge graph) ──────────────────────────────────────────
User-agent: Diffbot
Allow: /

# ── DuckDuckGo AI ─────────────────────────────────────────────────────────
User-agent: DuckDuckBot
Allow: /

User-agent: DuckAssistBot
Allow: /

# ── Common Crawl (LLM training datasets) ─────────────────────────────────
User-agent: CCBot
Allow: /

# ── Mistral AI (Le Chat) ──────────────────────────────────────────────────
User-agent: MistralAI-User
Allow: /

# ── DeepSeek ──────────────────────────────────────────────────────────────
User-agent: DeepseekBot
Allow: /

# ── You.com AI Search ─────────────────────────────────────────────────────
User-agent: YouBot
Allow: /

# ── Brave Search ──────────────────────────────────────────────────────────
User-agent: Bravebot
Allow: /

# ── Kagi ──────────────────────────────────────────────────────────────────
User-agent: kagi-fetcher
Allow: /

# ── HuggingFace ───────────────────────────────────────────────────────────
User-agent: HuggingFace-Bot
Allow: /

# ── Firecrawl / Tavily (AI agent tools) ──────────────────────────────────
User-agent: FirecrawlAgent
Allow: /

User-agent: TavilyBot
Allow: /

# ── Sitemaps ──────────────────────────────────────────────────────────────
Sitemap: {baseUrl}/sitemap.xml

# ── LLM readability files ─────────────────────────────────────────────────
# AI-friendly content index:   {baseUrl}/llms.txt
# Full content for LLMs:       {baseUrl}/llms-full.txt
""";

    // ── sitemap.xml ──────────────────────────────────────────────────────

    public static string SitemapXml(string baseUrl)
    {
        var priorities = new Dictionary<string, (string changefreq, string priority)>
        {
            ["/"]                    = ("weekly",  "1.0"),
            ["/science/optics"]      = ("monthly", "0.9"),
            ["/science/chemistry"]   = ("monthly", "0.9"),
            ["/culture/symbolism"]   = ("monthly", "0.9"),
            ["/culture/art-history"] = ("monthly", "0.9"),
            ["/guides/color-theory"] = ("monthly", "0.8"),
            ["/resources"]           = ("monthly", "0.7"),
        };

        var urls = string.Join("\n", AllPaths.Select(p =>
        {
            var (changefreq, priority) = priorities.GetValueOrDefault(p, ("monthly", "0.7"));
            return $"""
  <url>
    <loc>{baseUrl}{p}</loc>
    <lastmod>{DateModified}</lastmod>
    <changefreq>{changefreq}</changefreq>
    <priority>{priority}</priority>
  </url>""";
        }));

        return $"""
<?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
{urls}
</urlset>
""";
    }

    // ── llms.txt (AI readability standard) ──────────────────────────────

    public static string LlmsTxt(string baseUrl) => $"""
# {SiteName}

> {SiteDescription}

{SiteName} bridges hard science and cultural studies, providing in-depth research on red light optics, pigment chemistry, global symbolism, art history spanning 40,000 years, and practical color theory for designers.

Published: {DatePublished} | Last updated: {DateModified}

## Science

- [Optics & Perception]({baseUrl}/science/optics): Red light wavelengths (620-750nm), L-cone photoreceptor biology, Rayleigh scattering, OLED and quantum dot display technology.
- [Pigment Chemistry]({baseUrl}/science/chemistry): Chemical mechanisms of red pigments — iron oxide ochre (Fe₂O₃, 40,000+ years), cinnabar (HgS, toxic mercury sulfide), cochineal carminic acid (C₂₂H₂₀O₁₃), cadmium selenide (CdSe/CdS) with band-gap tuning.

## Culture

- [Global Symbolism]({baseUrl}/culture/symbolism): Red symbolism across East Asia (luck, 红包), South Asia (Hindu sindoor, shakti), Middle East, Americas (Aztec cochineal), and Africa (Maasai, Himba ochre). References Berlin & Kay (1969) universals.
- [Art History]({baseUrl}/culture/art-history): 40,000-year chronology: Sulawesi hand stencils → Lascaux → Egyptian murals → Roman cinnabar → medieval minium → cochineal discovery → Impressionists → Matisse → Rothko → contemporary art.

## Guides

- [Color Theory]({baseUrl}/guides/color-theory): Red in the color wheel (hue 0°), analogous/triadic/split-complementary palettes, CTA button conversion uplift (10-30%), WCAG AA contrast (4.5:1 minimum), red-green colorblindness (8% of men, 0.5% of women).

## References

- [Resources]({baseUrl}/resources): CSS named reds (crimson #DC143C, firebrick #B22222), Pantone/RAL/Munsell standards, academic bibliography (Berlin & Kay 1969, Elliot & Maier 2014, Pastoureau 2017), and online color tools.

## Optional

- [LLMs Full Content]({baseUrl}/llms-full.txt): Complete page text for LLM context loading.
""";

    public static string LlmsFullTxt(string baseUrl)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"# {SiteName} — Full Content");
        sb.AppendLine($"> {SiteDescription}");
        sb.AppendLine($"> Published: {DatePublished} | Updated: {DateModified}");
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
        sb.AppendLine("- Red light: 620-750 nm wavelength, 400-484 THz frequency, 1.65-2.00 eV photon energy");
        sb.AppendLine("- Oldest red pigment: red ochre (Fe₂O₃), used 40,000+ years ago");
        sb.AppendLine("- Red is the 3rd color term in every language studied (Berlin & Kay, 1969, 98 languages)");
        sb.AppendLine("- Pure red in HSL: hue 0° / 360°");
        sb.AppendLine("- WCAG AA minimum contrast for red text: 4.5:1");
        sb.AppendLine("- Red-green colorblindness prevalence: ~8% men, ~0.5% women");
        sb.AppendLine("- CTA conversion uplift for red buttons: 10-30% in A/B tests");
        sb.AppendLine("- Cochineal: ~70,000 insects per pound of carmine dye");

        return sb.ToString();
    }

    // ── Bot pages ────────────────────────────────────────────────────────

    private static string HomePage(string baseUrl, string path) => Layout(
        title: "Crimson Research Institute",
        metaDescription: "The leading resource on the science, culture, and applications of red — from electromagnetic wavelengths to global symbolism.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "What is the Crimson Research Institute?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "The Crimson Research Institute is the internet's most comprehensive research resource on the color red. We bridge hard science and cultural studies, covering electromagnetic optics, pigment chemistry, cross-cultural symbolism, art history spanning 40,000 years, and practical color theory."
      }
    },
    {
      "@type": "Question",
      "name": "What topics does the Crimson Research Institute cover?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "We cover five research areas: (1) Optics & Perception — the physics of red light at 620-750nm and human photoreceptor biology; (2) Pigment Chemistry — from iron oxide ochre to cadmium selenide; (3) Global Symbolism — how red carries meaning across civilizations; (4) Art History — 40,000 years from cave paintings to contemporary installation; (5) Color Theory — practical frameworks for designers."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Crimson Research Institute</h1>
<p>
    Welcome to the Crimson Research Institute — the internet's most comprehensive resource
    on the color red. We bridge the gap between hard science and cultural studies, offering
    peer-reviewed insights into how red wavelengths interact with human physiology, how red
    pigments shaped trade routes across millennia, and how red continues to dominate visual
    communication in the modern world.
</p>
<p>
    Our research spans electromagnetic optics, pigment chemistry, cross-cultural symbolism,
    and practical color theory. Whether you are an academic, a designer, or simply curious
    about why red demands attention like no other color, our library of in-depth articles
    will guide you through the science and the story.
</p>
<h2 style="color:{{Accent}}">Research Areas</h2>
<div style="display:grid; gap:1rem; margin-top:1rem;">
    <div style="border-left:4px solid {{Accent}}; padding-left:1rem;">
        <strong><a href="/science/optics" style="color:{{Accent}}">Optics &amp; Perception</a></strong>
        <p style="margin:0.25rem 0 0">How 620–750 nm wavelengths interact with the human visual system</p>
    </div>
    <div style="border-left:4px solid {{Accent}}; padding-left:1rem;">
        <strong><a href="/science/chemistry" style="color:{{Accent}}">Pigment Chemistry</a></strong>
        <p style="margin:0.25rem 0 0">From iron oxide to cadmium selenide — the molecules behind red</p>
    </div>
    <div style="border-left:4px solid {{Accent}}; padding-left:1rem;">
        <strong><a href="/culture/symbolism" style="color:{{Accent}}">Global Symbolism</a></strong>
        <p style="margin:0.25rem 0 0">How red carries meaning across civilizations and centuries</p>
    </div>
    <div style="border-left:4px solid {{Accent}}; padding-left:1rem;">
        <strong><a href="/culture/art-history" style="color:{{Accent}}">Red in Art History</a></strong>
        <p style="margin:0.25rem 0 0">From Paleolithic ochre to Rothko's color fields</p>
    </div>
    <div style="border-left:4px solid {{Accent}}; padding-left:1rem;">
        <strong><a href="/guides/color-theory" style="color:{{Accent}}">Color Theory Guide</a></strong>
        <p style="margin:0.25rem 0 0">Practical frameworks for using red in design and communication</p>
    </div>
</div>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>What is the Crimson Research Institute?</strong></summary>
    <p>The Crimson Research Institute is the internet's most comprehensive research resource on the color red. We bridge hard science and cultural studies, covering electromagnetic optics, pigment chemistry, cross-cultural symbolism, art history spanning 40,000 years, and practical color theory.</p>
</details>
<details>
    <summary><strong>What topics does the Crimson Research Institute cover?</strong></summary>
    <p>We cover five research areas: (1) <a href="/science/optics">Optics & Perception</a> — the physics of red light at 620–750 nm and human photoreceptor biology; (2) <a href="/science/chemistry">Pigment Chemistry</a> — from iron oxide ochre to cadmium selenide; (3) <a href="/culture/symbolism">Global Symbolism</a> — how red carries meaning across civilizations; (4) <a href="/culture/art-history">Art History</a> — 40,000 years from cave paintings to contemporary installation; (5) <a href="/guides/color-theory">Color Theory</a> — practical frameworks for designers.</p>
</details>
</section>
""");

    private static string OpticsPage(string baseUrl, string path) => Layout(
        title: "Optics of Red Light — Electromagnetic Properties and Human Perception",
        metaDescription: "Detailed scientific analysis of red light wavelengths (620-750nm), photoreceptor response, and the physics of red in the visible spectrum.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "What wavelength is red light?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Red light occupies the wavelength range of approximately 620 to 750 nanometers (nm) in the visible electromagnetic spectrum. This corresponds to a frequency range of 400–484 THz and a photon energy of 1.65–2.00 eV."
      }
    },
    {
      "@type": "Question",
      "name": "Why does red light scatter less than other colors?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Red light scatters less due to Rayleigh scattering, where scattering intensity is proportional to 1/λ⁴ (one over wavelength to the fourth power). Because red has a longer wavelength than blue or green, it scatters far less in the atmosphere. This is why sunsets appear red and why red warning lights are visible through fog."
      }
    },
    {
      "@type": "Question",
      "name": "Why do sunsets appear red?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "At sunrise and sunset, sunlight travels a longer path through the atmosphere. The shorter blue and green wavelengths scatter away via Rayleigh scattering (proportional to 1/λ⁴), leaving the longer red and orange wavelengths to reach the observer directly, producing the characteristic red-orange sky."
      }
    },
    {
      "@type": "Question",
      "name": "How is red produced in modern display technology?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Modern displays use several approaches: OLED displays use organic electroluminescent compounds that emit red light when electrically excited. Quantum dot displays use precisely-sized cadmium selenide nanocrystals (CdSe) that emit pure red at exact wavelengths due to quantum confinement. The Rec. 2020 color space standard pushes red primaries to 630 nm for maximum color gamut."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Optics &amp; Perception of Red</h1>
<p>
    Red occupies the longest-wavelength end of the visible spectrum, spanning approximately
    620 to 750 nanometers. Of the three types of cone photoreceptors in the human retina,
    L-cones (long-wavelength sensitive) peak near 564 nm but extend their sensitivity well
    into the red range, allowing us to perceive these wavelengths as the vivid color we
    call red. This physiological sensitivity is not accidental — it evolved to help primates
    detect ripe fruit against green foliage.
</p>
<p>
    Red light scatters less in the atmosphere than shorter wavelengths, which is why sunsets
    and sunrises appear red: when sunlight travels a longer path through the atmosphere at
    low angles, blue and green wavelengths are scattered away, leaving red and orange to
    dominate the sky. This same principle makes red ideal for warning signals — red light
    penetrates fog and haze more effectively than blue or green.
</p>
<p>
    In display technology, red has undergone a revolution. Early CRT monitors used europium-
    doped yttrium oxide phosphors to produce red. Modern OLED displays achieve red through
    organic electroluminescent compounds, while quantum dot displays use precisely-sized
    cadmium selenide nanocrystals to emit pure, saturated red at exact wavelengths. The
    Rec. 2020 color space standard pushes red primaries to 630 nm, demanding ever-purer
    red sources from display manufacturers.
</p>
<h2 style="color:{{Accent}}">Key Physical Properties</h2>
<ul>
    <li><strong>Wavelength range:</strong> 620–750 nm</li>
    <li><strong>Frequency:</strong> 400–484 THz</li>
    <li><strong>Photon energy:</strong> 1.65–2.00 eV</li>
    <li><strong>Rayleigh scattering:</strong> Minimal (1/λ⁴ dependency favors longer wavelengths)</li>
    <li><strong>Photoreceptor peak:</strong> L-cones at ~564 nm, extended sensitivity to 700+ nm</li>
</ul>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>What wavelength is red light?</strong></summary>
    <p>Red light occupies 620–750 nm, corresponding to 400–484 THz frequency and 1.65–2.00 eV photon energy.</p>
</details>
<details>
    <summary><strong>Why does red light scatter less than other colors?</strong></summary>
    <p>Rayleigh scattering intensity is proportional to 1/λ⁴. Red's longer wavelength means far less scattering compared to blue or green — this is why fog lights are red and sunsets appear orange-red.</p>
</details>
<details>
    <summary><strong>Why do sunsets appear red?</strong></summary>
    <p>At low sun angles, light travels a longer atmospheric path. Blue and green scatter away (1/λ⁴), leaving red and orange wavelengths to reach the observer.</p>
</details>
<details>
    <summary><strong>How is red produced in modern display technology?</strong></summary>
    <p>OLED displays use organic electroluminescent compounds. Quantum dot displays use precisely-sized CdSe nanocrystals that emit at exact wavelengths via quantum confinement. Rec. 2020 targets 630 nm for the red primary.</p>
</details>
</section>
""");

    private static string ChemistryPage(string baseUrl, string path) => Layout(
        title: "Chemistry of Red Pigments — From Iron Oxide to Modern Synthetics",
        metaDescription: "Comprehensive guide to the chemical compounds that produce red color: ochre, cinnabar, cochineal, cadmium red, and modern synthetic pigments.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "What is the oldest red pigment?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Red ochre (Fe₂O₃, iron(III) oxide / hematite) is the oldest red pigment in human use, with evidence of use stretching back over 40,000 years. Its color arises from ligand-to-metal charge transfer in the iron oxide crystal structure. It is chemically stable, non-toxic, and abundant."
      }
    },
    {
      "@type": "Question",
      "name": "Is cinnabar (vermilion) safe to use?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "No. Cinnabar is mercury sulfide (HgS) and is highly toxic. Chinese artisans and Roman painters who worked extensively with cinnabar frequently suffered mercury poisoning. Modern vermilion pigments use non-toxic synthetic alternatives."
      }
    },
    {
      "@type": "Question",
      "name": "What makes cadmium red special as a pigment?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Cadmium red (CdSe/CdS) offers exceptional lightfastness and opacity. The selenium content shifts the band gap from yellow (CdS at 2.42 eV) toward deep red (CdSe at 1.74 eV), allowing manufacturers to produce any hue from light red to maroon by adjusting the Se:S ratio."
      }
    },
    {
      "@type": "Question",
      "name": "What is carminic acid and where does it come from?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Carminic acid (C₂₂H₂₀O₁₃) is a natural red dye extracted from cochineal scale insects. Its anthraquinone chromophore absorbs green-blue light (peak ~530 nm), reflecting crimson-red. It takes approximately 70,000 cochineal insects to produce one pound of carmine dye. Despite this, it remains FDA-approved and is used in cosmetics, food coloring, and textiles."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Pigment Chemistry of Red</h1>
<p>
    The chemistry of red pigments spans the entire history of human material science, from
    Paleolithic iron oxides to 21st-century quantum dots. Each red pigment achieves its color
    through a different mechanism — electron transitions in metal oxides, conjugated double
    bonds in organic molecules, or quantum confinement in semiconductor nanocrystals.
</p>
<h2 style="color:{{Accent}}">Inorganic Red Pigments</h2>
<p>
    <strong>Red ochre (Fe₂O₃)</strong> — hematite — is the oldest pigment in human use. Its
    red color arises from ligand-to-metal charge transfer transitions in the iron(III) oxide
    crystal structure. Ochre is chemically stable, non-toxic, and abundant, which explains
    its 40,000+ year track record in art and decoration.
</p>
<p>
    <strong>Cinnabar (HgS)</strong> — mercury sulfide — produces a brilliant vermilion red
    through its semiconductor band gap of approximately 2.0 eV, which absorbs blue-green
    light and reflects red. Despite its beauty, cinnabar's mercury content makes it highly
    toxic. Chinese artisans and Roman painters who worked with cinnabar frequently suffered
    mercury poisoning.
</p>
<p>
    <strong>Cadmium red (CdSe/CdS)</strong> — introduced in 1910, cadmium selenide and
    cadmium sulfoselenide pigments offer exceptional lightfastness and opacity. The selenium
    content shifts the band gap from the yellow of pure CdS (2.42 eV) toward the red
    (approximately 1.74 eV for pure CdSe), allowing manufacturers to produce a range from
    light red to deep maroon by adjusting the Se:S ratio.
</p>
<h2 style="color:{{Accent}}">Biological Red Compounds</h2>
<p>
    <strong>Carminic acid (C₂₂H₂₀O₁₃)</strong> — extracted from cochineal scale insects —
    produces crimson through its anthraquinone chromophore. The conjugated ring system absorbs
    green-blue light (peak absorption ~530 nm), reflecting red. It takes approximately 70,000
    cochineal insects to produce one pound of carmine dye, making it one of the most labor-
    intensive colorants ever produced. Despite this, it remains FDA-approved and is still used
    in cosmetics, food coloring, and textiles today.
</p>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>What is the oldest red pigment?</strong></summary>
    <p>Red ochre (Fe₂O₃, hematite) — used for over 40,000 years. Non-toxic, stable, and still used today.</p>
</details>
<details>
    <summary><strong>Is cinnabar (vermilion) safe to use?</strong></summary>
    <p>No. Cinnabar is mercury sulfide (HgS) and is highly toxic. Historic artists who used it frequently suffered mercury poisoning. Modern vermilion uses synthetic alternatives.</p>
</details>
<details>
    <summary><strong>What makes cadmium red special as a pigment?</strong></summary>
    <p>Exceptional lightfastness and opacity. Band gap tuning (Se:S ratio shifts 2.42 eV → 1.74 eV) lets manufacturers produce any red hue from light pink to deep maroon.</p>
</details>
<details>
    <summary><strong>What is carminic acid and where does it come from?</strong></summary>
    <p>Natural red dye (C₂₂H₂₀O₁₃) from cochineal insects. ~70,000 insects per pound of carmine. FDA-approved for food, cosmetics, and textiles.</p>
</details>
</section>
""");

    private static string SymbolismPage(string baseUrl, string path) => Layout(
        title: "Red Symbolism Across Cultures — Universal Meanings and Regional Variations",
        metaDescription: "Cross-cultural analysis of red symbolism: love, danger, luck, revolution, and sacred meaning across civilizations worldwide.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "What does red symbolize in Chinese culture?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "In Chinese culture, red (红, hóng) symbolizes luck, prosperity, and celebration. Red envelopes (红包) containing money are given at Lunar New Year and weddings. Brides traditionally wear red. Stock market gains are displayed in red (opposite of Western convention). The association traces to the legend of Nian, a mythical beast frightened by the color red."
      }
    },
    {
      "@type": "Question",
      "name": "Why is red the third color term to appear in all languages?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Berlin and Kay's landmark 1969 study of 98 languages found that after black and white, red is invariably the third color term to emerge in every language studied. This universal pattern reflects red's deep biological significance — blood, fire, ripe fruit — and its importance in human survival."
      }
    },
    {
      "@type": "Question",
      "name": "What does red mean in Hindu tradition?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "In Hindu tradition, red is the color of Shakti (divine feminine power) and fertility. Brides wear red as a symbol of marital prosperity. Sindoor — red vermilion powder — is applied to the hair parting to indicate married status. Red is also associated with the goddess Durga and divine energy."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Global Symbolism of Red</h1>
<p>
    Red is the most symbolically loaded color in human culture. Linguistic research shows that
    after black and white, red is invariably the third color term to emerge in every language
    — a pattern documented by Berlin and Kay in their landmark 1969 study of 98 languages.
    This linguistic priority reflects red's deep biological and cultural significance.
</p>
<h2 style="color:{{Accent}}">East Asia</h2>
<p>
    In China, red (红, hóng) symbolizes luck, prosperity, and celebration. Red envelopes
    (红包) containing money are given at Lunar New Year and weddings. Brides traditionally wear
    red, and stock market gains are displayed in red (the opposite of Western convention). The
    association dates to the legend of Nian, a mythical beast frightened away by the color red,
    firecrackers, and loud noise. In Japan, red (赤, aka) is associated with vitality,
    happiness, and good fortune. Shinto shrine gates (torii) are painted vermilion to mark the
    boundary between the mundane and the sacred.
</p>
<h2 style="color:{{Accent}}">South Asia &amp; Middle East</h2>
<p>
    In Hindu tradition, red is the color of Shakti (divine feminine power) and is worn by brides
    as a symbol of fertility and marital prosperity. Sindoor — red vermilion powder applied to the
    hair parting — indicates married status. In Islamic art, red appears frequently in geometric
    patterns and calligraphy, often representing courage, sacrifice, and the blood of martyrs.
    Persian rugs use red extensively, with madder root providing the traditional dye.
</p>
<h2 style="color:{{Accent}}">The Americas &amp; Africa</h2>
<p>
    For the Aztecs, red was associated with Huitzilopochtli, the god of war and the sun, and
    was produced from cochineal insects — so valuable that it was used as currency. In many
    African cultures, red ochre holds spiritual significance: the Maasai of Kenya and Tanzania
    use it to adorn warriors' hair and bodies, while the Himba of Namibia mix ochre with
    butterfat to create otjize, the distinctive red body coating that signifies cultural
    identity and beauty.
</p>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>What does red symbolize in Chinese culture?</strong></summary>
    <p>Luck, prosperity, and celebration. Red envelopes (红包) for Lunar New Year and weddings. Red = stock market gains (inverse of Western convention). Associated with the legend of Nian beast.</p>
</details>
<details>
    <summary><strong>Why is red the third color term in all languages?</strong></summary>
    <p>Berlin & Kay (1969) studied 98 languages and found red invariably emerges as the third color term after black and white — reflecting its biological salience (blood, fire, ripe fruit).</p>
</details>
<details>
    <summary><strong>What does red mean in Hindu tradition?</strong></summary>
    <p>Red represents Shakti (divine feminine power) and fertility. Brides wear red. Sindoor (red vermilion powder) marks married status. Associated with the goddess Durga.</p>
</details>
</section>
""");

    private static string ArtHistoryPage(string baseUrl, string path) => Layout(
        title: "Red in Art History — From Cave Paintings to Contemporary Installation",
        metaDescription: "A chronological survey of how artists have used red across 40,000 years: ochre, vermilion, carmine, cadmium, and digital red.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "What is the oldest known red artwork?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "The oldest known red artworks are hand stencils at Sulawesi, Indonesia, dating to at least 39,900 years ago, made with red ochre spray. The Lascaux cave paintings in France (approximately 17,000 years ago) also used red ochre extensively alongside manganese black to depict horses, bulls, and deer."
      }
    },
    {
      "@type": "Question",
      "name": "Who are famous artists known for their use of red?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Notable artists associated with red include: Titian (Titian red, deep auburn tones in Renaissance portraits), Henri Matisse (declared he wanted his reds to 'burn' the viewer, exemplified in The Red Studio, 1911), Mark Rothko (luminous red Seagram Murals and Harvard Murals, 1960s), and Anish Kapoor (color as contested artistic territory)."
      }
    },
    {
      "@type": "Question",
      "name": "How did the discovery of cochineal change European painting?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "The discovery of cochineal insects in the New World transformed European painting after the Spanish brought the dye to Europe in the 16th century. Carmine lake made from cochineal produced a far more brilliant and transparent crimson than any previous red pigment. Tintoretto, Rubens, and Vermeer all used it, and it remained dominant until synthetic dyes replaced it in the 19th century."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Red in Art History</h1>
<h2 style="color:{{Accent}}">Prehistoric to Ancient (40,000 BCE – 500 CE)</h2>
<p>
    The earliest known art is inseparable from red. Hand stencils at Sulawesi (Indonesia),
    dating to at least 39,900 years ago, used red ochre spray. The Lascaux caves in France
    (17,000 years ago) deployed red ochre alongside manganese black to depict horses, bulls,
    and deer. In ancient Egypt, red symbolized both life (as the color of blood) and the
    dangerous desert god Set. Egyptian painters used red ochre and realgar (arsenic sulfide)
    for murals and sarcophagi. Roman frescoists paid extraordinary sums for cinnabar vermilion,
    with Pliny the Elder recording prices of 50 sesterces per pound.
</p>
<h2 style="color:{{Accent}}">Medieval to Renaissance (500 – 1600 CE)</h2>
<p>
    Medieval illuminated manuscripts used red lead (minium, Pb₃O₄) so extensively that
    decorated initial letters became known as "miniatures" — from the Latin minium, not
    from "minute." The discovery of cochineal in the New World transformed European painting:
    Tintoretto, Rubens, and Vermeer all used carmine lake made from cochineal. Titian became
    so associated with his rich, warm reds that the phrase "Titian red" entered the language
    to describe a particular deep auburn.
</p>
<h2 style="color:{{Accent}}">Modern to Contemporary (1800 – Present)</h2>
<p>
    The Impressionists broke with academic convention by using pure, unmixed cadmium red
    directly from the tube — Renoir's flesh tones and Monet's poppy fields exploited the
    pigment's intensity. Matisse declared he wanted his reds to "burn" the viewer, a goal
    spectacularly achieved in The Red Studio (1911), where red occupies nearly the entire
    canvas. Mark Rothko's luminous red paintings of the 1960s — including the Seagram Murals
    and the Harvard Murals — used layers of transparent red to create depth that seems to
    pulse and breathe. In contemporary art, Anish Kapoor's exclusive license to Vantablack
    sparked a color war, with Stuart Semple creating the "pinkest pink" and "reddest red"
    pigments in protest, highlighting how red remains a contested territory in art.
</p>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>What is the oldest known red artwork?</strong></summary>
    <p>Hand stencils at Sulawesi, Indonesia — at least 39,900 years old — made with red ochre. Lascaux caves (France, ~17,000 BCE) used red ochre extensively.</p>
</details>
<details>
    <summary><strong>Who are famous artists known for their use of red?</strong></summary>
    <p>Titian (Titian red), Matisse (The Red Studio, 1911 — "I want my reds to burn"), Rothko (Seagram Murals, transparent red depth), Rubens and Tintoretto (cochineal carmine).</p>
</details>
<details>
    <summary><strong>How did the discovery of cochineal change European painting?</strong></summary>
    <p>Spanish colonizers brought cochineal from the Americas in the 16th century. Carmine lake was far more brilliant and transparent than earlier reds — Tintoretto, Rubens, and Vermeer all adopted it immediately.</p>
</details>
</section>
""");

    private static string ColorTheoryPage(string baseUrl, string path) => Layout(
        title: "Color Theory Guide — Using Red Effectively in Design and Communication",
        metaDescription: "Practical color theory for designers: red's relationships on the color wheel, complementary palettes, psychological impact, and accessibility guidelines.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "Does a red call-to-action button increase conversions?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Yes. Red CTAs consistently outperform other colors in A/B tests, with conversion rate improvements of 10-30% over green and blue alternatives. This is attributed to red's attention-grabbing properties and urgency associations. However, results depend on surrounding context and cultural audience."
      }
    },
    {
      "@type": "Question",
      "name": "What is red's complementary color?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "In the RGB (additive) color model, red's complementary color is cyan. In the traditional RYB (subtractive) model used in painting, red's complement is green. Both pairings create maximum contrast and visual tension when placed together."
      }
    },
    {
      "@type": "Question",
      "name": "How do I make red text accessible (WCAG compliant)?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Red text requires a minimum contrast ratio of 4.5:1 against its background to meet WCAG AA standards. Dark reds like #8B0000 (dark red) or #660000 pass against white. Bright red #FF0000 on white achieves only 3.99:1 and fails AA. Use WebAIM's Contrast Checker to verify specific combinations."
      }
    },
    {
      "@type": "Question",
      "name": "What percentage of people are red-green colorblind?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Approximately 8% of men and 0.5% of women have red-green color blindness (deuteranopia or protanopia). This means roughly 1 in 12 male users cannot reliably distinguish red from green. Always pair color-coded information with icons, labels, or patterns as a secondary encoding."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Color Theory: Working with Red</h1>
<h2 style="color:{{Accent}}">Red on the Color Wheel</h2>
<p>
    Red sits as a primary color in both traditional (RYB) and modern (RGB/additive) color
    models. In the HSL color space, pure red is defined as hue 0° (or 360°), with full
    saturation producing the most vivid expression. Red's complementary color is cyan
    (in RGB) or green (in RYB), creating maximum contrast and visual tension when paired.
    This complementary relationship is why red-green combinations are so eye-catching — and
    why they present the most common accessibility challenge for color-blind users.
</p>
<h2 style="color:{{Accent}}">Palettes and Combinations</h2>
<p>
    <strong>Analogous:</strong> Red paired with red-orange and red-violet creates warm,
    harmonious palettes ideal for conveying energy and passion. <strong>Triadic:</strong>
    Red with blue and yellow produces vibrant, balanced compositions — the foundation of
    countless brand identities and superhero costumes. <strong>Split-complementary:</strong>
    Red with blue-green and yellow-green offers contrast without the starkness of a full
    complementary scheme, making it easier on the eyes while retaining visual impact.
</p>
<h2 style="color:{{Accent}}">Practical Guidelines</h2>
<ul>
    <li><strong>Call-to-action buttons:</strong> Red CTAs consistently outperform other colors in A/B tests, with conversion rate improvements of 10-30% over green and blue alternatives</li>
    <li><strong>Text legibility:</strong> Red text on white backgrounds requires a minimum contrast ratio of 4.5:1 (WCAG AA). Dark reds (#8B0000, #660000) pass; bright reds (#FF0000) often fail</li>
    <li><strong>Cultural awareness:</strong> Verify red's meaning in your target audience — financial gain in China (red = up), financial loss in the West (red = down)</li>
    <li><strong>Proportion:</strong> The 60-30-10 rule works well with red as the 10% accent. Overusing red fatigues the eye and dilutes its attention-grabbing power</li>
    <li><strong>Accessibility:</strong> Approximately 8% of men and 0.5% of women have red-green color blindness (deuteranopia/protanopia). Never rely on red alone to convey meaning — pair with icons, labels, or patterns</li>
</ul>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>Does a red CTA button increase conversions?</strong></summary>
    <p>Yes — 10-30% uplift in A/B tests vs. green or blue. Red's urgency associations drive click-through, but results vary by context and cultural audience.</p>
</details>
<details>
    <summary><strong>What is red's complementary color?</strong></summary>
    <p>Cyan in RGB (additive) model. Green in RYB (subtractive/traditional painting) model. Both pairings create maximum visual contrast.</p>
</details>
<details>
    <summary><strong>How do I make red text WCAG compliant?</strong></summary>
    <p>Minimum 4.5:1 contrast ratio (WCAG AA). #8B0000 or #660000 on white pass. #FF0000 on white achieves only 3.99:1 — fails AA. Use WebAIM Contrast Checker to verify.</p>
</details>
<details>
    <summary><strong>What percentage of people are red-green colorblind?</strong></summary>
    <p>~8% of men, ~0.5% of women have deuteranopia or protanopia. Always pair color coding with icons, labels, or patterns as secondary encoding.</p>
</details>
</section>
""");

    private static string ResourcesPage(string baseUrl, string path) => Layout(
        title: "Red Color Resources — Tools, References, and Further Reading",
        metaDescription: "Curated collection of color tools, academic references, and further reading about the science and culture of red.",
        baseUrl: baseUrl,
        path: path,
        faqJson: """
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "What are the CSS color codes for red?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "CSS named red colors include: red (#FF0000), darkred (#8B0000), crimson (#DC143C), firebrick (#B22222), indianred (#CD5C5C), tomato (#FF6347), orangered (#FF4500), and mediumvioletred (#C71585)."
      }
    },
    {
      "@type": "Question",
      "name": "What Pantone colors are red?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Key Pantone red colors include: Pantone 185 C (bright red), Pantone 200 C (standard red), Pantone 186 C (Coca-Cola red), Pantone 032 C (vivid red), and Pantone 1788 C (warm red). For specific brand applications, always verify the exact Pantone reference."
      }
    },
    {
      "@type": "Question",
      "name": "What academic research covers the psychology of red?",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "Key academic papers on red include: Berlin & Kay (1969) Basic Color Terms — documenting red as a universal 3rd color term; Elliot & Maier (2014) Color Psychology in Annual Review of Psychology; Hill & Barton (2005) Red enhances human performance in contests (Nature, 435); and Pastoureau (2017) Red: The History of a Color (Princeton University Press)."
      }
    }
  ]
}
""",
        bodyContent: $$"""
<article>
<h1 style="color:{{Accent}}">Resources &amp; References</h1>
<h2 style="color:{{Accent}}">Color Specification</h2>
<ul>
    <li><strong>CSS named reds:</strong> red (#FF0000), darkred (#8B0000), crimson (#DC143C), firebrick (#B22222), indianred (#CD5C5C), tomato (#FF6347)</li>
    <li><strong>Pantone reds:</strong> 185 C, 200 C, 186 C (Coca-Cola red), 032 C (bright red)</li>
    <li><strong>RAL:</strong> 3000 (Flame red), 3003 (Ruby red), 3020 (Traffic red)</li>
    <li><strong>Munsell:</strong> 5R (pure red hue page), valued by artists and color scientists</li>
</ul>
<h2 style="color:{{Accent}}">Academic References</h2>
<ul>
    <li>Berlin, B. &amp; Kay, P. (1969). <em>Basic Color Terms: Their Universality and Evolution</em></li>
    <li>Elliot, A.J. &amp; Maier, M.A. (2014). Color psychology: Effects of perceiving color on psychological functioning in humans. <em>Annual Review of Psychology</em>, 65, 95-120</li>
    <li>Hill, R.A. &amp; Barton, R.A. (2005). Red enhances human performance in contests. <em>Nature</em>, 435, 293</li>
    <li>Gage, J. (1999). <em>Color and Meaning: Art, Science, and Symbolism</em>. University of California Press</li>
    <li>Pastoureau, M. (2017). <em>Red: The History of a Color</em>. Princeton University Press</li>
</ul>
<h2 style="color:{{Accent}}">Online Tools</h2>
<ul>
    <li>Adobe Color — create and explore red-based color palettes</li>
    <li>Coolors.co — generate harmonious palettes with red primaries</li>
    <li>WebAIM Contrast Checker — validate red text/background accessibility</li>
    <li>Color Oracle — simulate color blindness to test red-dependent designs</li>
</ul>
</article>
<section class="faq">
<h2 style="color:{{Accent}}">Frequently Asked Questions</h2>
<details open>
    <summary><strong>What are the CSS color codes for red?</strong></summary>
    <p>red (#FF0000), darkred (#8B0000), crimson (#DC143C), firebrick (#B22222), indianred (#CD5C5C), tomato (#FF6347), orangered (#FF4500).</p>
</details>
<details>
    <summary><strong>What Pantone colors are red?</strong></summary>
    <p>185 C (bright red), 200 C (standard red), 186 C (Coca-Cola red), 032 C (vivid red), 1788 C (warm red).</p>
</details>
<details>
    <summary><strong>What academic research covers the psychology of red?</strong></summary>
    <p>Berlin & Kay (1969) universals; Elliot & Maier (2014) Annual Review of Psychology; Hill & Barton (2005) Nature 435; Pastoureau (2017) Princeton UP.</p>
</details>
</section>
""");

    // ── Shared layout ────────────────────────────────────────────────────

    private static string Layout(
        string title,
        string metaDescription,
        string bodyContent,
        string path = "/",
        string baseUrl = "",
        string? faqJson = null)
    {
        var canonicalUrl = Encode(baseUrl + path);
        var escapedTitle = EscapeJson(title);
        var escapedDescription = EscapeJson(metaDescription);
        var escapedBaseUrl = EscapeJson(baseUrl);
        var escapedCanonical = EscapeJson(baseUrl + path);
        var escapedSiteName = EscapeJson(SiteName);
        var escapedSiteDescription = EscapeJson(SiteDescription);

        var isHome = path == "/" || path == "";
        var schemaType = isHome ? "WebPage" : "Article";

        // Breadcrumb items for non-home pages
        var breadcrumbJson = BuildBreadcrumbJson(path, baseUrl);

        // WebSite schema for home page only
        var websiteSchema = isHome ? $$"""
<script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "WebSite",
  "@id": "{{EscapeJson(baseUrl)}}/#website",
  "name": "{{escapedSiteName}}",
  "url": "{{escapedBaseUrl}}",
  "description": "{{escapedSiteDescription}}",
  "inLanguage": "en"
}
</script>
""" : "";

        // BreadcrumbList for non-home pages
        var breadcrumbSchema = !isHome && !string.IsNullOrEmpty(breadcrumbJson) ? $"""
<script type="application/ld+json">
{breadcrumbJson}
</script>
""" : "";

        // FAQPage schema block
        var faqSchema = faqJson != null ? $"""
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
    <title>{{Encode(title)}}</title>
    <meta name="description" content="{{Encode(metaDescription)}}">
    <meta name="robots" content="index, follow">
    <link rel="canonical" href="{{canonicalUrl}}">

    <!-- Open Graph -->
    <meta property="og:type" content="{{(isHome ? "website" : "article")}}">
    <meta property="og:url" content="{{canonicalUrl}}">
    <meta property="og:title" content="{{Encode(title)}}">
    <meta property="og:description" content="{{Encode(metaDescription)}}">
    <meta property="og:site_name" content="{{Encode(SiteName)}}">
    <meta property="og:locale" content="en_US">

    <!-- Twitter Card -->
    <meta name="twitter:card" content="summary">
    <meta name="twitter:title" content="{{Encode(title)}}">
    <meta name="twitter:description" content="{{Encode(metaDescription)}}">

    <!-- Structured Data: Page -->
    <script type="application/ld+json">
    {
      "@context": "https://schema.org",
      "@type": "{{schemaType}}",
      "@id": "{{escapedCanonical}}",
      "headline": "{{escapedTitle}}",
      "name": "{{escapedTitle}}",
      "description": "{{escapedDescription}}",
      "url": "{{escapedCanonical}}",
      "inLanguage": "en",
      "datePublished": "{{DatePublished}}",
      "dateModified": "{{DateModified}}",
      "author": {
        "@type": "Organization",
        "name": "{{escapedSiteName}}",
        "url": "{{escapedBaseUrl}}"
      },
      "publisher": {
        "@type": "Organization",
        "name": "{{escapedSiteName}}",
        "url": "{{escapedBaseUrl}}"
      },
      "isPartOf": {
        "@type": "WebSite",
        "@id": "{{escapedBaseUrl}}/#website",
        "name": "{{escapedSiteName}}",
        "url": "{{escapedBaseUrl}}"
      }
    }
    </script>
    {{websiteSchema}}{{breadcrumbSchema}}{{faqSchema}}
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            font-family: system-ui, -apple-system, 'Segoe UI', Roboto, sans-serif;
            background: {{Bg}};
            color: {{Text}};
            line-height: 1.7;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }
        nav {
            background: {{Accent}};
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
        main a { color: {{Accent}}; }
        .faq { margin-top: 2rem; }
        .faq details { border-left: 3px solid {{Accent}}; padding-left: 1rem; margin-bottom: 0.75rem; }
        .faq summary { cursor: pointer; padding: 0.5rem 0; }
        .faq details p { margin-top: 0.5rem; margin-bottom: 0.25rem; }
        footer {
            background: {{Accent}};
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
        <a href="/" class="brand">Crimson Research Institute</a>
        <a href="/science/optics">Optics</a>
        <a href="/science/chemistry">Chemistry</a>
        <a href="/culture/symbolism">Symbolism</a>
        <a href="/culture/art-history">Art History</a>
        <a href="/guides/color-theory">Color Theory</a>
        <a href="/resources">Resources</a>
    </nav>
    <main>
        {{bodyContent}}
    </main>
    <footer>
        &copy; <time datetime="{{DateModified}}">2026</time> {{Encode(SiteName)}} — Exploring the science and culture of red.
        &nbsp;|&nbsp; <a href="/llms.txt" style="color:rgba(255,255,255,0.7)">llms.txt</a>
    </footer>
</body>
</html>
""";
    }

    private static string BuildBreadcrumbJson(string path, string baseUrl)
    {
        var items = path switch
        {
            "/science/optics"     => new[] { ("Home", "/"), ("Science", "/science"), ("Optics & Perception", "/science/optics") },
            "/science/chemistry"  => new[] { ("Home", "/"), ("Science", "/science"), ("Pigment Chemistry", "/science/chemistry") },
            "/culture/symbolism"  => new[] { ("Home", "/"), ("Culture", "/culture"), ("Global Symbolism", "/culture/symbolism") },
            "/culture/art-history"=> new[] { ("Home", "/"), ("Culture", "/culture"), ("Art History", "/culture/art-history") },
            "/guides/color-theory"=> new[] { ("Home", "/"), ("Guides", "/guides"), ("Color Theory", "/guides/color-theory") },
            "/resources"          => new[] { ("Home", "/"), ("Resources", "/resources") },
            _                     => Array.Empty<(string, string)>()
        };

        if (items.Length == 0) return "";

        var listItems = items.Select((item, i) =>
            $"    {{\"@type\": \"ListItem\", \"position\": {i + 1}, \"name\": \"{EscapeJson(item.Item1)}\", \"item\": \"{EscapeJson(baseUrl + item.Item2)}\"}}");

        return "{\n" +
               "  \"@context\": \"https://schema.org\",\n" +
               "  \"@type\": \"BreadcrumbList\",\n" +
               "  \"itemListElement\": [\n" +
               string.Join(",\n", listItems) + "\n" +
               "  ]\n" +
               "}";
    }

    private static string Encode(string value) =>
        System.Net.WebUtility.HtmlEncode(value);

    private static string EscapeJson(string value) =>
        value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
