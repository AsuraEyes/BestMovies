using System;
using System.Text.Json.Serialization;

public class TV : Media
{
    [JsonPropertyName("first_air_date")]
    public DateTime Premiere { set; get; }
    [JsonPropertyName("last_air_date")]
    public DateTime Finale { set; get; }
}