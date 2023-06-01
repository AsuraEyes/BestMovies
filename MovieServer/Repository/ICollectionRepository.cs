using MongoDB.Bson;
using MovieServer.Models;

namespace MovieServer.Repository;

public interface ICollectionRepository
{ 
    Task<string> CreateCollectionAsync(UserCollection collection);
    Task<IList<UserCollection>> GetUserCollectionsAsync(string email);
    Task<UserCollection> GetCollectionAsync(ObjectId id);
}