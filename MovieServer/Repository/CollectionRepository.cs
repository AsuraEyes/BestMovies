using MongoDB.Bson;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository;

public class CollectionRepository : ICollectionRepository
{
    private readonly IMongoClient client;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<Collection> collections;

    private const string Connection = "mongodb://newbestmoviesv2:Jo7mRI46lGNRZN28rJxOAArrOGo8RySauO9udMUB9I32z8Zq9WQPNhKGLsiRMZc2EVAyVJZg8J4eACDbkgeadg==@newbestmoviesv2.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmoviesv2@";

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
        var filter = Builders<Collection>.Filter.Eq("Email", email);
        var results = await collections.Find(filter).ToListAsync();

        return results;
    }

    public async Task<Collection> GetCollectionAsync(ObjectId id)
    {
        var filter = Builders<Collection>.Filter.Eq("_id", id);
        var results = await collections.Find(filter).FirstOrDefaultAsync();

        return results;
    }
}