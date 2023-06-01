using System.Text.Json;
using MovieServer.Models;

namespace MovieServer.Data.Media;

public class MovieService : IMovieService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3/";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13";
    private const string append = "&append_to_response=videos,credits";

    public MovieService()
    {
        client = new HttpClient();
    }

    public async Task<Movie> GetMovieAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri+$"movie/{id}"+api_key+append);
        var movie = JsonSerializer.Deserialize<Movie>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return movie;
    }
    
    public async Task<MediaList> GetRecommendedAsync(int id)
    {
        var mediaString = await client.GetStringAsync(uri+$"movie/{id}/recommendations"+api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }

    public async Task<MediaList> GetSimilarAsync(int id)
    {
        var mediaString = await client.GetStringAsync(uri+$"movie/{id}/similar"+api_key);
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }

    public async Task<MediaList> GetMoviesAsync(int page)
    {
        var mediaString = await client.GetStringAsync(uri + "movie/popular" + api_key + $"&page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }

    public async Task<MediaList> GetMoviesAsync(string query, int page)
    {
        var mediaString = await client.GetStringAsync(uri + "/search/movie" + api_key + $"&query={query}&page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media!;
    }
}