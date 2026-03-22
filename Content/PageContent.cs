namespace DnsProxyPoc.Content;

public static class PageContent
{
    public static string HomePageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">BrightPixel — Premium LED Pixel Products</h1>
<p>
    Welcome to BrightPixel, your specialist source for addressable LED pixel products. We carry
    the full range of individually controllable LED strips, pixel nodes, matrix panels, controllers,
    power supplies, and accessories — everything you need to bring your pixel lighting vision to life.
</p>
<p>
    Whether you are building your first WS2812B desk lamp, designing a professional architectural
    installation, or sequencing a 100,000-pixel holiday light show, BrightPixel has the components,
    the knowledge, and the technical support to make it happen.
</p>
<h2 style="color:{{accent}}">Our Products</h2>
<div style="display:grid; gap:1rem; margin-top:1rem;">
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/ws2812b-led-strips" style="color:{{accent}}">WS2812B LED Strips</a></strong>
        <p style="margin:0.25rem 0 0">Individually addressable RGB strips in 30, 60, and 144 LEDs/m — the most popular pixel LED</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/ws2811-pixel-nodes" style="color:{{accent}}">WS2811 Pixel Nodes</a></strong>
        <p style="margin:0.25rem 0 0">12V waterproof bullet and square modules for signage, building outlines, and pixel trees</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/apa102-led-strips" style="color:{{accent}}">APA102 DotStar Strips</a></strong>
        <p style="margin:0.25rem 0 0">High-speed SPI LED strips with 19.2 kHz flicker-free PWM for video and POV applications</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/pixel-controllers" style="color:{{accent}}">Pixel Controllers</a></strong>
        <p style="margin:0.25rem 0 0">ESP32 WLED boards, Teensy 4.1, Falcon F48 — controllers for every scale</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/led-matrix-panels" style="color:{{accent}}">LED Matrix Panels</a></strong>
        <p style="margin:0.25rem 0 0">HUB75 RGB panels from P2.5 to P10 pitch for video walls and scoreboards</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/power-supplies" style="color:{{accent}}">Power Supplies</a></strong>
        <p style="margin:0.25rem 0 0">Meanwell 5V &amp; 12V units properly sized for LED pixel loads</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/neon-flex" style="color:{{accent}}">LED Neon Flex</a></strong>
        <p style="margin:0.25rem 0 0">Addressable pixel neon rope light with smooth dot-free illumination</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/pixel-art-frames" style="color:{{accent}}">Pixel Art Frames</a></strong>
        <p style="margin:0.25rem 0 0">16x16 and 32x32 wall-mountable LED displays for retro art and dashboards</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/outdoor-waterproof" style="color:{{accent}}">Outdoor Waterproof</a></strong>
        <p style="margin:0.25rem 0 0">IP67/IP68 weatherproof pixels rated for -40°C to 60°C permanent installations</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/products/connectors-accessories" style="color:{{accent}}">Connectors &amp; Accessories</a></strong>
        <p style="margin:0.25rem 0 0">JST connectors, aluminum channels, signal amplifiers, and mounting hardware</p>
    </div>
</div>
<h2 style="color:{{accent}}">Guides &amp; Learning</h2>
<div style="display:grid; gap:1rem; margin-top:1rem;">
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/guides/getting-started" style="color:{{accent}}">Getting Started Guide</a></strong>
        <p style="margin:0.25rem 0 0">Everything you need for your first addressable LED project</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/guides/choosing-pixels" style="color:{{accent}}">How to Choose Pixels</a></strong>
        <p style="margin:0.25rem 0 0">WS2812B vs APA102 vs WS2811 vs SK6812 — find the right LED for your project</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/guides/power-calculation" style="color:{{accent}}">Power Calculator Guide</a></strong>
        <p style="margin:0.25rem 0 0">Size your power supply correctly with our formulas and wire gauge charts</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/guides/installation" style="color:{{accent}}">Installation Guide</a></strong>
        <p style="margin:0.25rem 0 0">Mounting, wiring, weatherproofing, and cable management best practices</p>
    </div>
    <div style="border-left:4px solid {{accent}}; padding-left:1rem;">
        <strong><a href="/guides/programming" style="color:{{accent}}">Programming Tutorial</a></strong>
        <p style="margin:0.25rem 0 0">Arduino, ESP32, FastLED, WLED — code your first animation</p>
    </div>
</div>
</article>
""";

    public static string Ws2812bPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">WS2812B Addressable RGB LED Strips</h1>
<p>
    The WS2812B is the world's most popular addressable LED pixel. Each tiny 5050-package LED
    contains a built-in WS2812B driver IC that receives 24-bit color data (8 bits per channel)
    via a single-wire protocol at 800 Kbps. This means you can control thousands of pixels
    with just one data pin on your microcontroller.
</p>
<p>
    Our WS2812B strips come on flexible PCBs in three densities: 30 LEDs/m for accent lighting
    and architectural outlines, 60 LEDs/m for balanced general-purpose use, and 144 LEDs/m for
    pixel art displays and smooth high-resolution effects. All strips are available in 1m and
    5m rolls, with IP30 (indoor), IP65 (splash-proof), and IP67 (fully waterproof) options.
</p>
<h2 style="color:{{accent}}">Specifications</h2>
<ul>
    <li><strong>LED type:</strong> WS2812B (5050 RGB with integrated IC)</li>
    <li><strong>Voltage:</strong> 5V DC</li>
    <li><strong>Color depth:</strong> 24-bit (16.7 million colors)</li>
    <li><strong>Protocol:</strong> Single-wire NRZ at 800 Kbps</li>
    <li><strong>Current per pixel:</strong> 60mA max (full white), ~20mA typical animation</li>
    <li><strong>Densities:</strong> 30, 60, 144 LEDs per meter</li>
    <li><strong>IP ratings:</strong> IP30, IP65, IP67</li>
    <li><strong>PCB width:</strong> 10mm (30/60 LED/m), 12mm (144 LED/m)</li>
    <li><strong>Operating temperature:</strong> -25°C to 80°C</li>
    <li><strong>Lifespan:</strong> 50,000+ hours</li>
</ul>
<h2 style="color:{{accent}}">Density Comparison</h2>
<p>
    <strong>30 LEDs/m</strong> — 33mm pixel spacing. Best for cove lighting, staircase outlines,
    and long runs where pixel density is less important. Lowest cost per meter with maximum
    cable run length due to reduced current draw (1.8A per meter max).
</p>
<p>
    <strong>60 LEDs/m</strong> — 16.7mm pixel spacing. The most versatile option. Individual
    pixels are barely visible behind a diffuser, making it ideal for under-cabinet lighting,
    desk setups, TV backlighting, and general decorative effects. Draws 3.6A per meter max.
</p>
<p>
    <strong>144 LEDs/m</strong> — 6.9mm pixel spacing. Pixels blend together even without a
    diffuser, creating smooth gradients and detailed pixel art. Essential for LED matrix displays,
    POV (persistence of vision) projects, and any application requiring high-resolution output.
    Draws 8.6A per meter max — power injection recommended every 0.5m.
</p>
<h2 style="color:{{accent}}">Wiring Guide</h2>
<p>
    WS2812B strips have three connections: <strong>5V</strong> (red wire), <strong>GND</strong>
    (white or black wire), and <strong>DATA</strong> (green wire). Connect DATA to your
    controller's output pin. Add a 300-470Ω resistor in series with the data line close to the
    first pixel to prevent signal reflections. Place a 1000μF electrolytic capacitor across 5V
    and GND at the power injection point to absorb power-on surges.
</p>
</article>
""";

