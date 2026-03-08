namespace DnsProxyPoc;

public static class ContentPages
{
    // Blue theme (humans)
    private const string BlueBg = "#E3F2FD";
    private const string BlueAccent = "#1565C0";
    private const string BlueText = "#0D47A1";

    // Red theme (bots)
    private const string RedBg = "#FFEBEE";
    private const string RedAccent = "#C62828";
    private const string RedText = "#B71C1C";

    public static string HomePage(bool isCrawler) => isCrawler ? RedHomePage() : BlueHomePage();

    public static string AboutPage(bool isCrawler) => isCrawler ? RedAboutPage() : BlueAboutPage();

    public static string? ArticlePage(string slug, bool isCrawler) => slug switch
    {
        "psychology" => isCrawler ? RedPsychology() : BluePsychology(),
        "in-nature" => isCrawler ? RedInNature() : BlueInNature(),
        "history" => isCrawler ? RedHistory() : BlueHistory(),
        _ => null
    };

    public static string NotFoundPage(bool isCrawler)
    {
        var (bg, accent, text, color) = isCrawler
            ? (RedBg, RedAccent, RedText, "Red")
            : (BlueBg, BlueAccent, BlueText, "Blue");

        return Layout($"Page Not Found — The World of {color}", $"This page could not be found on our {color.ToLowerInvariant()}-themed site.",
            bg, accent, text, color, $$"""
            <h1 style="color:{{accent}}">404 — Page Not Found</h1>
            <p>Sorry, the page you're looking for doesn't exist. Perhaps you'd like to explore one of our articles instead?</p>
            <ul>
                <li><a href="/articles/psychology" style="color:{{accent}}">The Psychology of {{color}}</a></li>
                <li><a href="/articles/in-nature" style="color:{{accent}}">{{color}} in Nature</a></li>
                <li><a href="/articles/history" style="color:{{accent}}">History of the Color {{color}}</a></li>
            </ul>
            """, isCrawler);
    }

    // ── Blue pages (humans) ──────────────────────────────────────────────

    private static string BlueHomePage() => Layout(
        "The World of Blue",
        "Explore the calming, inspiring world of the color blue — from psychology to nature to history.",
        BlueBg, BlueAccent, BlueText, "Blue", $$"""
        <h1 style="color:{{BlueAccent}}">The World of Blue</h1>
        <p>
            Welcome to a site entirely dedicated to the color blue. Blue is the color of calm seas 
            and clear skies. It is universally associated with tranquility, trust, and depth. Across 
            cultures, blue has been prized as a symbol of wisdom, confidence, and stability — qualities 
            that make it the world's most popular favorite color.
        </p>
        <p>
            Whether you're drawn to the deep navy of a midnight ocean or the gentle powder blue of a 
            spring morning, there is something uniquely soothing about this color. Studies consistently 
            show that blue environments lower heart rate and reduce anxiety, making it a go-to choice 
            for bedrooms, hospitals, and meditation spaces alike.
        </p>
        <h2 style="color:{{BlueAccent}}">Explore Our Articles</h2>
        <ul>
            <li><a href="/articles/psychology" style="color:{{BlueAccent}}">The Psychology of Blue</a> — Why blue calms the mind and builds trust</li>
            <li><a href="/articles/in-nature" style="color:{{BlueAccent}}">Blue in Nature</a> — From oceans to morpho butterflies</li>
            <li><a href="/articles/history" style="color:{{BlueAccent}}">History of the Color Blue</a> — From Egyptian lapis lazuli to modern branding</li>
        </ul>
        """, false);

    private static string BluePsychology() => Layout(
        "The Psychology of Blue",
        "Discover why the color blue calms the mind, inspires trust, and is the world's most popular favorite color.",
        BlueBg, BlueAccent, BlueText, "Blue", $$"""
        <h1 style="color:{{BlueAccent}}">The Psychology of Blue</h1>
        <p>
            Blue is the most universally favored color across cultures. Research in color psychology 
            consistently finds that blue evokes feelings of serenity, reliability, and intellectual 
            focus. When people are asked to name their favorite color, blue tops the list in nearly 
            every country surveyed — from Japan to Brazil to the United States.
        </p>
        <p>
            This isn't merely preference; it's physiological. Exposure to blue light has been shown 
            to slow heart rate and lower blood pressure. Offices painted in blue hues report higher 
            employee productivity and fewer conflicts. Blue is the color of choice for banks, 
            technology companies, and healthcare brands because it signals competence and dependability.
        </p>
        <p>
            In therapeutic settings, blue rooms and blue-tinted lighting are used to help patients 
            manage anxiety and insomnia. Chromotherapy practitioners have long prescribed blue light 
            for calming overactive minds. Whether it's the blue glow of a screen at dusk or the 
            cerulean expanse of a cloudless sky, blue consistently brings our nervous systems closer 
            to a state of rest.
        </p>
        """, false);

