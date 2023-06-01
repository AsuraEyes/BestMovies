using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class Movie : Media
{
    [JsonPropertyName("belongs_to_collection")]
    public MovieCollection MovieCollection { get; set; }
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
    public int Revenue { get; set; }
    public int Budget { get; set; }
}