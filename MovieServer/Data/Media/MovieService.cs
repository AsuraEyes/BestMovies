using System.Text.Json;
using MovieServer.Models;

namespace MovieServer.Data.Media;

public class MovieService : IMovieService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3/movie";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13&append_to_response=videos,credits";

    public MovieService()
    {
        client = new HttpClient();
    }

    public async Task<Movie> GetMovieAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri+$"/{id}"+api_key);
        var movie = JsonSerializer.Deserialize<Movie>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return movie;
    }
}