using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface IMovieService
{
    Task<Movie> GetMovieAsync(int id);
    Task<Models.Media[]> GetRecommendedAsync(int id);
    Task<Models.Media[]> GetSimilarAsync(int id);
}