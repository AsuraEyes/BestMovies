using System.Text.Json;
using MovieServer.Models;

namespace MovieServer.Data.Media;

public class MediaService : IMediaService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13";

    public MediaService()
    {
        client = new HttpClient();
    }

    public async Task<MediaList> GetTrendingAsync()
    {
        var mediaString = await client.GetStringAsync(uri+"/trending/all/day"+api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }
    
    public async Task<MediaList> GetMoviesAsync()
    {
        var mediaString = await client.GetStringAsync(uri + "/movie/now_playing" + api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }
    
    public async Task<MediaList> GetTVShowsAsync()
    {
        var mediaString = await client.GetStringAsync(uri + "/tv/airing_today" + api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }
}