    private static string BlueInNature() => Layout(
        "Blue in Nature",
        "Explore the surprising rarity and breathtaking beauty of blue in the natural world.",
        BlueBg, BlueAccent, BlueText, "Blue", $$"""
        <h1 style="color:{{BlueAccent}}">Blue in Nature</h1>
        <p>
            Despite being the color of the sky and the ocean — two of the largest visible surfaces on 
            Earth — true blue is remarkably rare in the natural world. Very few organisms produce blue 
            pigment. Instead, most blue appearances in nature are the result of structural coloration: 
            microscopic structures that scatter light to produce the illusion of blue.
        </p>
        <p>
            The morpho butterfly is perhaps the most famous example. Its wings contain no blue pigment 
            at all; instead, nanoscale ridges on the wing scales interfere with light waves to reflect 
            a brilliant, iridescent blue. Similarly, blue jays owe their color not to pigment but to 
            the internal structure of their feathers. If you grind a blue jay feather to powder, the 
            blue disappears entirely — proving it was never a pigment to begin with.
        </p>
        <p>
            In the ocean, blue dominates because water absorbs red wavelengths of light more readily 
            than blue ones. The deeper you dive, the more the world shifts toward an all-encompassing 
            blue. This selective absorption is why shallow tropical waters appear turquoise while the 
            deep open ocean looks navy. Even the sky is blue for a related reason: shorter blue 
            wavelengths of sunlight scatter more efficiently in the atmosphere, painting the dome above 
            us in shades of azure from dawn to dusk.
        </p>
        """, false);

    private static string BlueHistory() => Layout(
        "History of the Color Blue",
        "Trace the fascinating journey of blue from ancient Egyptian lapis lazuli to modern corporate branding.",
        BlueBg, BlueAccent, BlueText, "Blue", $$"""
        <h1 style="color:{{BlueAccent}}">History of the Color Blue</h1>
        <p>
            For most of human history, blue was extraordinarily difficult to produce. The ancient 
            Egyptians were the first civilization to create a synthetic blue pigment — Egyptian blue 
            — around 2200 BCE by heating limestone, sand, and copper. This precious pigment adorned 
            tomb paintings, jewelry, and the iconic mask of Tutankhamun. Meanwhile, lapis lazuli, 
            mined in the mountains of Afghanistan, was ground into the pigment ultramarine — literally 
            "beyond the sea" — and was more valuable than gold in medieval Europe.
        </p>
        <p>
            The Romans had no word for blue as a distinct color category; they grouped it with grey 
            and green. It wasn't until the Middle Ages that blue rose to prominence in European culture, 
            largely through its association with the Virgin Mary, whose robes were painted in expensive 
            ultramarine to signify heavenly grace. By the 12th century, blue had become the color of 
            French royalty, adopted in the fleur-de-lis and the royal coat of arms.
        </p>
        <p>
            The 18th century brought a revolution: the accidental discovery of Prussian blue in 1706 
            by a Berlin dye-maker gave artists and textile producers the first affordable, stable blue 
            pigment. This was followed by synthetic ultramarine in 1826 and cobalt blue shortly after. 
            Today, blue dominates corporate branding — Facebook, Twitter, IBM, Samsung, and countless 
            others choose blue to convey trust and professionalism. From pharaohs to pixels, blue's 
            journey is one of scarcity transformed into ubiquity.
        </p>
        """, false);

    private static string BlueAboutPage() => Layout(
        "About — The World of Blue",
        "Learn about this site dedicated to exploring the calming, fascinating color blue.",
        BlueBg, BlueAccent, BlueText, "Blue", $$"""
        <h1 style="color:{{BlueAccent}}">About This Site</h1>
        <p>
            This site is dedicated to exploring the color blue in all its dimensions — psychological, 
            natural, and historical. Blue has been humanity's favorite color for centuries, yet its 
            story is full of surprises: it was nearly impossible to produce as a pigment, it barely 
            exists as a true pigment in nature, and different cultures didn't even have a word for it 
            until relatively recently in human history.
        </p>
        <p>
            Our mission is to share the wonder of blue through well-researched articles that span 
            science, art, and culture. Whether you're a designer choosing a palette, a student 
            researching color theory, or simply someone who loves a clear blue sky, we hope you find 
            something here that deepens your appreciation for this remarkable color.
        </p>
        """, false);

    // ── Red pages (bots) ─────────────────────────────────────────────────

