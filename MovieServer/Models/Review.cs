using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MovieServer.Models;

public class Review
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("title")]
    public string Title { get; set; }
    [BsonElement("rating")]
    public double Rating { get; set; }
    [BsonElement("description")]
    public string Description { get; set; }
    [BsonElement("is_spoiler")]
    public bool IsSpoiler { get; set; }
    [BsonElement("created")]
    public DateTime Created { get; } = DateTime.Now;
    [BsonElement("edited")]
    public DateTime Edited { get; set; }
    [BsonElement("user")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }
    [BsonElement("media")]
    public int MediaId { get; set; }
}