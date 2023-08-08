using MongoDB.Bson;
using MovieServer.Models;

namespace MovieServer.Repository;

public interface ICollectionRepository
{ 
    Task CreateCollectionAsync(Collection collection);
    Task<IList<Collection>> GetUserCollectionsAsync(string email);
    Task<Collection> GetCollectionAsync(ObjectId id);
}