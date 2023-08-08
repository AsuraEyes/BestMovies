using MongoDB.Bson;
using MovieServer.Models;

namespace MovieServer.MiddlePoints;

public interface ICollectionMiddlePoint
{
    Task<MovieCollection> GetMovieCollectionAsync(int id);
    Task CreateCollectionAsync(Collection collection);
    Task<IList<Collection>> GetUserCollectionsAsync(string email);
    Task<Collection> GetCollectionAsync(ObjectId id);
}