using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class Media
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public Genre[] Genres { get; set; }
    public string Overview { get; set; }
    public string Trailer { get; set; }
    public double AvgRating { get; set; }
    [JsonPropertyName("poster_path")]
    public string Poster { get; set; }
    [JsonPropertyName("backdrop_path")]
    public string Backdrop { get; set; }
    public Language[] SpokenLanguage { get; set; }
    public string Status { get; set; }
    [JsonPropertyName("media_type")]
    public string Type { get; set; }
    [JsonPropertyName("tagline")]
    public string Tagline { get; set; }
    public Videos Videos { get; set; }
    public Credits Credits { get; set; }
}