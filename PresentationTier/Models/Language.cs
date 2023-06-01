using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class Language
{
    public string iso_639_1 { get; set; }
    [JsonPropertyName("english_name")]
    public string Name { get; set; }
}