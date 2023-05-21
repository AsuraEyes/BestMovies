using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface IMovieMiddlePoint
{
    Task<Movie> GetMovieAsync(int id);
}