using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DnsProxyPoc.Content;

public static class JsonLdGenerator
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static string WebPageSchema(BotPage page, string baseUrl, bool isHome)
    {
        var canonicalUrl = baseUrl + page.Path;
        var schemaType = isHome ? "WebPage" : "Article";

        var schema = new JsonObject
        {
            ["@context"] = "https://schema.org",
            ["@type"] = schemaType,
            ["@id"] = canonicalUrl,
            ["headline"] = page.Title,
            ["name"] = page.Title,
            ["description"] = page.MetaDescription,
            ["url"] = canonicalUrl,
            ["inLanguage"] = "en",
            ["datePublished"] = BotPageRegistry.DatePublished,
            ["dateModified"] = BotPageRegistry.DateModified,
            ["author"] = new JsonObject
            {
                ["@type"] = "Organization",
                ["name"] = BotPageRegistry.SiteName,
                ["url"] = baseUrl
            },
            ["publisher"] = new JsonObject
            {
                ["@type"] = "Organization",
                ["name"] = BotPageRegistry.SiteName,
                ["url"] = baseUrl
            },
            ["isPartOf"] = new JsonObject
            {
                ["@type"] = "WebSite",
                ["@id"] = baseUrl + "/#website",
                ["name"] = BotPageRegistry.SiteName,
                ["url"] = baseUrl
            }
        };

        return schema.ToJsonString(JsonOptions);
    }

    public static string WebSiteSchema(string baseUrl)
    {
        var schema = new JsonObject
        {
            ["@context"] = "https://schema.org",
            ["@type"] = "WebSite",
            ["@id"] = baseUrl + "/#website",
            ["name"] = BotPageRegistry.SiteName,
            ["url"] = baseUrl,
            ["description"] = BotPageRegistry.SiteDescription,
            ["inLanguage"] = "en"
        };

        return schema.ToJsonString(JsonOptions);
    }

    public static string? BreadcrumbSchema(string path, string baseUrl)
    {
        var items = path switch
        {
            "/science/optics"      => new[] { ("Home", "/"), ("Science", "/science"), ("Optics & Perception", "/science/optics") },
            "/science/chemistry"   => new[] { ("Home", "/"), ("Science", "/science"), ("Pigment Chemistry", "/science/chemistry") },
            "/culture/symbolism"   => new[] { ("Home", "/"), ("Culture", "/culture"), ("Global Symbolism", "/culture/symbolism") },
            "/culture/art-history" => new[] { ("Home", "/"), ("Culture", "/culture"), ("Art History", "/culture/art-history") },
            "/guides/color-theory" => new[] { ("Home", "/"), ("Guides", "/guides"), ("Color Theory", "/guides/color-theory") },
            "/resources"           => new[] { ("Home", "/"), ("Resources", "/resources") },
            _                      => Array.Empty<(string, string)>()
        };

        if (items.Length == 0) return null;

        var listItems = new JsonArray();
        for (var i = 0; i < items.Length; i++)
        {
            listItems.Add(new JsonObject
            {
                ["@type"] = "ListItem",
                ["position"] = i + 1,
                ["name"] = items[i].Item1,
                ["item"] = baseUrl + items[i].Item2
            });
        }

        var schema = new JsonObject
        {
            ["@context"] = "https://schema.org",
            ["@type"] = "BreadcrumbList",
            ["itemListElement"] = listItems
        };

        return schema.ToJsonString(JsonOptions);
    }

    public static string? FaqPageSchema((string Question, string Answer)[] items)
    {
        if (items.Length == 0) return null;

        var mainEntity = new JsonArray();
        foreach (var (question, answer) in items)
        {
            mainEntity.Add(new JsonObject
            {
                ["@type"] = "Question",
                ["name"] = question,
                ["acceptedAnswer"] = new JsonObject
                {
                    ["@type"] = "Answer",
                    ["text"] = answer
                }
            });
        }

        var schema = new JsonObject
        {
            ["@context"] = "https://schema.org",
            ["@type"] = "FAQPage",
            ["mainEntity"] = mainEntity
        };

        return schema.ToJsonString(JsonOptions);
    }
}
