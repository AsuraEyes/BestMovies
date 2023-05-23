using System;
using System.Text.Json.Serialization;


public class Movie : Media
{
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
}