using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace PresentationTier.Models;

public class Review
{
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public int Score { get; set; }
    public string Description { get; set; }
    public bool IsSpoiler { get; set; }
    public DateTime Created { get; } = DateTime.Now;
    public DateTime? Edited { get; set; }
    public string Email { get; set; }
    public int MediaId { get; set; }
    public string Username { get; set; }

    public Review()
    {
        Id = ObjectId.GenerateNewId();
    }
}