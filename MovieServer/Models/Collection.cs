using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using ThirdParty.Json.LitJson;

namespace MovieServer.Models;

public class Collection
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { set; get; }
    public int Id { set; get; }
    [BsonElement("user")]
    [BsonRepresentation(BsonType.ObjectId)]
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