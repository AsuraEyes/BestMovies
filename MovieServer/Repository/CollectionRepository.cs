using MongoDB.Bson;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository;

public class CollectionRepository : ICollectionRepository
{
    private readonly IMongoClient client;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<Collection> collections;

    private const string Connection = "mongodb://newbestmovies:8EKEyY9fkFENBYGXvlwj58ln5AxDnLDqB1y9z5T6WGkCyNQpmRF2aiSPe3mT0GTjOAbCtpQrHCB2ACDbUwDkMg==@newbestmovies.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmovies@";

    public CollectionRepository()
    {
        client = new MongoClient(Connection);
        database = client.GetDatabase("best_movies");
        collections = database.GetCollection<Collection>("collections");
    }

    public async Task CreateCollectionAsync(Collection collection)
    {
        await collections.InsertOneAsync(collection);
    }

    public async Task<IList<Collection>> GetUserCollectionsAsync(string email)
    {
        var filter = Builders<Collection>.Filter.Eq("email", email);
        var results = await collections.Find(filter).ToListAsync();

        return results;
    }

    public async Task<Collection> GetCollectionAsync(string email, int id)
    {
        var filter = Builders<Collection>.Filter.Eq("email", email) 
                     & Builders<Collection>.Filter.Eq("id", id);
        var results = await collections.Find(filter).FirstOrDefaultAsync();

        return results;
    }
}