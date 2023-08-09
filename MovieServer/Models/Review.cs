using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MovieServer.Models;

public class Review
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("title")]
    public string Title { get; set; }
    [BsonElement("rating")]
    public int Score { get; set; }
    [BsonElement("description")]
    public string Description { get; set; }
    [BsonElement("is_spoiler")]
    public bool IsSpoiler { get; set; }
    [BsonElement("created")]
    public DateTime Created { get; } = DateTime.Now;
    [BsonElement("edited")]
    public DateTime? Edited { get; set; }
    [BsonElement("user")]
    public string Email { get; set; }
    [BsonElement("media")]
    public int MediaId { get; set; }
    public string Username { get; set; }
}