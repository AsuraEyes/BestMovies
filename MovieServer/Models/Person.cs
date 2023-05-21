using System.Text.Json.Serialization;

namespace MovieServer.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime DeathDate { get; set; }
    public int Gender { get; set; }
    [JsonPropertyName("profile_path")]
    public string Picture { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Character { get; set; }
    public string Job { get; set; }
    public string Department { get; set; }
}