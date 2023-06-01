using System.Text.Json.Serialization;

namespace MovieServer.Models;

public class Language
{
    public string iso_639_1 { get; set; }
    [JsonPropertyName("english_name")]
    public string Name { get; set; }
}