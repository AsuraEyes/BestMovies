using System.Text.Json.Serialization;
using PresentationTier.Models;

namespace MovieServer.Models;

public class Movie : Media
{
    [JsonPropertyName("belongs_to_collection")]
    public Collection Collection { get; set; }
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }

    public Movie()
    { }
}