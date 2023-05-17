using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class Movie : Media
{
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
}