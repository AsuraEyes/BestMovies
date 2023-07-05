using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class MovieService : IMovieService
{
    private readonly HttpClient client;
    private const string uri = "https://newbestmoviesapi.azurewebsites.net/";

    public MovieService()
    {
        client = new HttpClient();
    }

    public async Task<Movie> GetMovieAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri+$"Movie/{id}");
        var movie = JsonSerializer.Deserialize<Movie>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return movie;
    }
    
    public async Task<MediaList> GetMoviesAsync(int page)
    {
        var mediaString = await client.GetStringAsync(uri+$"Movies?page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
    
    public async Task<MediaList> GetMoviesAsync(string query, int page)
    {
        var mediaString = await client.GetStringAsync(uri+$"SearchMovies?query={query}&page={page}");
        var media = JsonSerializer.Deserialize<MediaList>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
    
    public async Task<Models.Media[]> GetRecommendedAsync(int id)
    {
        var mediaString = await client.GetStringAsync(uri+$"Movie/{id}/Recommended");
        var media = JsonSerializer.Deserialize<Models.Media[]>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
    
    public async Task<Models.Media[]> GetSimilarAsync(int id)
    {
        var mediaString = await client.GetStringAsync(uri+$"Movie/{id}/Similar");
        var media = JsonSerializer.Deserialize<Models.Media[]>(mediaString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return media;
    }
}