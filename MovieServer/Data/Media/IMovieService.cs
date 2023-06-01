using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface IMovieService
{
    Task<Movie> GetMovieAsync(int id);
    Task<MediaList> GetRecommendedAsync(int id);
    Task<MediaList> GetSimilarAsync(int id);
    Task<MediaList> GetMoviesAsync(int page);
    Task<MediaList> GetMoviesAsync(string query, int page);
}