    public static string Ws2811PageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">WS2811 RGB Pixel Nodes</h1>
<p>
    WS2811 pixel nodes are individually addressable LED modules designed for installations
    where LEDs need to be distributed freely rather than arranged in a linear strip. Each node
    contains a WS2811 driver IC and one or three RGB LEDs encased in a waterproof IP68 housing.
    Operating at 12V DC, WS2811 nodes support much longer cable runs than 5V strip pixels.
</p>
<p>
    Our nodes come in two form factors: <strong>bullet nodes</strong> (9mm or 12mm diameter,
    designed to push through drilled holes in channel letters and sign faces) and
    <strong>square modules</strong> (40mm×40mm with screw mounting holes for grid layouts
    on building facades and seasonal displays).
</p>
<h2 style="color:{{accent}}">Specifications</h2>
<ul>
    <li><strong>IC:</strong> WS2811 (external driver, 1 or 3 LEDs per IC)</li>
    <li><strong>Voltage:</strong> 12V DC</li>
    <li><strong>Current:</strong> 20mA per node (single LED) / 60mA (3-LED module)</li>
    <li><strong>Protocol:</strong> WS2811 single-wire NRZ, 800 Kbps</li>
    <li><strong>IP rating:</strong> IP68 (waterproof, UV-stabilized epoxy)</li>
    <li><strong>Wire:</strong> 18AWG, 10cm or 15cm lead spacing</li>
    <li><strong>Connector:</strong> JST waterproof male/female pigtails</li>
    <li><strong>Operating temperature:</strong> -40°C to 60°C</li>
    <li><strong>Strings:</strong> Available in 50-count and 100-count strings</li>
</ul>
<h2 style="color:{{accent}}">Applications</h2>
<p>
    <strong>Channel letter signs:</strong> Bullet nodes pushed through 12mm holes in aluminum
    or acrylic sign faces provide individually controllable pixel lighting for storefronts.
    <strong>Building outlines:</strong> Square modules mounted along rooflines, window frames,
    and architectural features. <strong>Holiday displays:</strong> Pixel trees, mega-trees,
    and custom props where each node's position is mapped in xLights sequencing software.
    <strong>Pixel meshes:</strong> Nodes on flexible grid backing create large-format video
    displays at a fraction of the cost of matrix panels.
</p>
</article>
""";

    public static string Apa102PageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">APA102 DotStar High-Speed LED Strips</h1>
<p>
    The APA102 (marketed by Adafruit as DotStar) is the professional's choice for addressable
    LEDs where speed and flicker-free operation are critical. Unlike the WS2812B single-wire
    protocol, APA102 uses standard SPI (Serial Peripheral Interface) with separate clock and
    data lines, enabling data rates up to 20 MHz — over 25× faster than WS2812B.
</p>
<p>
    Each APA102 pixel features 24-bit RGB color (8 bits per channel) plus a 5-bit global
    brightness register (32 levels) that operates at 19.2 kHz PWM. This ultra-high refresh
    rate produces absolutely zero visible flicker — essential for film/TV production,
    persistence-of-vision displays, and any application captured on camera.
</p>
<h2 style="color:{{accent}}">Specifications</h2>
<ul>
    <li><strong>LED type:</strong> APA102C (5050 RGB with SPI driver IC)</li>
    <li><strong>Voltage:</strong> 5V DC</li>
    <li><strong>Protocol:</strong> SPI (2-wire: clock + data), up to 20 MHz</li>
    <li><strong>Color depth:</strong> 24-bit RGB + 5-bit global brightness</li>
    <li><strong>PWM frequency:</strong> 19.2 kHz (flicker-free)</li>
    <li><strong>Current per pixel:</strong> 60mA max</li>
    <li><strong>Densities:</strong> 30, 60, 144 LEDs per meter</li>
    <li><strong>IP ratings:</strong> IP30, IP65, IP67</li>
</ul>
<h2 style="color:{{accent}}">When to Choose APA102 Over WS2812B</h2>
<p>
    Choose APA102 when: filming LED displays (zero flicker on camera), building POV props
    (fast data rate keeps up with rotation speed), needing precise low-brightness dimming
    (5-bit global dimmer avoids PWM stepping artifacts at low levels), or driving very long
    chains (SPI clock signal prevents timing drift). For all other applications, the lower-cost
    WS2812B is typically sufficient.
</p>
</article>
""";

