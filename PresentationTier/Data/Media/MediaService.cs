using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class MediaService : IMediaService
{
    private readonly HttpClient client;
    private const string uri = "https://localhost:7254/Trending";

    public MediaService()
    {
        client = new HttpClient();
    }

    public async Task<MediaList> GetTrendingAsync()
    {
        var mediaString = await client.GetStringAsync(uri);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
}