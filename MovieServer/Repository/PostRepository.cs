﻿using MongoDB.Driver;
using MovieServer.Models;
using MovieServer.MiddlePoints;
using MongoDB.Bson;

namespace MovieServer.Repository
{
    public class PostRepository : IPostRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Post> posts;

        // Connection string to the MongoDB database
        private const string Connection = "mongodb://newbestmoviesv2:Jo7mRI46lGNRZN28rJxOAArrOGo8RySauO9udMUB9I32z8Zq9WQPNhKGLsiRMZc2EVAyVJZg8J4eACDbkgeadg==@newbestmoviesv2.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmoviesv2@";

        public PostRepository()
        {
            client = new MongoClient(Connection);
            database = client.GetDatabase("best_movies");
            posts = database.GetCollection<Post>("posts");
        }

        // Create a new post by inserting it into the posts collection
        public async Task CreatePostAsync(Post post)
        {
            await posts.InsertOneAsync(post);
        }

        // Retrieve all posts from the posts collection
        public async Task<List<Post>> GetAllPostsAsync()
        {
            var filter = Builders<Post>.Filter.Empty;
            var posts = await this.posts.Find(filter).ToListAsync();
            foreach (var post in posts)
            {
                Console.WriteLine(post);
            }
            return posts;
        }

        // Update a post by finding it based on the postId and updating its NumberOfLikes
        public async Task UpdatePostAsync(Post post)
        {
            var filter = Builders<Post>.Filter.Where(x => x.Id == post.Id);
            var update = Builders<Post>.Update
                .Set(p => p.NumberOfLikes, post.NumberOfLikes)
                .Set(p => p.LikedByUsers, post.LikedByUsers)
                .Set(p => p.DisLikedByUsers, post.DisLikedByUsers);

            await posts.UpdateOneAsync(filter, update);
        }


        // Retrieve a post by its postId
        public async Task<Post> GetPostByIdAsync(string postId)
        {
            if (!ObjectId.TryParse(postId, out ObjectId objectId))
            {
                return null;
            }

            var filter = Builders<Post>.Filter.Eq("_id", objectId);
            return await posts.Find(filter).FirstOrDefaultAsync();
        }



    }
}
