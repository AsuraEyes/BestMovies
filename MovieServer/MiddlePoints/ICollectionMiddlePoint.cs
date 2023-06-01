using MovieServer.Models;

namespace MovieServer.MiddlePoints;

public interface ICollectionMiddlePoint
{
    Task<MovieCollection> GetMovieCollectionAsync(int id);
    Task<string> CreateCollectionAsync(UserCollection collection);
    Task<IList<UserCollection>> GetUserCollectionsAsync(string email);
    Task<UserCollection> GetCollectionAsync(string id);
    Task<string> CreateFavoritesAsync(string email);
    Task<string> CreateWatchListAsync(string email);
}