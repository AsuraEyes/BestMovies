using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class TVService : ITVService
{
    private readonly HttpClient client;
    private const string uri = "https://newbestmoviesapi.azurewebsites.net/TV";
    
    public TVService()
    {
        client = new HttpClient();
    }

    public async Task<TV> GetTVAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri + $"/{id}");
        var tv = JsonSerializer.Deserialize<TV>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return tv;
    }
    
    public async Task<MediaList> GetTVShowsAsync(int page)
    {
        var mediaString = await client.GetStringAsync(uri+$"Search?page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
    
    public async Task<MediaList> GetTVShowsAsync(string query, int page)
    {
        var mediaString = await client.GetStringAsync(uri+$"Search?query={query}&page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
}