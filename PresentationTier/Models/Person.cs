using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime Birthday { get; set; }
    [JsonPropertyName("deathday")]
    public DateTime? DeathDay { get; set; }
    public int Gender { get; set; }
    [JsonPropertyName("profile_path")]
    public string Picture { get; set; }
    [JsonPropertyName("place_of_birth")]
    public string PlaceOfBirth { get; set; }
    public string Character { get; set; }
    public string Job { get; set; }
    public string Department { get; set; }
    [JsonPropertyName("combined_credits")]
    public MediaCredits MediaCredits { get; set; }
}