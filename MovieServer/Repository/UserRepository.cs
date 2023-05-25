using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository;

public class UserRepository : IUserRepository
{
    private IMongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<User> users;

    private const string Connection = "mongodb://bestmovies:T7kEN4N9rFiyO3NxiO2n70eibqRSXrThkxvAUpOhy9490QKnrpS58hkYKoPKwZJJkqEXfLdBxgnPACDbEJUVRg==@bestmovies.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@bestmovies@";

    public UserRepository()
    {
        client = new MongoClient(Connection);
        database = client.GetDatabase("best_movies");
        users = database.GetCollection<User>("users");
    }


    public async Task CreateUserAsync(User user)
    {
        await users.InsertOneAsync(user);
    }

    public async Task<User> GetUserAsync(string email)
    {
        var filter = Builders<User>.Filter.Eq("_id", email);
        var results = await users.Find(filter).FirstOrDefaultAsync();

        return results;
    }
}