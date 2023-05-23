using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class MediaService : IMediaService
{
    private readonly HttpClient client;
    private const string uri = "https://bmtest.azurewebsites.net/Trending";

    public MediaService()
    {
        client = new HttpClient();
    }

    public async Task<Models.Media[]> GetTrendingAsync()
    {
        var mediaString = await client.GetStringAsync(uri);
        var media = JsonSerializer.Deserialize<Models.Media[]>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
}