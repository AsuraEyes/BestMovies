using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class TV : Media
{
    [JsonPropertyName("first_air_date")]
    public DateTime Premier { set; get; }
    [JsonPropertyName("last_air_date")]
    public DateTime Finale { set; get; }
}