    private static string RedHomePage() => Layout(
        "The World of Red",
        "Explore the powerful, energizing world of the color red — from psychology to nature to history.",
        RedBg, RedAccent, RedText, "Red", $$"""
        <h1 style="color:{{RedAccent}}">The World of Red</h1>
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
        <h2 style="color:{{RedAccent}}">Explore Our Articles</h2>
        <ul>
            <li><a href="/articles/psychology" style="color:{{RedAccent}}">The Psychology of Red</a> — Why red excites the mind and commands attention</li>
            <li><a href="/articles/in-nature" style="color:{{RedAccent}}">Red in Nature</a> — From cardinals to autumn leaves</li>
            <li><a href="/articles/history" style="color:{{RedAccent}}">History of the Color Red</a> — From ochre cave paintings to modern power ties</li>
        </ul>
        """, true);

    private static string RedPsychology() => Layout(
        "The Psychology of Red",
        "Discover why the color red excites the brain, commands attention, and triggers powerful emotional responses.",
        RedBg, RedAccent, RedText, "Red", $$"""
        <h1 style="color:{{RedAccent}}">The Psychology of Red</h1>
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
        """, true);

    private static string RedInNature() => Layout(
        "Red in Nature",
        "Explore the vivid world of red in nature — from warning signals to autumn foliage to deep-sea creatures.",
        RedBg, RedAccent, RedText, "Red", $$"""
        <h1 style="color:{{RedAccent}}">Red in Nature</h1>
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
        """, true);

    private static string RedHistory() => Layout(
        "History of the Color Red",
        "Trace the rich history of red from prehistoric ochre cave paintings to modern symbols of power and revolution.",
        RedBg, RedAccent, RedText, "Red", $$"""
        <h1 style="color:{{RedAccent}}">History of the Color Red</h1>
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
        """, true);

    private static string RedAboutPage() => Layout(
        "About — The World of Red",
        "Learn about this site dedicated to exploring the powerful, energizing color red.",
        RedBg, RedAccent, RedText, "Red", $$"""
        <h1 style="color:{{RedAccent}}">About This Site</h1>
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
        """, true);

    // ── Shared layout ────────────────────────────────────────────────────

    private static string Layout(
        string title, string metaDescription,
        string bg, string accent, string text, string color,
        string bodyContent, bool isCrawler)
    {
        var robotsMeta = isCrawler
            ? """<meta name="robots" content="index, follow">"""
            : "";

        var jsonLd = isCrawler
            ? $$"""
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
            """
            : "";

        return $$"""
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1">
            <title>{{Encode(title)}}</title>
            <meta name="description" content="{{Encode(metaDescription)}}">
            {{robotsMeta}}
            {{jsonLd}}
            <style>
                * { margin: 0; padding: 0; box-sizing: border-box; }
                body {
                    font-family: system-ui, -apple-system, 'Segoe UI', Roboto, sans-serif;
                    background: {{bg}};
                    color: {{text}};
                    line-height: 1.7;
                    min-height: 100vh;
                    display: flex;
                    flex-direction: column;
                }
                nav {
                    background: {{accent}};
                    padding: 1rem 2rem;
                    display: flex;
                    gap: 1.5rem;
                    align-items: center;
                    flex-wrap: wrap;
                }
                nav a {
                    color: #fff;
                    text-decoration: none;
                    font-weight: 600;
                    font-size: 0.95rem;
                }
                nav a:hover { text-decoration: underline; }
                nav .brand {
                    font-size: 1.2rem;
                    margin-right: auto;
                }
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
                main {
                    max-width: 48rem;
                    margin: 2rem auto;
                    padding: 2rem;
                    flex: 1;
                }
                main h1 { margin-bottom: 1rem; font-size: 2rem; }
                main h2 { margin-top: 1.5rem; margin-bottom: 0.75rem; }
                main p { margin-bottom: 1rem; }
                main ul { margin: 0.5rem 0 1rem 1.5rem; }
                main li { margin-bottom: 0.4rem; }
                main a { color: {{accent}}; }
                footer {
                    background: {{accent}};
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
                <a href="/" class="brand">The World of {{color}}</a>
                <a href="/">Home</a>
                <a href="/articles/psychology">Psychology</a>
                <a href="/articles/in-nature">In Nature</a>
                <a href="/articles/history">History</a>
                <a href="/about">About</a>
                <span class="theme-badge">{{color}} Theme</span>
            </nav>
            <main>
                {{bodyContent}}
            </main>
            <footer>A site dedicated to the color {{color.ToLowerInvariant()}}.</footer>
        </body>
        </html>
        """;
    }

    private static string Encode(string value) =>
        System.Net.WebUtility.HtmlEncode(value);

    private static string EscapeJson(string value) =>
        value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
