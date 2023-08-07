using MongoDB.Bson;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository;

public class CollectionRepository : ICollectionRepository
{
    private readonly IMongoClient client;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<UserCollection> userCollections;

    private const string Connection = "mongodb://newbestmovies:8EKEyY9fkFENBYGXvlwj58ln5AxDnLDqB1y9z5T6WGkCyNQpmRF2aiSPe3mT0GTjOAbCtpQrHCB2ACDbUwDkMg==@newbestmovies.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmovies@";

    public CollectionRepository()
    {
        client = new MongoClient(Connection);
        database = client.GetDatabase("best_movies");
        userCollections = database.GetCollection<UserCollection>("collections");
    }

    public async Task<string> CreateCollectionAsync(UserCollection collection)
    {
        await userCollections.InsertOneAsync(collection);
        return collection.Id;
    }

    public async Task<IList<UserCollection>> GetUserCollectionsAsync(string email)
    {
        var filter = Builders<UserCollection>.Filter.Eq("email", email);
        var results = await userCollections.Find(filter).ToListAsync();

        return results;
    }

    public async Task<UserCollection> GetCollectionAsync(ObjectId id)
    {
        var filter = Builders<UserCollection>.Filter.Eq("_id", id);
        var results = await userCollections.Find(filter).FirstOrDefaultAsync();

        return results;
    }
}