using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieServer.Models;

public class Collection
{
     [BsonId]
    public ObjectId Id { get; set; }
   
    public string Email { set; get; }
    public string Name { set; get; }
    [JsonPropertyName("poster_path")]
    public string? Poster { get; set; }
    [JsonPropertyName("backdrop_path")]
    public string? Backdrop { get; set; }
    [JsonPropertyName("media")]
    public Media[]? Media { set; get; }
    public bool IsPublic { set; get; }
    
}