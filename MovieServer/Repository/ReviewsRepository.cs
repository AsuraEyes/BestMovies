using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.Repository;

public class ReviewsRepository : IReviewsRepository
{
    private IMongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Review> reviews;

    private const string Connection = "mongodb://newbestmoviesv2:Jo7mRI46lGNRZN28rJxOAArrOGo8RySauO9udMUB9I32z8Zq9WQPNhKGLsiRMZc2EVAyVJZg8J4eACDbkgeadg==@newbestmoviesv2.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmoviesv2@";
    public ReviewsRepository()
    {
        client = new MongoClient(Connection);
        database = client.GetDatabase("best_movies");
        reviews = database.GetCollection<Review>("reviews");
    }

    public async Task WriteReviewAsync(Review review)
    {
        await reviews.InsertOneAsync(review);
    }

    public async Task<IList<Review>> GetAllReviewsAsync(int mediaId)
    {
        var filter = Builders<Review>.Filter.Eq("media", mediaId);
        var results = await reviews.Find(filter).ToListAsync();

        return results;
    }
    
    public async Task<IList<Review>> GetAllUserReviewsAsync(string email)
    {
        var filter = Builders<Review>.Filter.Eq("user", email);
        var results = await reviews.Find(filter).ToListAsync();

        return results;
    }
}