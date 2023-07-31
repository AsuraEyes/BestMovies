using MongoDB.Bson;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository;

public class CollectionRepository : ICollectionRepository
{
    private readonly IMongoClient client;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<UserCollection> userCollections;

  //  private const string Connection = "mongodb://bestmovies:T7kEN4N9rFiyO3NxiO2n70eibqRSXrThkxvAUpOhy9490QKnrpS58hkYKoPKwZJJkqEXfLdBxgnPACDbEJUVRg==@bestmovies.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@bestmovies@";
    private const string Connection = "mongodb://localhost:27017";

    public CollectionRepository()
    {
        client = new MongoClient(Connection);
        database = client.GetDatabase("best_movies");
        userCollections = database.GetCollection<UserCollection>("user_collections");
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