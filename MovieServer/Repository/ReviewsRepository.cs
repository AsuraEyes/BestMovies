using MongoDB.Bson;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.DAO;

public class ReviewsRepository : IReviewsRepository
{
    private IMongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Review> reviews;

    private const string Connection = "mongodb://newbestmovies:B48gCrdEoKZ6qoDtvsGCVZ1s4aG86BerK9IagWEXvFEyFj4qOGqT8PZeXMSWYNtOHGUNJKp1wtY6ACDbDYb9rg==@newbestmovies.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@newbestmovies@";

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

    public async Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId)
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