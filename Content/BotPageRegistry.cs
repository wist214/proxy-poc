namespace DnsProxyPoc.Content;

public static class BotPageRegistry
{
    public const string SiteName = "BrightPixel";
    public const string SiteDescription = "Premium addressable LED pixel products, controllers, and accessories for lighting professionals and creative makers.";
    public const string DatePublished = "2024-06-15";
    public const string DateModified = "2026-03-15";
    public const string Accent = "#1565C0";
    public const string Bg = "#E8F0FE";
    public const string Text = "#1A237E";

    private static readonly BotPage[] Pages =
    [
        // ── Home ──────────────────────────────────────────────────────────────
        new(
            Path: "/",
            Title: "BrightPixel — Premium LED Pixel Products & Accessories",
            MetaDescription: "Shop addressable LED pixel strips, controllers, panels, and accessories. WS2812B, APA102, WS2811 — everything you need for professional pixel lighting.",
            FaqItems:
            [
                ("What is BrightPixel?",
                 "BrightPixel is a specialist retailer of addressable LED pixel products. We carry WS2812B, WS2811, APA102, and SK6812 LED strips, pixel nodes, matrix panels, controllers, power supplies, and all the connectors and accessories needed for professional and hobbyist LED pixel projects."),
                ("What LED pixel products do you sell?",
                 "We sell individually addressable LED strips (WS2812B, APA102, SK6812), pixel nodes (WS2811), LED matrix panels, pixel controllers (ESP32, Teensy, Falcon), power supplies rated for LED loads, and a full range of connectors, cables, and mounting accessories."),
                ("Do you ship internationally?",
                 "Yes. BrightPixel ships to over 50 countries. Standard shipping is available worldwide, with express options for North America, Europe, and Australia. All orders include tracking and are packed with ESD-safe materials to protect sensitive LED components.")
            ],
            BodyHtml: PageContent.HomePageBody(Accent),
            SitemapPriority: "1.0",
            SitemapChangeFreq: "weekly"
        ),

        // ── Products ──────────────────────────────────────────────────────────
        new(
            Path: "/products/ws2812b-led-strips",
            Title: "WS2812B Addressable RGB LED Pixel Strips — 30, 60, 144 LEDs/m",
            MetaDescription: "Buy WS2812B addressable RGB LED strips in 30, 60, and 144 LEDs per meter. 5V individually controllable pixels, IP30/IP65/IP67 options. Perfect for pixel art and ambient lighting.",
            FaqItems:
            [
                ("What is a WS2812B LED strip?",
                 "The WS2812B is an individually addressable RGB LED with an integrated WS2812B driver IC inside each LED package. Each pixel can display any of 16.7 million colors (24-bit color depth — 8 bits per R, G, B channel) and is controlled via a single-wire data protocol at 800 Kbps. It operates at 5V DC and draws approximately 60mA per pixel at full white brightness."),
                ("What densities are available for WS2812B strips?",
                 "We carry WS2812B strips in three densities: 30 LEDs/m (standard spacing, best for accent lighting and long runs), 60 LEDs/m (balanced density for most projects), and 144 LEDs/m (high density for pixel art displays and smooth color gradients). All densities come in 1m and 5m rolls."),
                ("Are WS2812B strips waterproof?",
                 "We offer three IP ratings: IP30 (bare PCB, indoor only), IP65 (silicone-coated top surface, splash-resistant), and IP67 (fully enclosed in silicone tube, suitable for outdoor and wet environments). For permanent outdoor installations, we recommend IP67 with additional channel mounting."),
                ("How many WS2812B pixels can I run from one data line?",
                 "Practically, a single data line can drive 300-500 WS2812B pixels reliably. Beyond 300 pixels, you should inject power every 150 pixels to prevent voltage drop and color shift. For very long runs (1000+ pixels), use a level shifter (3.3V to 5V) and consider the APA102 protocol for better signal integrity.")
            ],
            BodyHtml: PageContent.Ws2812bPageBody(Accent),
            SitemapPriority: "0.9",
            SitemapChangeFreq: "weekly"
        ),
        new(
            Path: "/products/ws2811-pixel-nodes",
            Title: "WS2811 RGB Pixel Nodes — Bullet & Square Modules for Signage",
            MetaDescription: "WS2811 RGB pixel nodes in 12V bullet and square form factors. IP68 waterproof, ideal for channel letters, building outlines, and festival decorations.",
            FaqItems:
            [
                ("What is a WS2811 pixel node?",
                 "A WS2811 pixel node is a standalone, individually addressable RGB LED module containing one or more LEDs driven by a WS2811 IC. Unlike strip-mounted pixels, nodes are discrete units connected by wire leads, making them ideal for installations where LEDs must be spaced irregularly — channel letter signs, building outlines, pixel trees, and decorative meshes."),
                ("What is the difference between WS2811 and WS2812B?",
                 "The WS2812B integrates the driver IC inside the LED package and operates at 5V. The WS2811 is an external driver IC paired with standard LEDs, typically operating at 12V. The 12V operation of WS2811 allows longer cable runs with less voltage drop, making it better suited for large-scale outdoor installations. Both use the same single-wire protocol."),
                ("Are WS2811 pixel nodes waterproof?",
                 "Yes. Our WS2811 pixel nodes are rated IP68 — fully waterproof and dustproof. Each node is potted in UV-stabilized epoxy resin, suitable for permanent outdoor installations including submersion. Wire connections use waterproof JST connectors.")
            ],
            BodyHtml: PageContent.Ws2811PageBody(Accent),
            SitemapPriority: "0.9",
            SitemapChangeFreq: "weekly"
        ),
        new(
            Path: "/products/apa102-led-strips",
            Title: "APA102 DotStar High-Speed Addressable LED Strips",
            MetaDescription: "APA102 (DotStar) high-speed SPI LED strips with 2-wire clock+data protocol. Superior PWM at 19.2 kHz, no flicker. 30/60/144 LEDs/m for POV and video applications.",
            FaqItems:
            [
                ("What makes APA102 better than WS2812B?",
                 "The APA102 uses a 2-wire SPI protocol (clock + data) instead of the WS2812B's single-wire protocol. This provides three key advantages: (1) Much higher data rates — up to 20 MHz clock vs 800 Kbps; (2) Global brightness control via a 5-bit (32-level) hardware dimmer per LED, separate from the 8-bit RGB channels; (3) 19.2 kHz PWM refresh rate that eliminates visible flicker, critical for POV (persistence of vision) displays and video applications."),
                ("What is the APA102 refresh rate?",
                 "The APA102 operates at 19.2 kHz PWM frequency — far above the ~400 Hz of WS2812B. This high refresh rate means absolutely no visible flicker, even when captured on camera. This makes APA102 the preferred choice for film/TV sets, POV displays, and any application where flicker-free operation is essential."),
                ("Can I mix APA102 and WS2812B in the same project?",
                 "Not on the same data line — they use different protocols (SPI vs single-wire). However, many controllers (ESP32, Teensy 4.x, Falcon F16V4) can drive both protocols simultaneously on separate output channels, letting you use APA102 for flicker-sensitive areas and WS2812B for longer runs in the same installation.")
            ],
            BodyHtml: PageContent.Apa102PageBody(Accent),
            SitemapPriority: "0.9",
            SitemapChangeFreq: "weekly"
        ),
        new(
            Path: "/products/pixel-controllers",
            Title: "LED Pixel Controllers — ESP32, Teensy, Falcon, WLED Compatible",
            MetaDescription: "LED pixel controllers for every scale. ESP32 WLED boards for hobbyists, Teensy 4.1 for artists, Falcon F48 for commercial shows. DMX, E1.31, Art-Net support.",
            FaqItems:
            [
                ("What is the best LED pixel controller for beginners?",
                 "For beginners, we recommend an ESP32-based controller running WLED firmware. WLED provides a full web-based UI for controlling up to 1500 pixels, with 100+ built-in effects, preset scheduling, sound reactivity, and integration with Home Assistant. No programming required — just flash the firmware, connect to Wi-Fi, and start designing."),
                ("What controller do I need for a large pixel installation?",
                 "For installations over 5,000 pixels, we recommend the Falcon F48 (up to 48 output ports, 100,000+ pixels) or the Falcon F16V4 (16 ports, 32,000 pixels). These professional controllers support E1.31 (sACN), Art-Net, and DDP protocols, have built-in Ethernet, and can run sequences from the onboard SD card without a computer."),
                ("What is WLED?",
                 "WLED is an open-source firmware for ESP8266 and ESP32 microcontrollers that turns them into powerful LED pixel controllers. It supports WS2812B, APA102, SK6812, and dozens of other LED protocols. Features include a web UI, 100+ effects, sound reactivity, DMX input, E1.31/Art-Net support, and Home Assistant integration."),
                ("What is E1.31 (sACN)?",
                 "E1.31, also known as sACN (streaming Architecture for Control Networks), is an Ethernet-based protocol for transmitting DMX512 data over IP networks. It supports up to 63,999 universes of 512 channels each, enabling control of millions of pixels from sequencing software like xLights, Vixen, or MadMapper.")
            ],
            BodyHtml: PageContent.ControllersPageBody(Accent),
            SitemapPriority: "0.9",
            SitemapChangeFreq: "weekly"
        ),
        new(
            Path: "/products/led-matrix-panels",
            Title: "LED Matrix Panels — P2.5, P3, P5, P10 RGB Pixel Displays",
            MetaDescription: "LED matrix panels in P2.5 to P10 pitches. HUB75 interface, 64x32 and 64x64 modules. Build video walls, scoreboards, and pixel art installations.",
            FaqItems:
            [
                ("What does P2.5, P3, P5, P10 mean for LED panels?",
                 "The P-number indicates the pixel pitch — the center-to-center distance between adjacent pixels in millimeters. P2.5 means 2.5mm pitch (high resolution, ideal for close viewing), P5 means 5mm pitch (medium resolution, good for 3-10m viewing distance), and P10 means 10mm pitch (large scale, best for outdoor signage viewed from a distance). Lower pitch = higher resolution = higher cost per square meter."),
                ("What is the HUB75 interface?",
                 "HUB75 is the standard interface for driving RGB LED matrix panels. It uses a 16-pin ribbon cable that carries row select lines (A, B, C, D, E), RGB data for two simultaneous rows, clock, latch, and output enable signals. To drive HUB75 panels with addressable pixel controllers, you need an adapter board (such as SmartMatrix or ESP32-HUB75-MatrixPanel-DMA)."),
                ("How many LED panels can I chain together?",
                 "Most HUB75 panels support daisy-chaining via output connectors. A single ESP32 with the HUB75 DMA driver library can reliably drive 8-12 panels (e.g., a 4x3 grid of 64x32 panels = 256x96 pixel display). For larger video walls, use dedicated receiver cards (such as Linsn RV908) that support hundreds of panels per card.")
            ],
            BodyHtml: PageContent.MatrixPanelsPageBody(Accent),
            SitemapPriority: "0.9",
            SitemapChangeFreq: "weekly"
        ),
        new(
            Path: "/products/power-supplies",
            Title: "LED Pixel Power Supplies — 5V 10A-60A & 12V Meanwell Units",
            MetaDescription: "Power supplies sized for LED pixels. 5V 10A to 60A for WS2812B strips, 12V for WS2811 nodes. Meanwell LRS and HLG series, UL/CE certified.",
            FaqItems:
            [
                ("How do I calculate the power supply size for LED pixels?",
                 "Each WS2812B pixel draws up to 60mA at full white (20mA per R, G, B channel). Multiply the pixel count by 0.06A to get the maximum current draw. Add a 20% safety margin. Example: 300 pixels × 0.06A = 18A × 1.2 = 21.6A — use a 5V 30A supply. In practice, most animations use 30-50% of maximum brightness, but always size the supply for worst-case."),
                ("What brand of power supply should I use?",
                 "We recommend Meanwell power supplies for all LED pixel projects. The LRS series (enclosed) offers excellent efficiency (up to 91%) and reliability in a compact form factor. For outdoor installations, the HLG series (IP67 rated) provides waterproof, constant-voltage output with built-in dimming support. All our Meanwell units carry UL, CE, and TUV certifications."),
                ("Do I need multiple power supplies for a large installation?",
                 "For installations over 1000 pixels, we recommend using multiple power supplies distributed throughout the installation rather than one massive unit. This reduces voltage drop over long cable runs and improves reliability. Connect all power supply grounds together but keep the positive rails separate to prevent ground loops.")
            ],
            BodyHtml: PageContent.PowerSuppliesPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/products/connectors-accessories",
            Title: "LED Pixel Connectors, Cables & Mounting Accessories",
            MetaDescription: "JST-SM, JST-XH, and 3-pin pixel connectors. Silicone mounting clips, aluminum channels, T-connectors, extension cables, and amplifiers for LED pixel strips.",
            FaqItems:
            [
                ("What connectors do WS2812B strips use?",
                 "WS2812B strips typically use 3-pin JST-SM connectors (data, 5V, ground). Some strips use bare solder pads instead. We stock pre-wired JST-SM pigtails, solderable connectors, and solderless snap connectors that clip directly onto cut strip ends — no soldering required."),
                ("What is a pixel signal amplifier?",
                 "A signal amplifier (also called a repeater or level shifter) regenerates the WS2812B data signal for long cable runs between controller and strip. After about 5 meters of cable, signal degradation can cause flickering or color errors. An amplifier placed at the strip input restores clean 5V logic levels, enabling reliable data transmission over 20m+ cable runs."),
                ("What aluminum channel should I use for LED strips?",
                 "We carry U-channel (surface mount), V-channel (corner mount at 45°), and recessed channel (flush with surface) profiles. All include frosted diffuser covers that blend individual pixel dots into smooth light bands. Standard lengths are 1m and 2m, with end caps and mounting clips included.")
            ],
            BodyHtml: PageContent.ConnectorsPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/products/outdoor-waterproof",
            Title: "IP67/IP68 Waterproof Outdoor LED Pixel Lights",
            MetaDescription: "Weatherproof outdoor LED pixels rated IP67 and IP68. UV-stabilized silicone encapsulation, stainless steel mounting, rated for -40°C to 60°C operation.",
            FaqItems:
            [
                ("What IP rating do I need for outdoor LED pixels?",
                 "IP65 withstands rain and splashing (silicone-coated top). IP67 survives temporary submersion to 1m for 30 minutes (fully enclosed in silicone tube). IP68 handles continuous submersion — ideal for fountains and underwater features. For most outdoor building installations, IP67 is sufficient. For ground-level or water features, choose IP68."),
                ("Can LED pixels be used in freezing temperatures?",
                 "Yes. Our outdoor-rated pixels operate reliably from -40°C to 60°C. The LEDs themselves generate minimal heat and are unaffected by cold. However, power supplies should be housed in weatherproof enclosures, and all connections should use waterproof connectors or be sealed with heat-shrink tubing and silicone adhesive."),
                ("How long do outdoor LED pixels last?",
                 "Quality outdoor LED pixels with proper UV-stabilized encapsulation typically last 50,000 hours (approximately 11 years at 12 hours per day). The main failure modes are UV degradation of the silicone housing and moisture ingress at connection points. Using our UV-stabilized IP67/IP68 products with sealed connections maximizes lifespan.")
            ],
            BodyHtml: PageContent.OutdoorPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/products/neon-flex",
            Title: "LED Neon Flex Pixel Strips — Addressable RGB Neon Rope Light",
            MetaDescription: "Addressable LED neon flex strips with smooth, dot-free illumination. WS2812B-compatible pixel neon in silicone housing. Bendable to 40mm radius for signage and architecture.",
            FaqItems:
            [
                ("What is LED neon flex?",
                 "LED neon flex is an addressable LED strip encased in a specially shaped silicone extrusion that diffuses the light from individual pixels into a smooth, continuous glow — mimicking the look of traditional glass neon tubes. Unlike neon, LED neon flex is shatterproof, runs on low voltage (5V or 12V DC), bends easily, and each segment can display any color independently."),
                ("What is the minimum bend radius?",
                 "Our pixel neon flex bends to a 40mm radius for horizontal bends and 100mm for vertical bends without damaging the LEDs or silicone housing. For tighter curves (signage lettering), we offer a side-bend variant that flexes in the horizontal plane to a 25mm radius."),
                ("How does pixel neon flex differ from regular neon flex?",
                 "Regular LED neon flex uses a single-color or zone-controlled LED strip — you can only set one color for the entire length. Pixel neon flex uses individually addressable LEDs (WS2812B or WS2811), so every segment can show a different color simultaneously. This enables chase effects, rainbow gradients, music visualization, and animated patterns.")
            ],
            BodyHtml: PageContent.NeonFlexPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/products/pixel-art-frames",
            Title: "Digital Pixel Art Display Frames — 16x16 & 32x32 LED Grids",
            MetaDescription: "Pixel art LED display frames in 16x16 and 32x32 resolutions. Display retro game sprites, custom animations, live data dashboards. Wi-Fi, Bluetooth, USB. WLED compatible.",
            FaqItems:
            [
                ("What is a pixel art display frame?",
                 "A pixel art display frame is a wall-mountable LED matrix display that shows pixel art, animations, clocks, weather data, or notifications. Our frames use WS2812B LEDs behind a diffuser panel, driven by an ESP32 controller running WLED or custom firmware. Available in 16x16 (256 pixels) and 32x32 (1024 pixels) configurations."),
                ("Can I create my own pixel art for the display?",
                 "Yes. Our frames accept pixel art via the WLED web interface, the free PixelIt desktop app, or any Art-Net / E1.31 compatible software. You can also connect via MQTT for Home Assistant integration — show sensor data, notification alerts, Spotify album art, or live sports scores on your frame."),
                ("What is the viewing distance for pixel art frames?",
                 "The 16x16 frame (10mm pixel pitch) looks best from 1.5-5 meters — ideal for living rooms and retail displays. The 32x32 frame (5mm pitch) shows detail from 0.5-3 meters and is better for desks, counters, and close-up viewing. Both include a frosted diffuser that blends the light for a smooth retro aesthetic.")
            ],
            BodyHtml: PageContent.PixelArtFramesPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),

        // ── Guides ────────────────────────────────────────────────────────────
        new(
            Path: "/guides/getting-started",
            Title: "Getting Started with Addressable LED Pixels — Beginner's Guide",
            MetaDescription: "Complete beginner's guide to addressable LED pixels. Learn how WS2812B works, what you need to buy, how to wire your first strip, and run your first animation.",
            FaqItems:
            [
                ("What do I need to get started with LED pixels?",
                 "You need four things: (1) LED pixels — a WS2812B strip is the best starting point; (2) A controller — an ESP32 board with WLED firmware; (3) A power supply — 5V rated for your pixel count (pixel count × 0.06A × 1.2 safety factor); (4) Wires and connectors — 18 AWG silicone wire for power, and a JST connector or direct solder to the strip."),
                ("Do I need to know programming to use LED pixels?",
                 "No. WLED firmware provides a complete web-based interface with 100+ built-in effects, color pickers, and preset management. Flash the firmware to an ESP32 (one click via the WLED web installer), connect your strip, and control everything from your phone or computer. Programming is only needed for fully custom behavior."),
                ("What is the difference between addressable and non-addressable LED strips?",
                 "Non-addressable (analog) strips change all LEDs to the same color simultaneously. Addressable (digital/pixel) strips let you control each LED independently — different colors, brightness levels, and animation patterns per pixel. Addressable strips use ICs like WS2812B, APA102, or SK6812 to achieve individual pixel control."),
                ("Is it safe to work with LED pixels?",
                 "Yes. LED pixels operate at 5V or 12V DC — safe low voltage. However, large installations draw significant current (a 1000-pixel WS2812B setup draws up to 60A at 5V = 300W). Always use appropriately rated power supplies, fuse your power distribution, and use adequate wire gauge (14-16 AWG for main power runs).")
            ],
            BodyHtml: PageContent.GettingStartedPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/guides/choosing-pixels",
            Title: "How to Choose the Right LED Pixels for Your Project",
            MetaDescription: "Decision guide comparing WS2812B, WS2811, APA102, SK6812 pixels. Covers voltage, density, protocol speed, IP rating, and best use case for each LED type.",
            FaqItems:
            [
                ("Should I use WS2812B or APA102?",
                 "Use WS2812B for most projects — it's cheaper, widely supported, and sufficient for ambient lighting, accent strips, and decorations. Choose APA102 when you need flicker-free operation (video/film sets), very fast refresh rates (POV displays), or precise global brightness control. APA102 costs 2-3× more than WS2812B."),
                ("What LED density should I choose?",
                 "30 LEDs/m — accent lighting, architectural outlines, and long runs (lowest cost per meter). 60 LEDs/m — the most versatile density for general use, room lighting, and decorative effects. 144 LEDs/m — pixel art displays, video panels, and applications requiring smooth gradients with no visible gaps between pixels."),
                ("Should I use 5V or 12V pixels?",
                 "5V pixels (WS2812B, APA102, SK6812) offer the widest selection and lowest cost. 12V pixels (WS2811, GS8208) allow longer cable runs with less voltage drop — ideal for outdoor and large-scale installations. If your total cable run from power supply to the farthest pixel exceeds 5 meters, consider 12V or plan for power injection points."),
                ("What is SK6812 and when should I use it?",
                 "The SK6812 is a WS2812B-compatible LED available in RGBW (RGB + dedicated white channel). The dedicated white LED produces a cleaner, more efficient white than mixing RGB. Choose SK6812 RGBW when your project needs both colorful effects and high-quality white illumination — under-cabinet lighting, task lighting combined with ambient color.")
            ],
            BodyHtml: PageContent.ChoosingPixelsPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/guides/power-calculation",
            Title: "LED Pixel Power Supply Calculator & Sizing Guide",
            MetaDescription: "Calculate exact power supply requirements for WS2812B, APA102, and WS2811 LED pixel projects. Formulas, injection points, wire gauge charts, and real-world examples.",
            FaqItems:
            [
                ("How much power does a single WS2812B pixel use?",
                 "A single WS2812B pixel draws up to 60mA at 5V when displaying full white (all three channels at maximum brightness). That's 0.3W per pixel. At typical animation brightness (30-50%), draw drops to 18-30mA. For power supply sizing, always calculate based on 60mA maximum to ensure headroom."),
                ("How do I calculate the total power for my LED project?",
                 "Use this formula: Total Amps = (Pixel Count × 0.06A) × 1.2 safety margin. Total Watts = Total Amps × Voltage. Example: 500 WS2812B pixels → 500 × 0.06 = 30A × 1.2 = 36A. Power = 36A × 5V = 180W. Choose a 5V 40A (200W) power supply. For 12V WS2811: 500 × 0.02A × 1.2 = 12A → 12V 15A (180W) supply."),
                ("What wire gauge do I need for LED pixels?",
                 "For main power runs: 14 AWG (up to 30A), 16 AWG (up to 22A), 18 AWG (up to 16A). For branch connections: 20-22 AWG (up to 7A). Use silicone-insulated wire for flexibility and heat resistance. Keep power runs as short as possible and use multiple injection points for long strips."),
                ("What is power injection and when do I need it?",
                 "Power injection means adding additional power feed points along a long LED strip instead of powering from one end only. Without injection, voltage drops along the strip cause LEDs at the far end to appear dimmer and shift toward red/yellow. Inject power every 150 pixels (2.5m at 60 LED/m) for WS2812B, or every 300 pixels for 12V WS2811.")
            ],
            BodyHtml: PageContent.PowerCalculationPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/guides/installation",
            Title: "LED Pixel Installation Guide — Mounting, Wiring & Weatherproofing",
            MetaDescription: "Step-by-step LED pixel installation guide. Surface mounting, aluminum channels, outdoor weatherproofing, cable management, and power distribution best practices.",
            FaqItems:
            [
                ("How do I mount LED strips to a surface?",
                 "For indoor use: most strips have 3M VHB adhesive backing — clean the surface with isopropyl alcohol and press firmly. For permanent or heavy strips, use aluminum channels with mounting clips. For outdoor use: use stainless steel mounting clips screwed into the surface, plus waterproof silicone at all connection points."),
                ("Can I cut addressable LED strips?",
                 "Yes. WS2812B strips can be cut between any two pixels at the marked cut lines (copper pads visible between LEDs). After cutting, solder wires or use snap connectors to reconnect. Each cut segment works independently with its own data input. Never cut through an LED — always use the marked cut points."),
                ("How do I weatherproof outdoor LED pixel connections?",
                 "Use IP67-rated waterproof connectors where possible. For soldered joints, apply adhesive-lined heat-shrink tubing and seal with a layer of silicone conformal coating. For junction boxes, use IP65-rated enclosures with cable glands. Test all seals before final installation by spraying with water and checking for moisture ingress.")
            ],
            BodyHtml: PageContent.InstallationPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/guides/programming",
            Title: "Programming LED Pixels — Arduino, ESP32, FastLED & WLED Tutorial",
            MetaDescription: "Learn to program addressable LED pixels with Arduino IDE and ESP32. FastLED library tutorial, WLED firmware guide, custom animations, sound reactivity, and DMX control.",
            FaqItems:
            [
                ("What is the best library for programming LED pixels?",
                 "FastLED is the most popular Arduino library for addressable LEDs. It supports WS2812B, APA102, SK6812, and 50+ other chipsets. FastLED provides HSV color space, palette-based animation, temporal dithering, and power management. For Python (Raspberry Pi), the NeoPixel library from Adafruit or the rpi-ws281x library are standard choices."),
                ("How do I make LED pixels react to music?",
                 "For no-code sound reactivity, use WLED with the AudioReactive usermod — it uses the ESP32's built-in ADC to sample a microphone (INMP441 I2S or MAX4466 analog). For custom solutions, use an MSGEQ7 7-band spectrum analyzer IC with FastLED to map frequency bands to LED segments. Both approaches achieve real-time beat detection and frequency visualization."),
                ("Can I control LED pixels from a web browser?",
                 "Yes. WLED exposes a REST API and WebSocket interface for real-time control from any web browser. You can also use the WLED app (iOS/Android), integrate with Home Assistant via MQTT or native WLED integration, or use Art-Net/E1.31/DDP protocols from professional lighting software like xLights, Resolume, or MadMapper."),
                ("What is the FastLED rainbow effect code?",
                 "A basic FastLED rainbow uses fill_rainbow(leds, NUM_LEDS, hue++, 7) in the main loop, where hue is a uint8_t that increments each frame — the automatic overflow creates continuous cycling. Call FastLED.show() after filling the array. Add FastLED.delay(20) for smooth animation at 50fps. This five-line sketch is the classic starting point for pixel programming.")
            ],
            BodyHtml: PageContent.ProgrammingPageBody(Accent),
            SitemapPriority: "0.8",
            SitemapChangeFreq: "monthly"
        ),

        // ── Learn ─────────────────────────────────────────────────────────────
        new(
            Path: "/learn/pixel-technology",
            Title: "Understanding Addressable LED Pixel Technology — How Pixels Work",
            MetaDescription: "Deep dive into how addressable LED pixels work. IC architecture, PWM dimming, signal propagation, refresh rates, and the engineering behind WS2812B and APA102 LEDs.",
            FaqItems:
            [
                ("How does an addressable LED pixel work?",
                 "Each addressable pixel contains an RGB LED and a tiny integrated circuit (IC) that receives serial data, extracts its own color value, and passes the remaining data to the next pixel in the chain. The IC generates PWM signals to drive each R, G, B channel at the specified brightness level. This cascading architecture means you only need one data wire from the controller, regardless of how many pixels are connected."),
                ("What is PWM dimming in LED pixels?",
                 "PWM (Pulse Width Modulation) rapidly switches the LED on and off at a fixed frequency. The ratio of on-time to off-time (duty cycle) determines perceived brightness. WS2812B uses ~400 Hz PWM — visible as flicker in high-speed photography. APA102 uses 19.2 kHz — completely flicker-free. Each channel (R, G, B) has 8-bit resolution (256 levels), yielding 16.7 million color combinations."),
                ("What limits the number of pixels on a single data line?",
                 "Three factors: (1) Signal integrity — each pixel reshapes the signal, but noise accumulates over hundreds of pixels; (2) Refresh rate — with 30μs per pixel (WS2812B), 1000 pixels take 30ms per frame = 33fps maximum; (3) Voltage drop — resistance in the strip PCB traces causes progressive voltage drop. Practical limit: 300-500 for WS2812B, 1000+ for APA102 (clock signal maintains timing).")
            ],
            BodyHtml: PageContent.PixelTechnologyPageBody(Accent),
            SitemapPriority: "0.7",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/learn/protocols",
            Title: "LED Communication Protocols — WS2812B vs APA102 vs DMX512 vs E1.31",
            MetaDescription: "Complete comparison of LED pixel protocols: WS2812B single-wire, APA102 SPI, SK6812 RGBW, DMX512, E1.31 sACN, Art-Net, and DDP. Speed, capacity, and use cases.",
            FaqItems:
            [
                ("What protocol does WS2812B use?",
                 "WS2812B uses a proprietary single-wire NRZ (Non-Return-to-Zero) protocol at 800 Kbps. Each bit is encoded as a precisely timed high/low pulse: a '1' bit is 0.7μs high + 0.6μs low, a '0' bit is 0.35μs high + 0.8μs low. Timing tolerance is ±150ns. A reset signal (>50μs low) triggers all pixels to latch their received data simultaneously."),
                ("What is DMX512 and how does it work with pixels?",
                 "DMX512 is a professional lighting control standard that transmits 512 channels per universe via RS-485 serial (250 Kbaud). Each pixel uses 3 channels (RGB), so one DMX universe controls 170 pixels. For larger installations, E1.31 (sACN) transmits DMX over Ethernet with up to 63,999 universes — enough for millions of pixels. DMX-to-pixel decoders bridge traditional DMX controllers to addressable strips."),
                ("What is the DDP protocol?",
                 "DDP (Distributed Display Protocol) is a modern, efficient protocol designed specifically for LED pixels. Unlike E1.31 which is limited to 512 channels per universe, DDP sends arbitrary-length packets — no universe splitting required. This reduces overhead and simplifies configuration. WLED and many modern controllers support DDP natively."),
                ("Which protocol should I use for my project?",
                 "Hobby/home use: WS2812B protocol with WLED controller (simplest setup). Medium installations (1000-10,000 pixels): E1.31 with xLights sequencing software. Large commercial displays (10,000+ pixels): E1.31 or Art-Net with Falcon/AlphaPix controllers. Film/video: APA102 (flicker-free). DJ/stage: DMX512 or Art-Net for compatibility with existing lighting rigs.")
            ],
            BodyHtml: PageContent.ProtocolsPageBody(Accent),
            SitemapPriority: "0.7",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/learn/color-mixing",
            Title: "RGB Color Mixing & Color Spaces for LED Pixel Displays",
            MetaDescription: "How RGB additive color mixing works in LED pixels. Understand HSV/HSL color spaces, color temperature, gamma correction, and CRI for pixel lighting applications.",
            FaqItems:
            [
                ("How does RGB color mixing work in LED pixels?",
                 "LED pixels use additive color mixing — each pixel contains separate Red, Green, and Blue LEDs. When all three shine at full brightness, you see white. Red + Green = Yellow. Red + Blue = Magenta. Green + Blue = Cyan. Each channel has 256 brightness levels (8-bit), yielding 256³ = 16,777,216 possible colors per pixel."),
                ("What is HSV color space and why is it better for LED animation?",
                 "HSV (Hue, Saturation, Value) maps color to a cylinder where Hue is the color angle (0°=Red, 120°=Green, 240°=Blue), Saturation is the color purity (0=gray, 255=vivid), and Value is brightness (0=off, 255=full). HSV makes animation intuitive: incrementing Hue creates smooth rainbow cycles, reducing Saturation creates pastel fades, and adjusting Value handles dimming — all without complex RGB math."),
                ("What is gamma correction and do I need it?",
                 "Gamma correction compensates for the non-linear relationship between PWM duty cycle and perceived brightness. Without correction, a value of 128 (50% duty cycle) appears much brighter than 50% perceived brightness. Applying a gamma curve (typically γ=2.2) makes brightness transitions look smooth and natural. FastLED and WLED both include gamma correction options."),
                ("What is CRI and does it matter for LED pixels?",
                 "CRI (Color Rendering Index) measures how accurately a light source renders colors compared to sunlight (CRI 100). Standard RGB pixel LEDs have a CRI of 20-40 — poor for illumination but fine for decorative effects. SK6812 RGBW pixels with a dedicated warm white LED achieve CRI 80+, making them suitable for task lighting where color accuracy matters.")
            ],
            BodyHtml: PageContent.ColorMixingPageBody(Accent),
            SitemapPriority: "0.7",
            SitemapChangeFreq: "monthly"
        ),

        // ── Resources ─────────────────────────────────────────────────────────
        new(
            Path: "/resources",
            Title: "LED Pixel Tools, Software & Resources",
            MetaDescription: "Curated list of LED pixel tools and software: WLED, xLights, FastLED, power calculators, wiring diagrams, and community forums for addressable LED projects.",
            FaqItems:
            [
                ("What software do I need for LED pixel projects?",
                 "For simple control: WLED firmware (free, web-based, 100+ effects). For sequenced shows: xLights (free, open-source, professional show sequencer). For programming: Arduino IDE with FastLED library. For professional shows: Resolume Arena, MadMapper, or Lightjams. For Home Assistant integration: WLED native integration or MQTT."),
                ("Where can I find LED pixel project tutorials?",
                 "Our guides section covers all fundamentals. For community projects, the WLED Discord (20,000+ members), r/addressableLEDs on Reddit, and the xLights Facebook group are the most active communities. The FastLED documentation on GitHub and the Adafruit NeoPixel Überguide are excellent technical references."),
                ("Are there mobile apps for controlling LED pixels?",
                 "Yes. WLED has official apps for iOS and Android with full effect control, color picking, and preset management. LedFx provides real-time music visualization. Jinx! works for matrix panels. For professional control, Luminair and TouchOSC offer DMX/Art-Net control from tablets.")
            ],
            BodyHtml: PageContent.ResourcesPageBody(Accent),
            SitemapPriority: "0.7",
            SitemapChangeFreq: "monthly"
        ),
        new(
            Path: "/about",
            Title: "About BrightPixel — LED Pixel Specialists Since 2019",
            MetaDescription: "BrightPixel is a specialist LED pixel retailer serving lighting professionals, creative makers, and hobbyists worldwide since 2019. Learn about our mission and team.",
            FaqItems:
            [
                ("Who is behind BrightPixel?",
                 "BrightPixel was founded in 2019 by a team of lighting designers and electronics engineers who were frustrated by the difficulty of sourcing quality LED pixel components. We test every product we sell, write honest specifications, and provide the technical support that generic LED resellers can't match."),
                ("Do you offer technical support?",
                 "Yes. Every order includes free email technical support for wiring, configuration, and troubleshooting. We also offer paid consultation for large commercial installations — our engineers can review your designs, specify components, and provide on-site commissioning support."),
                ("Do you offer wholesale pricing?",
                 "Yes. We offer tiered wholesale pricing for orders above $500. Contact our sales team for a custom quote. We supply lighting designers, AV integrators, event production companies, and retail display specialists across North America and Europe.")
            ],
            BodyHtml: PageContent.AboutPageBody(Accent),
            SitemapPriority: "0.5",
            SitemapChangeFreq: "monthly"
        )
    ];

    public static IReadOnlyList<BotPage> AllPages => Pages;

    public static BotPage? GetPage(string path)
    {
        if (path is "" or "/") path = "/";
        return Pages.FirstOrDefault(p => p.Path == path);
    }
}