    public static string ControllersPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Pixel Controllers</h1>
<p>
    A pixel controller is the brain of any addressable LED installation. It receives animation
    data — from built-in effects, sequencing software, or streaming protocols — and translates
    it into the precisely timed signal pulses that drive each pixel. We carry controllers for
    every project scale, from a single ESP32 board driving 300 pixels to a Falcon F48
    powering 100,000+ pixels across a commercial display.
</p>
<h2 style="color:{{accent}}">ESP32 WLED Controllers</h2>
<p>
    Our ESP32 WLED boards come pre-flashed with WLED firmware and include level-shifted outputs,
    screw terminals for easy wiring, and a USB-C port for power and programming. WLED provides
    a browser-based UI with 100+ effects, sound reactivity, preset scheduling, and integration
    with Home Assistant, Alexa, and Google Home. Ideal for 1-1500 pixels.
</p>
<h2 style="color:{{accent}}">Teensy 4.1 Controllers</h2>
<p>
    The Teensy 4.1 runs at 600 MHz with hardware DMA output for up to 32 parallel LED channels.
    Combined with the OctoWS2811 or FastLED library, a single Teensy can drive 10,000+ pixels
    at high frame rates. Preferred by LED artists and interactive installation designers who
    need custom firmware and low-latency real-time control.
</p>
<h2 style="color:{{accent}}">Falcon Professional Controllers</h2>
<p>
    The Falcon F16V4 (16 outputs, 32,000 pixels) and F48 (48 outputs, 100,000+ pixels) are
    the industry standard for large-scale holiday light shows and commercial pixel displays.
    Features include E1.31/Art-Net/DDP Ethernet input, SD card show playback without a PC,
    differential signal outputs for long cable runs, and fused per-port power distribution.
</p>
<h2 style="color:{{accent}}">Protocol Support</h2>
<ul>
    <li><strong>WLED:</strong> WS2812B, APA102, SK6812, WS2801 — Wi-Fi, E1.31, Art-Net, DDP, MQTT</li>
    <li><strong>Teensy:</strong> WS2812B, APA102, WS2801, RGBW — USB, Art-Net, E1.31, OctoWS2811</li>
    <li><strong>Falcon:</strong> WS2812B, WS2811, APA102, TM1809, LPD6803, SM16703 — E1.31, Art-Net, DDP, DMX</li>
</ul>
</article>
""";

    public static string MatrixPanelsPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Matrix Panels</h1>
<p>
    LED matrix panels are modular RGB displays designed to tile together into large video walls,
    scoreboards, and information displays. Each panel contains a grid of surface-mount RGB LEDs
    driven by constant-current shift register ICs (typically ICN2037 or FM6124), connected via
    the HUB75 standard interface.
</p>
<h2 style="color:{{accent}}">Available Pixel Pitches</h2>
<p>
    <strong>P2.5</strong> — 2.5mm pitch, 64×64 pixels per panel (160×160mm). Ultra-high resolution
    for close viewing (1-3m). Indoor use only. Ideal for reception displays and information kiosks.
</p>
<p>
    <strong>P3</strong> — 3mm pitch, 64×32 pixels per panel (192×96mm). Excellent resolution for
    indoor signage viewed from 2-5m. Our most popular indoor panel for retail and event displays.
</p>
<p>
    <strong>P5</strong> — 5mm pitch, 64×32 pixels per panel (320×160mm). Medium resolution
    suitable for 3-10m viewing distance. Available in indoor and outdoor (IP65) versions.
    Popular for sports scoreboards, church displays, and semi-outdoor installations under canopies.
</p>
<p>
    <strong>P10</strong> — 10mm pitch, 32×16 pixels per panel (320×160mm). Low resolution,
    high brightness outdoor panels with IP65 rating. Designed for building-mounted signs,
    highway message boards, and any application viewed from 10m or more.
</p>
<h2 style="color:{{accent}}">Driving HUB75 Panels</h2>
<p>
    HUB75 panels require a dedicated driver that can rapidly scan the rows and clock out pixel
    data. For hobbyist projects, use an ESP32 with the ESP32-HUB75-MatrixPanel-DMA library
    (drives up to 12 panels). For larger video walls, use professional receiver cards
    (Linsn RV908, Colorlight 5A-75B) connected via Ethernet to a sending card in your PC.
</p>
</article>
""";

    public static string PowerSuppliesPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Pixel Power Supplies</h1>
<p>
    Proper power is the foundation of every reliable LED pixel installation. Under-specced
    power supplies cause voltage drop (dim, yellow-shifted pixels at the end of long runs),
    overheating, and premature failure. We carry UL/CE certified Meanwell power supplies
    specifically selected for LED pixel workloads.
</p>
<h2 style="color:{{accent}}">5V Power Supplies (for WS2812B, APA102, SK6812)</h2>
<ul>
    <li><strong>Meanwell LRS-50-5:</strong> 5V 10A (50W) — up to 150 pixels</li>
    <li><strong>Meanwell LRS-100-5:</strong> 5V 18A (90W) — up to 300 pixels</li>
    <li><strong>Meanwell LRS-200-5:</strong> 5V 40A (200W) — up to 600 pixels</li>
    <li><strong>Meanwell LRS-350-5:</strong> 5V 60A (300W) — up to 1000 pixels</li>
    <li><strong>Meanwell HLG-150H-5 (outdoor IP67):</strong> 5V 25A — for weatherproof installations</li>
</ul>
<h2 style="color:{{accent}}">12V Power Supplies (for WS2811, GS8208)</h2>
<ul>
    <li><strong>Meanwell LRS-100-12:</strong> 12V 8.5A (100W) — up to 500 WS2811 nodes</li>
    <li><strong>Meanwell LRS-200-12:</strong> 12V 17A (200W) — up to 1000 nodes</li>
    <li><strong>Meanwell LRS-350-12:</strong> 12V 29A (350W) — up to 1750 nodes</li>
    <li><strong>Meanwell HLG-150H-12 (outdoor IP67):</strong> 12V 12.5A — weatherproof</li>
</ul>
<h2 style="color:{{accent}}">Sizing Formula</h2>
<p>
    Total amps = (pixel count × max current per pixel) × 1.2 safety margin.<br>
    WS2812B: pixel count × 0.06A × 1.2.<br>
    WS2811 (single LED): pixel count × 0.02A × 1.2.<br>
    Always round up to the next available supply size.
</p>
</article>
""";

    public static string ConnectorsPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">Connectors, Cables &amp; Mounting Accessories</h1>
<p>
    The right connectors and mounting hardware make the difference between a clean, reliable
    installation and a frustrating mess of loose wires. We stock every connector type used in
    addressable LED pixel projects, plus aluminum extrusion channels, diffusers, and mounting
    clips for professional finishes.
</p>
<h2 style="color:{{accent}}">Connectors</h2>
<ul>
    <li><strong>3-pin JST-SM:</strong> Standard WS2812B strip connector — data + 5V + GND. Male and female pigtails with 15cm leads.</li>
    <li><strong>4-pin JST-SM:</strong> For RGBW strips (SK6812) — data + 5V + GND + white channel.</li>
    <li><strong>Solderless snap connectors:</strong> Clip onto cut strip ends — no soldering required. Available for 10mm and 12mm strip widths.</li>
    <li><strong>Waterproof 3-pin:</strong> IP67-rated screw-lock connectors for outdoor installations.</li>
    <li><strong>DC barrel jacks:</strong> 5.5×2.1mm for connecting power supplies. Screw-terminal and solder versions.</li>
    <li><strong>Wago 221 lever nuts:</strong> Tool-free wire splicing for power distribution. 2, 3, and 5-port models.</li>
</ul>
<h2 style="color:{{accent}}">Aluminum Channels</h2>
<ul>
    <li><strong>U-channel (surface mount):</strong> 17mm wide, accepts 10-12mm strips. Includes frosted diffuser cover, end caps, and mounting clips. 1m and 2m lengths.</li>
    <li><strong>V-channel (corner mount):</strong> 45° profile for corner installations. Same diffuser and accessory system.</li>
    <li><strong>Recessed channel:</strong> Mounts flush with the surface for a seamless integrated look. Requires a routed groove.</li>
    <li><strong>Flexible silicone channel:</strong> Bendable to curved surfaces while maintaining diffusion. 1m lengths.</li>
</ul>
<h2 style="color:{{accent}}">Signal Accessories</h2>
<ul>
    <li><strong>Level shifter (3.3V to 5V):</strong> SN74HCT125N quad buffer IC on a breakout board. Essential when using 3.3V controllers (ESP32, Raspberry Pi) with 5V pixel strips.</li>
    <li><strong>Signal amplifier/repeater:</strong> Regenerates data signal for cable runs over 5m between controller and strip.</li>
    <li><strong>T-connector:</strong> Split one data output to two strip runs (parallel wiring).</li>
</ul>
</article>
""";

