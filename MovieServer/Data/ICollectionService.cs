using MovieServer.Models;

namespace MovieServer.Data;

public interface ICollectionService
{
    Task<MovieCollection> GetMovieCollectionAsync(int id);
}