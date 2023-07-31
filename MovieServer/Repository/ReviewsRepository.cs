using MongoDB.Bson;
using MongoDB.Driver;
using MovieServer.Models;

namespace MovieServer.DAO;

public class ReviewsRepository : IReviewsRepository
{
    private IMongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Review> reviews;

   // private const string Connection = "mongodb://bestmovies:T7kEN4N9rFiyO3NxiO2n70eibqRSXrThkxvAUpOhy9490QKnrpS58hkYKoPKwZJJkqEXfLdBxgnPACDbEJUVRg==@bestmovies.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@bestmovies@";
    private const string Connection = "mongodb://localhost:27017";

    public ReviewsRepository()
    {
        client = new MongoClient(Connection);
        database = client.GetDatabase("best_movies");
        reviews = database.GetCollection<Review>("reviews");
    }

    public async Task CreateReviewAsync(Review review)
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