    public static string OutdoorPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">Outdoor Waterproof LED Pixels</h1>
<p>
    Our outdoor LED pixel range is engineered for permanent exterior installations in all
    climates. Every product undergoes UV exposure testing, thermal cycling (-40°C to 80°C),
    salt spray testing, and IP67/IP68 submersion verification before we add it to our catalog.
</p>
<h2 style="color:{{accent}}">IP67 Silicone Tube Strips</h2>
<p>
    Our IP67 WS2812B and WS2811 strips are fully enclosed in UV-stabilized silicone tubing
    with sealed end caps. The silicone maintains flexibility in freezing temperatures and
    resists yellowing from UV exposure for 5+ years. Available in 30 and 60 LEDs/m.
</p>
<h2 style="color:{{accent}}">IP68 Pixel Nodes</h2>
<p>
    WS2811 bullet and square nodes potted in clear UV-stabilized epoxy. Rated for continuous
    submersion — suitable for fountains, pools, and ground-recessed installations. Stainless
    steel 316 mounting hardware included for coastal and high-corrosion environments.
</p>
<h2 style="color:{{accent}}">Weatherproof Accessories</h2>
<ul>
    <li><strong>IP65 junction boxes:</strong> Weatherproof enclosures with cable glands for housing controllers and power connections</li>
    <li><strong>Marine-grade heat shrink:</strong> Adhesive-lined, UV-resistant heat shrink tubing for sealing solder joints</li>
    <li><strong>Silicone sealant:</strong> Neutral-cure RTV silicone for sealing cut ends and connector entry points</li>
    <li><strong>Stainless steel mounting clips:</strong> 316 stainless for coastal environments — will not rust or stain</li>
</ul>
</article>
""";

    public static string NeonFlexPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">Addressable LED Neon Flex</h1>
<p>
    LED neon flex combines the smooth, dot-free glow of traditional glass neon with the
    versatility and safety of addressable LED pixels. Each segment contains individually
    controllable WS2812B or WS2811 LEDs inside a specially extruded silicone housing that
    diffuses the light into a continuous band of color.
</p>
<h2 style="color:{{accent}}">Product Range</h2>
<p>
    <strong>Standard neon flex (top-emitting):</strong> Light emits from the top face. 6×12mm
    cross-section. 60 pixels/m with 16.7mm pixel spacing. Minimum bend radius 40mm. 5V DC.
    Available in 1m, 2m, and 5m lengths with JST-SM connectors.
</p>
<p>
    <strong>Side-bend neon flex:</strong> Light emits from the side face, designed for
    lettering and tight horizontal curves. 6×12mm cross-section. Minimum bend radius 25mm.
    Ideal for channel letter signage and custom shapes.
</p>
<p>
    <strong>360° round neon flex:</strong> Cylindrical 14mm diameter tube emitting light in
    all directions. Perfect for 3D installations, sculptures, and globe-like shapes where
    the pixel must be visible from every angle.
</p>
<h2 style="color:{{accent}}">Specifications</h2>
<ul>
    <li><strong>Pixel IC:</strong> WS2812B (5V) or WS2811 (12V)</li>
    <li><strong>Pixel density:</strong> 60 LEDs/m</li>
    <li><strong>Material:</strong> UV-stabilized food-grade silicone</li>
    <li><strong>IP rating:</strong> IP67</li>
    <li><strong>Cutting unit:</strong> Every 16.7mm (per pixel)</li>
    <li><strong>Lifespan:</strong> 50,000 hours</li>
    <li><strong>Certifications:</strong> UL, CE, RoHS</li>
</ul>
</article>
""";

    public static string PixelArtFramesPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">Pixel Art LED Display Frames</h1>
<p>
    Our pixel art frames are wall-mountable LED displays that bring retro pixel art, live data
    dashboards, and animated notifications to your wall. Each frame contains a grid of WS2812B
    LEDs behind a frosted acrylic diffuser, driven by an ESP32 running WLED firmware. Connect
    via Wi-Fi and control from your phone, computer, or smart home system.
</p>
<h2 style="color:{{accent}}">16×16 Frame (256 pixels)</h2>
<p>
    10mm pixel pitch in a 200×200mm illuminated area. Wooden frame with matte black finish.
    Wall-mountable with a flush-mount bracket (no visible hardware). USB-C powered — runs from
    any 5V 3A USB charger. Ideal for living room pixel art, notification displays, and retro
    game sprite showcases. Viewing distance: 1.5-5m.
</p>
<h2 style="color:{{accent}}">32×32 Frame (1024 pixels)</h2>
<p>
    5mm pixel pitch in a 200×200mm illuminated area. Higher resolution for detailed sprites,
    album art, weather displays, and mini dashboards. Same wooden frame and flush-mount system.
    Powered by USB-C 5V 5A. Viewing distance: 0.5-3m. Supports GIF playback and live data
    feeds via MQTT.
</p>
<h2 style="color:{{accent}}">Software Compatibility</h2>
<ul>
    <li><strong>WLED:</strong> Built-in 100+ effects, color picker, preset scheduling</li>
    <li><strong>PixelIt:</strong> Free desktop app for designing and uploading pixel art</li>
    <li><strong>Home Assistant:</strong> Native WLED integration — show sensor data, notifications, album art</li>
    <li><strong>Art-Net / E1.31:</strong> Drive from professional software (Resolume, MadMapper, xLights)</li>
    <li><strong>MQTT:</strong> Push custom JSON payloads for live dashboards, scores, alerts</li>
</ul>
</article>
""";

    public static string GettingStartedPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">Getting Started with Addressable LED Pixels</h1>
<p>
    This guide walks you through everything you need to go from zero to a working LED pixel
    setup. By the end, you will have a strip of individually addressable LEDs displaying
    colorful animations controlled from your phone.
</p>
<h2 style="color:{{accent}}">Step 1: Gather Your Components</h2>
<ul>
    <li><strong>LED strip:</strong> <a href="/products/ws2812b-led-strips" style="color:{{accent}}">WS2812B 60 LEDs/m, 1m, IP30</a> — the ideal starter strip</li>
    <li><strong>Controller:</strong> <a href="/products/pixel-controllers" style="color:{{accent}}">ESP32 WLED board</a> — pre-flashed, ready to go</li>
    <li><strong>Power supply:</strong> <a href="/products/power-supplies" style="color:{{accent}}">5V 4A USB-C</a> or 5V 10A barrel jack supply</li>
    <li><strong>Wire:</strong> 22 AWG silicone hookup wire (included with our starter kits)</li>
    <li><strong>Capacitor:</strong> 1000μF 6.3V electrolytic (included with our ESP32 boards)</li>
</ul>
<h2 style="color:{{accent}}">Step 2: Wire It Up</h2>
<p>
    Connect the strip's <strong>5V</strong> (red) and <strong>GND</strong> (black) wires to your
    power supply. Connect the strip's <strong>DATA</strong> (green) wire to the ESP32 board's
    data output pin. Place the 1000μF capacitor across 5V and GND close to the strip's power
    input. That's it — three connections.
</p>
<h2 style="color:{{accent}}">Step 3: Configure WLED</h2>
<p>
    Power on the ESP32. It creates a Wi-Fi access point called "WLED-AP". Connect your phone
    to it, open a browser, and navigate to 4.3.2.1. Set your home Wi-Fi credentials, configure
    the LED count (60 for a 1m 60 LED/m strip), and save. WLED will connect to your Wi-Fi —
    open its IP address in any browser to access the full control panel.
</p>
<h2 style="color:{{accent}}">Step 4: Play with Effects</h2>
<p>
    WLED includes 100+ built-in effects: Rainbow, Fire, Meteor, Twinkle, Gradient, Chase,
    Colorwaves, Fireworks, and many more. Pick a color, select an effect, adjust speed and
    intensity, and save presets for your favorites. Add sound reactivity by enabling the
    AudioReactive usermod and connecting a microphone module.
</p>
<h2 style="color:{{accent}}">Next Steps</h2>
<ul>
    <li><a href="/guides/choosing-pixels" style="color:{{accent}}">Choose the right pixel type</a> for your next project</li>
    <li><a href="/guides/power-calculation" style="color:{{accent}}">Calculate power requirements</a> for larger installations</li>
    <li><a href="/guides/installation" style="color:{{accent}}">Mount and weatherproof</a> for permanent placement</li>
    <li><a href="/guides/programming" style="color:{{accent}}">Write custom code</a> with FastLED and Arduino</li>
</ul>
</article>
""";

