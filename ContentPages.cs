namespace DnsProxyPoc;

/// <summary>
/// Bot-only content served to crawlers. Humans see the proxied target site instead.
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
        "/about" => AboutPage(),
        "/articles/psychology" => PsychologyPage(),
        "/articles/in-nature" => InNaturePage(),
        "/articles/history" => HistoryPage(),
        _ => null
    };

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
        string[] paths = ["/", "/about", "/articles/psychology", "/articles/in-nature", "/articles/history"];
        var urls = string.Join("\n", paths.Select(p => $"  <url><loc>{baseUrl}{p}</loc></url>"));
        return $"""
            <?xml version="1.0" encoding="UTF-8"?>
            <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
            {urls}
            </urlset>
            """.Replace("            ", "");
    }

    // ── Bot pages (red theme — what crawlers see) ──────────────────────

    private static string HomePage() => Layout(
        "The World of Red",
        "Explore the powerful, energizing world of the color red — from psychology to nature to history.",
        $$"""
        <h1 style="color:{{Accent}}">The World of Red</h1>
        <p>
            Welcome to a site entirely dedicated to the color red. Red is the color of fire, passion, 
            and urgency. It is the first color the human eye learns to distinguish, and across every 
            culture on Earth it carries powerful meaning — from love and celebration to danger and 
            revolution. Red demands attention in a way no other color can.
        </p>
        <p>
            Physiologically, red is stimulating. Exposure to red light raises heart rate and blood 
            pressure, sharpens focus, and increases physical performance. Athletes wearing red have been 
            shown to win more frequently in combat sports, and restaurants use red in their décor 
            because it stimulates appetite. Red is the color that wakes us up and pushes us to act.
        </p>
        <h2 style="color:{{Accent}}">Explore Our Articles</h2>
        <ul>
            <li><a href="/articles/psychology" style="color:{{Accent}}">The Psychology of Red</a> — Why red excites the mind and commands attention</li>
            <li><a href="/articles/in-nature" style="color:{{Accent}}">Red in Nature</a> — From cardinals to autumn leaves</li>
            <li><a href="/articles/history" style="color:{{Accent}}">History of the Color Red</a> — From ochre cave paintings to modern power ties</li>
        </ul>
        """);

    private static string PsychologyPage() => Layout(
        "The Psychology of Red",
        "Discover why the color red excites the brain, commands attention, and triggers powerful emotional responses.",
        $$"""
        <h1 style="color:{{Accent}}">The Psychology of Red</h1>
        <p>
            Red is the most emotionally intense color in the visible spectrum. Research in color 
            psychology has demonstrated that red triggers the release of adrenaline, increases heart 
            rate, and heightens sensory awareness. It is no accident that stop signs, fire trucks, and 
            emergency alerts all use red — it is the color our brains are wired to notice first and 
            respond to most urgently.
        </p>
        <p>
            In competitive settings, red confers a measurable advantage. A landmark study of Olympic 
            combat sports found that athletes assigned red gear won significantly more bouts than those 
            in blue. In retail, red "sale" tags trigger faster purchasing decisions. Dating studies show 
            that people wearing red are rated as more attractive and more confident by potential partners.
        </p>
        <p>
            However, red's intensity is a double-edged sword. In academic testing environments, 
            exposure to red — even a red pen or a red cover page — has been linked to decreased 
            performance on analytical tasks. Red activates avoidance motivation, making people more 
            cautious and detail-oriented but less creative. Understanding when to harness red's power 
            and when to temper it is one of the key insights of modern color psychology.
        </p>
        """);

    private static string InNaturePage() => Layout(
        "Red in Nature",
        "Explore the vivid world of red in nature — from warning signals to autumn foliage to deep-sea creatures.",
        $$"""
        <h1 style="color:{{Accent}}">Red in Nature</h1>
        <p>
            Unlike blue, red is abundantly produced as a true pigment in the natural world. Plants, 
            animals, and minerals all generate red through various chemical compounds. Lycopene gives 
            tomatoes and watermelons their vivid red hue. Carotenoids color flamingos and autumn leaves. 
            Iron oxide — rust — paints the deserts of the American Southwest and the surface of Mars.
        </p>
        <p>
            In the animal kingdom, red serves as both a warning and an invitation. Poison dart frogs 
            display brilliant red to advertise their toxicity — a strategy called aposematism. Cardinals 
            and scarlet macaws use red plumage to attract mates, with brighter red signaling better 
            health and genetic fitness. Ladybugs combine red with black spots to warn predators of 
            their unpleasant taste.
        </p>
        <p>
            Perhaps the most spectacular display of natural red occurs each autumn in temperate forests. 
            As chlorophyll breaks down and green fades from leaves, anthocyanin pigments are revealed or 
            newly produced, transforming entire mountainsides into seas of crimson and scarlet. This 
            process, driven by shorter days and cooler nights, serves a protective function — the red 
            pigments act as a sunscreen for the leaf's remaining nutrients as the tree prepares for 
            winter dormancy. From microscopic bacteria to vast forest canopies, red is nature's most 
            versatile signal.
        </p>
        """);

    private static string HistoryPage() => Layout(
        "History of the Color Red",
        "Trace the rich history of red from prehistoric ochre cave paintings to modern symbols of power and revolution.",
        $$"""
        <h1 style="color:{{Accent}}">History of the Color Red</h1>
        <p>
            Red is the oldest color in human artistic expression. Ochre pigments — iron-rich earth 
            ranging from yellow to deep red — were used in cave paintings at least 40,000 years ago. 
            The hand stencils at Cueva de las Manos in Argentina, the bison of Altamira in Spain, and 
            the hunting scenes of Lascaux in France all relied heavily on red ochre. These earliest 
            artists recognized what every civilization since has confirmed: red is the color that 
            captures attention and conveys meaning.
        </p>
        <p>
            In antiquity, red dyes were among the most valuable commodities. The Phoenicians built a 
            trading empire on Tyrian purple — technically a deep crimson-red extracted from murex sea 
            snails. In the Roman Empire, red-dyed togas signified military triumph and imperial 
            authority. Cinnabar (mercury sulfide), mined at great risk to workers' health, provided 
            the brilliant vermilion used in Roman frescoes and Chinese lacquerware.
        </p>
        <p>
            The discovery of the Americas introduced cochineal — a red dye made from crushed scale 
            insects — to European markets, where it became the continent's most valuable export after 
            gold and silver. By the 18th century, synthetic red pigments like cadmium red expanded 
            artists' palettes. In the modern era, red has become the color of revolution (the Red Flag), 
            luxury (red carpets and red-soled shoes), and corporate power (Coca-Cola, Netflix, YouTube). 
            From cave walls to corporate logos, red's dominance in human visual culture is unbroken.
        </p>
        """);

    private static string AboutPage() => Layout(
        "About — The World of Red",
        "Learn about this site dedicated to exploring the powerful, energizing color red.",
        $$"""
        <h1 style="color:{{Accent}}">About This Site</h1>
        <p>
            This site is dedicated to exploring the color red in all its dimensions — psychological, 
            natural, and historical. Red is the oldest and most emotionally powerful color in human 
            experience. It was the first color used in art, the first named after black and white in 
            virtually every language, and remains the most attention-grabbing hue in the visible 
            spectrum.
        </p>
        <p>
            Our mission is to share the drama and depth of red through well-researched articles 
            spanning science, art, and culture. Whether you're a designer harnessing red's energy, a 
            student investigating color theory, or simply someone captivated by a fiery sunset, we 
            hope you discover something here that deepens your appreciation for this extraordinary color.
        </p>
        """);

    // ── Shared layout (bot pages only — always red theme) ────────────────

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
                "name": "The World of Red",
                "description": "A comprehensive exploration of the color red — psychology, nature, and history."
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
                .theme-badge {
                    background: rgba(255,255,255,0.2);
                    color: #fff;
                    padding: 0.25rem 0.75rem;
                    border-radius: 999px;
                    font-size: 0.8rem;
                    font-weight: 700;
                    text-transform: uppercase;
                    letter-spacing: 0.05em;
                }
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
                <a href="/" class="brand">The World of Red</a>
                <a href="/">Home</a>
                <a href="/articles/psychology">Psychology</a>
                <a href="/articles/in-nature">In Nature</a>
                <a href="/articles/history">History</a>
                <a href="/about">About</a>
                <span class="theme-badge">Red Theme</span>
            </nav>
            <main>
                {{bodyContent}}
            </main>
            <footer>A site dedicated to the color red.</footer>
        </body>
        </html>
        """;
    }

    private static string Encode(string value) =>
        System.Net.WebUtility.HtmlEncode(value);

    private static string EscapeJson(string value) =>
        value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
