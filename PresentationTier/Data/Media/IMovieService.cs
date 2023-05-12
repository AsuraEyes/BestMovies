using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface IMovieService
{
    Task<Movie> GetMovieAsync(int id);
}