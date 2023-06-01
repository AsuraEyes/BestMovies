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
    [JsonPropertyName("original_language")]
    public string Language { get; set; }
    public string Status { get; set; }
    [JsonPropertyName("media_type")]
    public string Type { get; set; }
    [JsonPropertyName("tagline")]
    public string Tagline { get; set; }
    public Videos Videos { get; set; }
    public Credits Credits { get; set; }
    public string Character { get; set; }
    public string Department { get; set; }
    public string Job { get; set; }
    [JsonPropertyName("vote_average")]
    public float AVGVote { get; set; }
    [JsonPropertyName("vote_count")]
    public int Count { get; set; }
}