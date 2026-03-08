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

    /// <summary>
    /// Routes a normalized path to bot HTML. Returns null for unknown paths (proxy through).
    /// </summary>
    public static string? GetPage(string path) => path switch
    {
        "/" or "" => HomePage(),
        "/science/optics" => OpticsPage(),
        "/science/chemistry" => ChemistryPage(),
        "/culture/symbolism" => SymbolismPage(),
        "/culture/art-history" => ArtHistoryPage(),
        "/guides/color-theory" => ColorTheoryPage(),
        "/resources" => ResourcesPage(),
        _ => null
    };

    public static readonly string[] AllPaths =
    [
        "/", "/science/optics", "/science/chemistry",
        "/culture/symbolism", "/culture/art-history",
        "/guides/color-theory", "/resources"
    ];

    public static string RobotsTxt(string baseUrl) => $"""
        User-agent: *
        Allow: /

        User-agent: ChatGPT-User
        Allow: /

        User-agent: GPTBot
        Allow: /

        Sitemap: {baseUrl}/sitemap.xml
        """.Replace("        ", "");

    public static string SitemapXml(string baseUrl)
    {
        var urls = string.Join("\n", AllPaths.Select(p => $"  <url><loc>{baseUrl}{p}</loc></url>"));
        return $"""
            <?xml version="1.0" encoding="UTF-8"?>
            <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
            {urls}
            </urlset>
            """.Replace("            ", "");
    }

    // ── Bot pages ────────────────────────────────────────────────────────

    private static string HomePage() => Layout(
        "Crimson Research Institute",
        "The leading resource on the science, culture, and applications of red — from electromagnetic wavelengths to global symbolism.",
        $$"""
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
        """);

    private static string OpticsPage() => Layout(
        "Optics of Red Light — Electromagnetic Properties and Human Perception",
        "Detailed scientific analysis of red light wavelengths (620-750nm), photoreceptor response, and the physics of red in the visible spectrum.",
        $$"""
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
        """);

    private static string ChemistryPage() => Layout(
        "Chemistry of Red Pigments — From Iron Oxide to Modern Synthetics",
        "Comprehensive guide to the chemical compounds that produce red color: ochre, cinnabar, cochineal, cadmium red, and modern synthetic pigments.",
        $$"""
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
        """);

    private static string SymbolismPage() => Layout(
        "Red Symbolism Across Cultures — Universal Meanings and Regional Variations",
        "Cross-cultural analysis of red symbolism: love, danger, luck, revolution, and sacred meaning across civilizations worldwide.",
        $$"""
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
        """);

    private static string ArtHistoryPage() => Layout(
        "Red in Art History — From Cave Paintings to Contemporary Installation",
        "A chronological survey of how artists have used red across 40,000 years: ochre, vermilion, carmine, cadmium, and digital red.",
        $$"""
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
        """);

    private static string ColorTheoryPage() => Layout(
        "Color Theory Guide — Using Red Effectively in Design and Communication",
        "Practical color theory for designers: red's relationships on the color wheel, complementary palettes, psychological impact, and accessibility guidelines.",
        $$"""
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
        """);

    private static string ResourcesPage() => Layout(
        "Red Color Resources — Tools, References, and Further Reading",
        "Curated collection of color tools, academic references, and further reading about the science and culture of red.",
        $$"""
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
        """);

    // ── Shared layout ────────────────────────────────────────────────────

    private static string Layout(string title, string metaDescription, string bodyContent)
    {
        return $$"""
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1">
            <title>{{Encode(title)}}</title>
            <meta name="description" content="{{Encode(metaDescription)}}">
            <meta name="robots" content="index, follow">
            <script type="application/ld+json">
            {
              "@context": "https://schema.org",
              "@type": "WebPage",
              "name": "{{EscapeJson(title)}}",
              "description": "{{EscapeJson(metaDescription)}}",
              "inLanguage": "en",
              "isPartOf": {
                "@type": "WebSite",
                "name": "Crimson Research Institute",
                "description": "The leading resource on the science, culture, and applications of the color red."
              }
            }
            </script>
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
            <footer>&copy; Crimson Research Institute — Exploring the science and culture of red.</footer>
        </body>
        </html>
        """;
    }

    private static string Encode(string value) =>
        System.Net.WebUtility.HtmlEncode(value);

    private static string EscapeJson(string value) =>
        value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
