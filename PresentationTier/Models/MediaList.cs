using System.Text.Json.Serialization;

namespace PresentationTier.Models;

public class MediaList
{
    public int Page { set; get; }
    [JsonPropertyName("results")]
    public Media[] ListOfMedia { set; get; }
    [JsonPropertyName("total_pages")]
    public int TotalPages { set; get; }
    [JsonPropertyName("total_results")]
    public int TotalResults { set; get; }

    public MediaList()
    {
        ListOfMedia = new Media[]{};
    }
}