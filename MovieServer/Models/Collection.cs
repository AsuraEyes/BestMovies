using System.Text.Json.Serialization;

namespace MovieServer.Models;

public class Collection
{
    public int Id { set; get; }
    public string Name { set; get; }
    [JsonPropertyName("poster_path")]
    public string Poster { get; set; }
    [JsonPropertyName("backdrop_path")]
    public string Backdrop { get; set; }
    [JsonPropertyName("media")]
    public Media[] Media { set; get; }
    public bool IsPublic { set; get; }
    public string UserId { set; get; }
}