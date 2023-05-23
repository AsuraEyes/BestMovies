using System.Text.Json.Serialization;


public class Videos
{
    [JsonPropertyName("results")]
    public Video[] VideoList { get; set; }

    public Videos()
    {
        VideoList = new Video[]{};
    }
}