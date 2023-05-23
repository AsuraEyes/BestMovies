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
    public DateTime Created { get; set; }
    [BsonElement("edited")]
    public DateTime Edited { get; set; }
    [BsonElement("count")]
    public int Count { set; get; }
    [BsonElement("number_of_likes")]
    public int NumberOfLikes { set; get; }
    [BsonElement("user")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }
    [BsonElement("media")]
    public int MediaId { get; set; }
    [BsonElement("users")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string[] LikedUsers { set; get; }
}