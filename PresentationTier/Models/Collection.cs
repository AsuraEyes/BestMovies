using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PresentationTier.Models;

public class Collection
{
    [BsonId]
    public ObjectId _id { set; get; }
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
    
    public Collection()
    {
        _id = ObjectId.GenerateNewId();
    }
}