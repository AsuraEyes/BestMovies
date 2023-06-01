using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface IMovieService
{
    Task<Movie> GetMovieAsync(int id);
    Task<MediaList> GetMoviesAsync(int page);
    Task<MediaList> GetMoviesAsync(string query, int page);
    Task<Models.Media[]> GetRecommendedAsync(int id);
    Task<Models.Media[]> GetSimilarAsync(int id);
}