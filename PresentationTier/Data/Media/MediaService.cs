using System.Text.Json;

namespace PresentationTier.Data.Media;

public class MediaService : IMediaService
{
    private readonly HttpClient client;
    private const string uri = "https://newbestmoviesapi.azurewebsites.net/";

    public MediaService()
    {
        client = new HttpClient();
    }

    public async Task<Models.Media[]> GetTrendingAsync()
    {
        var mediaString = await client.GetStringAsync(uri+"Trending");
        var media = JsonSerializer.Deserialize<Models.Media[]>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
    
    public async Task<Models.Media[]> GetMoviesAsync()
    {
        var mediaString = await client.GetStringAsync(uri+"NowPlaying");
        var media = JsonSerializer.Deserialize<Models.Media[]>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
    
    public async Task<Models.Media[]> GetTVShowsAsync()
    {
        var mediaString = await client.GetStringAsync(uri+"AiringToday");
        var media = JsonSerializer.Deserialize<Models.Media[]>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
}