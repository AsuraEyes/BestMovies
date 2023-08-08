using System.Text.Json;
using MovieServer.Models;

namespace MovieServer.Data.Media;

public class TVService : ITVService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13&append_to_response=videos,credits";
    
    public TVService()
    {
        client = new HttpClient();
    }

    public async Task<TV> GetTVAsync(int id)
    {
        var tvString = await client.GetStringAsync(uri + $"/tv/{id}" + api_key);
        var tv = JsonSerializer.Deserialize<TV>(tvString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return tv;
    }
    
    public async Task<MediaList> GetTVShowsAsync(int page)
    {
        var mediaString = await client.GetStringAsync(uri + "tv/popular" + api_key + $"&page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }
    
    public async Task<MediaList> GetTVShowsAsync(string query, int page)
    {
        var tvString = await client.GetStringAsync(uri + "/search/tv" + api_key + $"&query={query}&page={page}");
        var tv = JsonSerializer.Deserialize<MediaList>(tvString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return tv;
    }
    
    public async Task<MediaList> GetRecommendedAsync(int id)
    {
        var mediaString = await client.GetStringAsync(uri+$"tv/{id}/recommendations"+api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }

    public async Task<MediaList> GetSimilarAsync(int id)
    {
        var mediaString = await client.GetStringAsync(uri+$"tv/{id}/similar"+api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }
}