    public static string ChoosingPixelsPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">How to Choose the Right LED Pixels</h1>
<p>
    With so many addressable LED options available, choosing the right one for your project
    can be overwhelming. This guide compares the four most popular pixel types across the
    factors that matter: voltage, protocol speed, density, cost, and best use case.
</p>
<h2 style="color:{{accent}}">Quick Comparison Table</h2>
<table style="width:100%; border-collapse:collapse; margin:1rem 0;">
    <tr style="border-bottom:2px solid {{accent}};">
        <th style="text-align:left; padding:0.5rem;">Feature</th>
        <th style="text-align:left; padding:0.5rem;">WS2812B</th>
        <th style="text-align:left; padding:0.5rem;">APA102</th>
        <th style="text-align:left; padding:0.5rem;">WS2811</th>
        <th style="text-align:left; padding:0.5rem;">SK6812</th>
    </tr>
    <tr style="border-bottom:1px solid #ccc;">
        <td style="padding:0.5rem;">Voltage</td><td style="padding:0.5rem;">5V</td><td style="padding:0.5rem;">5V</td><td style="padding:0.5rem;">12V</td><td style="padding:0.5rem;">5V</td>
    </tr>
    <tr style="border-bottom:1px solid #ccc;">
        <td style="padding:0.5rem;">Protocol</td><td style="padding:0.5rem;">1-wire 800Kbps</td><td style="padding:0.5rem;">SPI 20MHz</td><td style="padding:0.5rem;">1-wire 800Kbps</td><td style="padding:0.5rem;">1-wire 800Kbps</td>
    </tr>
    <tr style="border-bottom:1px solid #ccc;">
        <td style="padding:0.5rem;">PWM Rate</td><td style="padding:0.5rem;">~400 Hz</td><td style="padding:0.5rem;">19.2 kHz</td><td style="padding:0.5rem;">~400 Hz</td><td style="padding:0.5rem;">~400 Hz</td>
    </tr>
    <tr style="border-bottom:1px solid #ccc;">
        <td style="padding:0.5rem;">Colors</td><td style="padding:0.5rem;">RGB</td><td style="padding:0.5rem;">RGB</td><td style="padding:0.5rem;">RGB</td><td style="padding:0.5rem;">RGB or RGBW</td>
    </tr>
    <tr style="border-bottom:1px solid #ccc;">
        <td style="padding:0.5rem;">Best for</td><td style="padding:0.5rem;">General use</td><td style="padding:0.5rem;">Video/POV</td><td style="padding:0.5rem;">Outdoor/long runs</td><td style="padding:0.5rem;">White + color</td>
    </tr>
    <tr>
        <td style="padding:0.5rem;">Relative cost</td><td style="padding:0.5rem;">$</td><td style="padding:0.5rem;">$$$</td><td style="padding:0.5rem;">$$</td><td style="padding:0.5rem;">$$</td>
    </tr>
</table>
<h2 style="color:{{accent}}">Decision Guide</h2>
<p>
    <strong>Choose WS2812B</strong> if you want the widest compatibility, lowest cost, and
    largest community support. It handles 90% of pixel projects perfectly.
</p>
<p>
    <strong>Choose APA102</strong> if you need flicker-free operation for video/film, POV
    displays, or very fast refresh rates. Worth the premium for professional applications.
</p>
<p>
    <strong>Choose WS2811</strong> if you need 12V operation for long cable runs (outdoor
    buildings, signage, holiday displays) or discrete node form factors (pixel trees, channel letters).
</p>
<p>
    <strong>Choose SK6812</strong> if you need both colorful effects and high-quality white
    light — under-cabinet lighting, task lighting with ambient color, or any RGBW application.
</p>
</article>
""";

    public static string PowerCalculationPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Pixel Power Supply Calculator</h1>
<p>
    Getting your power supply sizing right is critical. Too small and pixels dim, flicker, or
    the supply overheats. Too large and you waste money and space. This guide provides the
    formulas, charts, and real-world examples to size your supply perfectly.
</p>
<h2 style="color:{{accent}}">The Formula</h2>
<p>
    <strong>Required Amps = Pixel Count × Max Current Per Pixel × 1.2 Safety Margin</strong>
</p>
<ul>
    <li>WS2812B / APA102: 0.06A per pixel at 5V (60mA)</li>
    <li>SK6812 RGBW: 0.08A per pixel at 5V (80mA — four channels)</li>
    <li>WS2811 (single LED): 0.02A per node at 12V (20mA)</li>
    <li>WS2811 (3-LED module): 0.06A per node at 12V (60mA)</li>
</ul>
<h2 style="color:{{accent}}">Real-World Examples</h2>
<p>
    <strong>Desk setup — 2m WS2812B 60/m (120 pixels):</strong><br>
    120 × 0.06A × 1.2 = 8.6A → Use 5V 10A supply (LRS-50-5).
</p>
<p>
    <strong>Room perimeter — 15m WS2812B 30/m (450 pixels):</strong><br>
    450 × 0.06A × 1.2 = 32.4A → Use 5V 40A supply (LRS-200-5). Inject power every 150 pixels.
</p>
<p>
    <strong>Holiday mega-tree — 2000 WS2811 nodes (12V):</strong><br>
    2000 × 0.02A × 1.2 = 48A → Two 12V 29A supplies (LRS-350-12). Distribute across the tree.
</p>
<h2 style="color:{{accent}}">Wire Gauge Chart</h2>
<ul>
    <li><strong>14 AWG:</strong> Up to 32A — main trunk power runs</li>
    <li><strong>16 AWG:</strong> Up to 22A — secondary power distribution</li>
    <li><strong>18 AWG:</strong> Up to 16A — branch runs and power injection taps</li>
    <li><strong>20 AWG:</strong> Up to 11A — short branch connections</li>
    <li><strong>22 AWG:</strong> Up to 7A — data lines and low-current branches</li>
</ul>
<h2 style="color:{{accent}}">Power Injection Points</h2>
<p>
    For WS2812B 60 LEDs/m strips, inject power every 2.5 meters (150 pixels). For 144 LEDs/m,
    inject every 0.5 meters (72 pixels). For 12V WS2811 nodes, you can run 5-10 meters between
    injection points depending on wire gauge. Always inject both 5V/12V and GND — never GND only.
</p>
</article>
""";

