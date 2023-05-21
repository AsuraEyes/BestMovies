using System.Text.Json.Serialization;

namespace MovieServer.Models;

public class Movie : Media
{
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }

    public Movie()
    { }
}