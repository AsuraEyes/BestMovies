using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class MovieCollection
{
    public int Id { set; get; }
    public string Name { set; get; }
    [JsonPropertyName("poster_path")]
    public string Poster { get; set; }
    [JsonPropertyName("backdrop_path")]
    public string Backdrop { get; set; }
    public string Overview { get; set; }
    public int Revenue { get; set; }
    [JsonPropertyName("parts")]
    public Movie[] Movies { set; get; }
}