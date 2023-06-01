using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface IMovieMiddlePoint
{
    Task<Movie> GetMovieAsync(int id);
    Task<MediaList> GetMoviesAsync(int page);
    Task<MediaList> GetMoviesAsync(string query, int page);
    Task<Models.Media[]> GetRecommendedAsync(int id);
    Task<Models.Media[]> GetSimilarAsync(int id);
}