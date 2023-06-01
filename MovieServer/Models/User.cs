using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MovieServer.Models;

public class User
{
    [BsonId]
    public string Email{ get; set; }
    [BsonElement("password")]
    public string Password{ get; set; }
    [BsonElement("username")]
    public string Username{ get; set; }
    [BsonElement("role")]
    public string Role{ get; set; }
    [BsonElement("name")]
    public string Name{ get; set; }
    [BsonElement("country_code")]
    public int CountryCallingCode { get; set; }
    [BsonElement("phone_number")]
    public int PhoneNumber{ get; set; }
    [BsonElement("profile")]
    public string Profile { get; set; }
    [BsonElement("backdrop")]
    public string Backdrop { get; set; }
    [BsonElement("date_joined")]
    public DateTime Joined { get; set; }
    [BsonElement("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
}