    public static string InstallationPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Pixel Installation Guide</h1>
<p>
    A proper installation makes your LED pixels last longer, look better, and cause fewer
    headaches. This guide covers the four pillars of a great install: surface preparation,
    mounting methods, wiring best practices, and weatherproofing.
</p>
<h2 style="color:{{accent}}">Surface Preparation</h2>
<p>
    Clean the mounting surface thoroughly with isopropyl alcohol (90%+) and allow it to dry
    completely. For adhesive-backed strips, the surface must be smooth, dry, and free of dust
    or grease. Rough or textured surfaces — use aluminum channels with mechanical mounting
    clips instead of relying on adhesive alone.
</p>
<h2 style="color:{{accent}}">Indoor Mounting Methods</h2>
<ul>
    <li><strong>3M VHB adhesive (built in):</strong> Works on smooth, clean surfaces. Temperature range -20°C to 60°C. Press firmly for 30 seconds per section.</li>
    <li><strong>Aluminum channel:</strong> Professional finish with diffusion. Screw or adhesive mount the channel, then slide the strip in. Best for permanent installs.</li>
    <li><strong>Silicone clips:</strong> Snap-on clips every 20-30cm for easy strip removal and reinstallation. Good for rental/temporary setups.</li>
    <li><strong>Magnetic mount:</strong> Attach magnetic tape to the strip backing for repositionable mounting on metal surfaces.</li>
</ul>
<h2 style="color:{{accent}}">Outdoor Weatherproofing</h2>
<ul>
    <li>Use IP67 silicone-tube strips or IP68 potted nodes for all outdoor installations</li>
    <li>Seal all cut ends with silicone end caps and neutral-cure RTV sealant</li>
    <li>Use IP67 waterproof connectors or seal soldered joints with adhesive-lined heat shrink</li>
    <li>Mount controllers and power supplies in IP65 junction boxes with cable glands</li>
    <li>Route cables through UV-rated conduit and drip-loop all vertical cable entries</li>
    <li>Test all sealed connections with a spray test before final assembly</li>
</ul>
<h2 style="color:{{accent}}">Wiring Best Practices</h2>
<ul>
    <li>Keep data wire runs under 5m between controller and first pixel (use a signal amplifier for longer runs)</li>
    <li>Add a 300-470Ω resistor in series with the data line at the controller end</li>
    <li>Place a 1000μF capacitor across power and ground at each power injection point</li>
    <li>Use appropriately gauged wire for the current load (see our <a href="/guides/power-calculation" style="color:{{accent}}">power guide</a>)</li>
    <li>Label all wires and connections — future-you will thank present-you</li>
</ul>
</article>
""";

    public static string ProgrammingPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">Programming LED Pixels</h1>
<p>
    While WLED handles most use cases without writing code, custom programming unlocks
    unlimited creative possibilities. This guide covers the essential tools and code patterns
    for programming addressable LEDs with Arduino, ESP32, and FastLED.
</p>
<h2 style="color:{{accent}}">Development Environment</h2>
<p>
    Install the <strong>Arduino IDE</strong> (2.x recommended) and add the ESP32 board package
    via the Board Manager. Install the <strong>FastLED</strong> library via the Library Manager.
    Connect your ESP32 via USB and select the correct board and port in Arduino IDE.
</p>
<h2 style="color:{{accent}}">Your First Sketch: Rainbow</h2>
<p>A basic rainbow animation in FastLED:</p>
<pre style="background:#1e1e3f; color:#e0e0ff; padding:1rem; border-radius:4px; overflow-x:auto; font-size:0.9rem;">
#include &lt;FastLED.h&gt;
#define NUM_LEDS 60
#define DATA_PIN 16
CRGB leds[NUM_LEDS];
uint8_t hue = 0;

void setup() {
  FastLED.addLeds&lt;WS2812B, DATA_PIN, GRB&gt;(leds, NUM_LEDS);
  FastLED.setBrightness(128);
}

void loop() {
  fill_rainbow(leds, NUM_LEDS, hue++, 7);
  FastLED.show();
  FastLED.delay(20);
}
</pre>
<h2 style="color:{{accent}}">Common Patterns</h2>
<ul>
    <li><strong>Color wipe:</strong> Set pixels one by one with a delay between each — creates a traveling dot or fill effect</li>
    <li><strong>Fire effect:</strong> Use FastLED's HeatColor palette with random sparking to simulate flickering flames</li>
    <li><strong>Palette cycling:</strong> Define a CRGBPalette16 and use ColorFromPalette() with a shifting index for smooth professional gradients</li>
    <li><strong>Segment control:</strong> Divide your strip into logical segments and run different effects on each segment simultaneously</li>
</ul>
<h2 style="color:{{accent}}">Sound Reactivity</h2>
<p>
    For beat-reactive LEDs, connect an INMP441 I2S microphone to your ESP32 and use the
    ArduinoFFT library to perform real-time frequency analysis. Map frequency bands to LED
    segments: bass (60-250 Hz) drives the center, mids (250-2000 Hz) fill outward, and
    treble (2000-16000 Hz) triggers sparkle effects at the edges.
</p>
<h2 style="color:{{accent}}">Network Control</h2>
<p>
    For network-controlled LEDs, use the ESP32's WiFi library combined with the ArtnetWifi
    or E131 library to receive streaming pixel data from professional software. This lets you
    drive LEDs from xLights, Resolume, MadMapper, or any Art-Net / E1.31 source over Wi-Fi
    or Ethernet.
</p>
</article>
""";

