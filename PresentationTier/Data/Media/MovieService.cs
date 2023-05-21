using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class MovieService : IMovieService
{
    private readonly HttpClient client;
    private const string uri = "https://localhost:7254/Movie";

    public MovieService()
    {
        client = new HttpClient();
    }

    public async Task<Movie> GetMovieAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri+$"/{id}");
        var movie = JsonSerializer.Deserialize<Movie>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        var cast = movie.Credits.Cast;
        foreach (var person in cast)
        {
            var image = "https://image.tmdb.org/t/p/original" + person.Picture;
            person.Picture = image;
        }
        return movie;
    }
}