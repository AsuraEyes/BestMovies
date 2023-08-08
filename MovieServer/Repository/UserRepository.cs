using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository
{
    public class UserRepository : IUserRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<User> users;

        // Connection string to the MongoDB database
       // private const string Connection = "mongodb://newbestmoviesv2:Jo7mRI46lGNRZN28rJxOAArrOGo8RySauO9udMUB9I32z8Zq9WQPNhKGLsiRMZc2EVAyVJZg8J4eACDbkgeadg==@newbestmoviesv2.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmoviesv2@";
        private const string Connection = "mongodb://localhost:27017/";
        public UserRepository()
        {
            client = new MongoClient(Connection);
            database = client.GetDatabase("best_movies");
            users = database.GetCollection<User>("users");
        }

        // Create a new user in the database
        public async Task CreateUserAsync(User user)
        {
            await users.InsertOneAsync(user);
        }

        // Update an existing user in the database
        public async Task UpdateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq("email", user.Email);
            var update = Builders<User>.Update
                .Set(u => u.Password, user.Password)
                .Set(u => u.Username, user.Username)
                .Set(u => u.Name, user.Name)
                .Set(u => u.CountryCallingCode, user.CountryCallingCode)
                .Set(u => u.PhoneNumber, user.PhoneNumber)
                .Set(u => u.Profile, user.Profile)
                .Set(u => u.Backdrop, user.Backdrop)
                .Set(u => u.DateOfBirth, user.DateOfBirth);

            await users.UpdateOneAsync(filter, update);
        }

        // Retrieve a user from the database based on their email
        public async Task<User> GetUserAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq("email", email);
            var results = await users.Find(filter).FirstOrDefaultAsync();

            return results;
        }
    }
}