    public static string PixelTechnologyPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">How Addressable LED Pixels Work</h1>
<p>
    An addressable LED pixel is a small marvel of integrated circuit engineering. Understanding
    how they work helps you design better installations, troubleshoot problems faster, and
    choose the right pixel type for your project.
</p>
<h2 style="color:{{accent}}">The Architecture</h2>
<p>
    Each WS2812B pixel is a 5050-package (5mm × 5mm) containing three LED dies (red, green,
    blue) and a WS2812B controller IC — all bonded to a single lead frame. The IC has four
    pins: VDD (5V power), VSS (ground), DIN (data in), and DOUT (data out).
</p>
<p>
    When data arrives at DIN, the IC extracts the first 24 bits (the color value for this pixel)
    and passes all remaining bits out through DOUT to the next pixel. This cascading
    architecture means the first pixel in the chain receives data first, the second pixel
    receives the remaining data, and so on down the line. After all data is sent, a reset
    pulse (50μs+ of low signal) causes all pixels to latch their values and update simultaneously.
</p>
<h2 style="color:{{accent}}">PWM Dimming</h2>
<p>
    Each color channel is driven by Pulse Width Modulation. The IC switches the LED on and off
    at a fixed frequency (~400 Hz for WS2812B, 19.2 kHz for APA102). Brightness is controlled
    by varying the duty cycle — 50% on-time produces 50% perceived brightness (after gamma
    correction). With 8-bit resolution per channel, each LED has 256 brightness levels,
    yielding 256³ = 16,777,216 color combinations.
</p>
<h2 style="color:{{accent}}">Signal Propagation</h2>
<p>
    Each pixel reshapes the data signal — acting as a miniature repeater. This is why
    addressable LED strips can work at all: the digital signal is regenerated at every pixel,
    maintaining clean logic levels over hundreds of meters of total strip length. However,
    the signal regeneration adds a tiny delay per pixel (~30μs for WS2812B), limiting the
    maximum refresh rate for very long chains: 1000 pixels × 30μs = 30ms per frame = 33 fps.
</p>
<h2 style="color:{{accent}}">Voltage Considerations</h2>
<p>
    The 5V WS2812B IC has a minimum operating voltage of approximately 3.5V. As current flows
    through the strip's copper PCB traces, resistance causes progressive voltage drop. At the
    end of a long unpowered strip, voltage may drop below the IC's minimum, causing dim or
    glitching pixels. Power injection — feeding 5V at multiple points along the strip —
    solves this completely.
</p>
</article>
""";

    public static string ProtocolsPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Communication Protocols Compared</h1>
<p>
    Different LED pixel products use different communication protocols. Understanding these
    protocols helps you choose compatible controllers, predict performance limits, and
    troubleshoot signal issues.
</p>
<h2 style="color:{{accent}}">WS2812B Protocol (Single-Wire NRZ)</h2>
<p>
    The WS2812B uses a single data line transmitting at 800 Kbps. Each bit is a precisely
    timed pulse: logical 1 = 0.7μs high + 0.6μs low; logical 0 = 0.35μs high + 0.8μs low.
    Timing tolerance is ±150ns. A reset occurs after 50μs of continuous low. Pros: single
    wire, simple wiring. Cons: timing-critical (requires hardware timers or DMA), susceptible
    to noise on long cable runs, ~400 Hz PWM causes visible flicker on camera.
</p>
<h2 style="color:{{accent}}">APA102 Protocol (SPI)</h2>
<p>
    APA102 uses standard SPI with clock (CLK) and data (MOSI) lines. Data is clocked at up
    to 20 MHz. Each pixel receives a 32-bit frame: 3-bit header (111), 5-bit global brightness,
    8-bit blue, 8-bit green, 8-bit red. The explicit clock line eliminates timing sensitivity —
    the data rate is limited only by clock speed, not software timing precision. This makes
    APA102 ideal for resource-constrained or multi-tasking controllers.
</p>
<h2 style="color:{{accent}}">DMX512</h2>
<p>
    DMX512 is the professional stage lighting standard. It transmits 512 channels per universe
    at 250 Kbaud over RS-485 differential signaling (reliable over 300m cable runs). Each RGB
    pixel uses 3 channels, so one universe drives 170 pixels — fine for stage fixtures, but
    limiting for large pixel displays. XLR 5-pin or RJ45 connectors are standard.
</p>
<h2 style="color:{{accent}}">E1.31 (sACN) — DMX Over Ethernet</h2>
<p>
    E1.31 (streaming Architecture for Control Networks) transmits DMX512 universes over
    standard IP networks via multicast UDP. Up to 63,999 universes are supported, enabling
    millions of pixels. E1.31 is the de facto standard for large-format pixel shows controlled
    by xLights, Vixen, or commercial lighting consoles.
</p>
<h2 style="color:{{accent}}">Art-Net</h2>
<p>
    Art-Net is another DMX-over-Ethernet protocol, widely used in the entertainment industry.
    It supports 32,768 universes and is compatible with most professional lighting consoles and
    software. Both unicast and broadcast modes are available. Art-Net 4 adds subscription-based
    multicast for improved network efficiency.
</p>
<h2 style="color:{{accent}}">DDP (Distributed Display Protocol)</h2>
<p>
    DDP is a modern, purpose-built protocol for pixel control. Unlike E1.31 and Art-Net, DDP
    sends variable-length packets — no universe splitting required. This simplifies configuration
    and reduces overhead. DDP is natively supported by WLED, FPP (Falcon Player), xLights, and
    most modern controllers.
</p>
</article>
""";

