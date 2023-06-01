using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MovieServer.Models;

public class UserCollection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("email")]
    public string Email { set; get; }
    [BsonElement("name")]
    public string Name { set; get; }
    [BsonElement("poster")]
    public string Poster { get; set; }
    [BsonElement("backdrop")]
    public string Backdrop { get; set; }
    [BsonElement("media")]
    public Media[] Media { set; get; }
    [BsonElement("is_public")]
    public bool IsPublic { set; get; }
}