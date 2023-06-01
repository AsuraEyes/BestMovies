using PresentationTier.Models;

namespace PresentationTier.Data;

public interface ICollectionService
{
    Task<MovieCollection> GetMovieCollectionAsync(int id);
}