    public static string ColorMixingPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">RGB Color Mixing for LED Pixels</h1>
<p>
    Understanding how LED pixels create color is fundamental to designing great animations
    and lighting effects. This guide covers additive RGB mixing, the HSV color space preferred
    for animation, gamma correction, and color rendering quality.
</p>
<h2 style="color:{{accent}}">Additive RGB Color Mixing</h2>
<p>
    LED pixels use additive color mixing — each pixel contains separate Red, Green, and Blue
    LEDs that combine their light output to create any perceived color. When all three channels
    are off, you see black (no light). When all three are at full brightness, you see white.
    The primary combinations are: Red + Green = Yellow, Red + Blue = Magenta, Green + Blue = Cyan.
    With 8-bit control per channel (0-255), pixels can display 256³ = 16,777,216 distinct colors.
</p>
<h2 style="color:{{accent}}">HSV Color Space</h2>
<p>
    While RGB defines colors by mixing primaries, HSV (Hue, Saturation, Value) describes color
    the way humans think about it: What color? (Hue: 0-255 mapped to the rainbow), How vivid?
    (Saturation: 0=gray, 255=pure color), How bright? (Value: 0=off, 255=full). FastLED's
    CHSV type makes animation intuitive — incrementing Hue by 1 each frame creates a smooth
    rainbow cycle without any math.
</p>
<h2 style="color:{{accent}}">Gamma Correction</h2>
<p>
    Human vision perceives brightness logarithmically, not linearly. A pixel at 50% PWM duty
    cycle (value 128) looks much brighter than "half" brightness — it appears about 73% as
    bright. Gamma correction applies a power curve (typically γ = 2.2 or 2.8) to map linear
    PWM values to perceptually uniform brightness steps. Without gamma correction, fades look
    uneven and washed out. FastLED's dim8_video() applies approximate gamma correction per frame.
</p>
<h2 style="color:{{accent}}">Color Temperature &amp; CRI</h2>
<p>
    RGB pixel LEDs produce "white" by mixing all three channels at full power. This synthetic
    white has a color temperature of roughly 6500K (cool daylight) and a CRI (Color Rendering
    Index) of only 20-40 — objects lit by it look unnatural. For applications requiring quality
    white light, SK6812 RGBW pixels add a dedicated warm white LED (2700-4000K) with CRI 80+,
    producing natural-looking illumination alongside colorful effects.
</p>
</article>
""";

    public static string ResourcesPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">LED Pixel Tools, Software &amp; Resources</h1>
<h2 style="color:{{accent}}">Firmware &amp; Controllers</h2>
<ul>
    <li><strong>WLED</strong> — Open-source ESP32/ESP8266 firmware with 100+ effects, web UI, sound reactivity, and smart home integration</li>
    <li><strong>FPP (Falcon Player)</strong> — Raspberry Pi / BeagleBone show player for E1.31/Art-Net sequences. Used with Falcon controllers for holiday light shows</li>
    <li><strong>ESPixelStick</strong> — Lightweight E1.31 receiver firmware for ESP8266/ESP32</li>
</ul>
<h2 style="color:{{accent}}">Sequencing &amp; Design Software</h2>
<ul>
    <li><strong>xLights</strong> — Free, open-source sequencer with timeline editor, effect library, and pixel layout modeling. The standard for holiday light shows</li>
    <li><strong>Vixen Lights</strong> — Free Windows sequencer with drag-and-drop effects and prop wizard</li>
    <li><strong>Jinx!</strong> — Free LED matrix software for real-time effects on HUB75 panels</li>
    <li><strong>LedFx</strong> — Open-source real-time music visualization for networked LED strips</li>
    <li><strong>Resolume Arena</strong> — Professional VJ and media server software with Art-Net/sACN output</li>
</ul>
<h2 style="color:{{accent}}">Programming Libraries</h2>
<ul>
    <li><strong>FastLED</strong> — Arduino C++ library supporting 50+ LED chipsets, HSV color, palettes, noise functions, and power management</li>
    <li><strong>Adafruit NeoPixel</strong> — Lightweight Arduino library for WS2812B and friends</li>
    <li><strong>rpi-ws281x</strong> — Python library for Raspberry Pi GPIO-driven WS281x strips</li>
    <li><strong>OctoWS2811</strong> — Teensy library for driving up to 8 parallel WS2812B strings via DMA</li>
</ul>
<h2 style="color:{{accent}}">Community</h2>
<ul>
    <li><strong>WLED Discord</strong> — 20,000+ members, active troubleshooting and project sharing</li>
    <li><strong>r/addressableLEDs</strong> — Reddit community for pixel LED projects and advice</li>
    <li><strong>xLights Facebook Group</strong> — 30,000+ members focused on holiday light show sequencing</li>
    <li><strong>FastLED GitHub</strong> — Issue tracker, examples, and community contributions</li>
</ul>
<h2 style="color:{{accent}}">Useful Tools</h2>
<ul>
    <li><strong>QuinLED wire calculator</strong> — Calculate wire gauge for any LED power distribution scenario</li>
    <li><strong>WLED web installer</strong> — Flash WLED firmware to ESP32 directly from your browser</li>
    <li><strong>LED strip power calculator</strong> — Input pixel count, type, and brightness to get exact power supply sizing</li>
</ul>
</article>
""";

    public static string AboutPageBody(string accent) => $$"""
<article>
<h1 style="color:{{accent}}">About BrightPixel</h1>
<p>
    BrightPixel was founded in 2019 by lighting designers and electronics engineers who were
    frustrated by the difficulty of sourcing quality LED pixel components. Generic LED resellers
    offer thousands of poorly documented products with misleading specifications. We decided
    to build the store we wished existed: a curated selection of tested, honestly specified
    products backed by real technical support.
</p>
<h2 style="color:{{accent}}">What Sets Us Apart</h2>
<ul>
    <li><strong>Tested products:</strong> Every product we sell has been tested in our lab for electrical performance, waterproofing (where rated), and long-term reliability. If it does not meet spec, we do not sell it.</li>
    <li><strong>Honest specifications:</strong> We publish actual measured current draw, not theoretical maximums. Our IP ratings are verified by independent testing, not just the manufacturer's claim.</li>
    <li><strong>Technical support:</strong> Our support team includes electronics engineers and lighting designers. We can help with wiring, software configuration, power distribution, and controller selection — not just order tracking.</li>
    <li><strong>Guides and education:</strong> Our <a href="/guides/getting-started" style="color:{{accent}}">comprehensive guides</a> help you succeed with your project, whether it is your first LED strip or your 100th installation.</li>
</ul>
<h2 style="color:{{accent}}">Who We Serve</h2>
<p>
    Our customers range from hobbyists building their first desk LED setup to professional
    lighting designers specifying components for commercial architectural installations. We
    supply holiday light show enthusiasts, LED artists, event production companies, sign
    fabricators, AV integrators, and creative agencies.
</p>
<h2 style="color:{{accent}}">Wholesale</h2>
<p>
    We offer tiered wholesale pricing for orders above $500. Contact our sales team for a
    custom quote tailored to your volume and product mix. We regularly supply lighting
    designers, AV integrators, event production companies, and retail display specialists.
</p>
</article>
""";
}
