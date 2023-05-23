using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class Collection
{
    public int Id { set; get; }
    public string Name { set; get; }
    [JsonPropertyName("poster_path")]
    public string Poster { get; set; }
    [JsonPropertyName("backdrop_path")]
    public string Backdrop { get; set; }
    public int[] MovieId { set; get; }
    public int[] TVId { set; get; }
    public bool IsPublic { set; get; }
    public string UserId { set; get; }
}