using System.Text.Json.Serialization;

namespace MovieServer.Models;

public class MediaList
{
    public int Page { set; get; }
    [JsonPropertyName("results")]
    public Media[] ListOfMedia { set; get; }

    public MediaList()
    {
        ListOfMedia = new Media[]{};
    }
}