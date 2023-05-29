using MongoDB.Driver;
using MovieServer.Models;
using MovieServer.MiddlePoints;

namespace MovieServer.Repository
{
    public class PostRepository : IPostRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Post> posts;

        private const string Connection = "mongodb://bestmovies:T7kEN4N9rFiyO3NxiO2n70eibqRSXrThkxvAUpOhy9490QKnrpS58hkYKoPKwZJJkqEXfLdBxgnPACDbEJUVRg==@bestmovies.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@bestmovies@";

        public PostRepository()
        {
            client = new MongoClient(Connection);
            database = client.GetDatabase("best_movies");
            posts = database.GetCollection<Post>("posts");
        }

        public async Task CreatePostAsync(Post post)
        {
            await posts.InsertOneAsync(post);
        }
    }
}
