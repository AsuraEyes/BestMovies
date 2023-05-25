using MongoDB.Bson;
using MovieServer.Data;
using MovieServer.Data.Media;
using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints;

public class CollectionMiddlePoint : ICollectionMiddlePoint
{
    private readonly ICollectionService collectionService;
    private readonly ICollectionRepository collectionRepository;
    private readonly IMovieService movieService;
    private const string Image = "https://image.tmdb.org/t/p/original";

    public CollectionMiddlePoint(ICollectionService collectionService, IMovieService movieService, ICollectionRepository collectionRepository)
    {
        this.collectionService = collectionService;
        this.movieService = movieService;
        this.collectionRepository = collectionRepository;
    }

    public async Task<MovieCollection> GetMovieCollectionAsync(int id)
    {
        var collection = await collectionService.GetMovieCollectionAsync(id);

        collection.Poster = SetImage(collection.Poster);
        collection.Backdrop = SetImage(collection.Backdrop);
        collection.Movies = SetMedia(collection.Movies);
        collection.Revenue = await GetRevenueAsync(collection.Movies);
        
        return collection;
    }

    public async Task<string> CreateCollectionAsync(UserCollection collection)
    {
        var collectionId = await collectionRepository.CreateCollectionAsync(collection);
        return collectionId;
    }

    public async Task<IList<UserCollection>> GetUserCollectionsAsync(string email)
    {
        var collection = await collectionRepository.GetUserCollectionsAsync(email);
        return collection;
    }

    public async Task<UserCollection> GetCollectionAsync(string collectionId)
    {
        var id = ObjectId.Parse(collectionId);
        var collection = await collectionRepository.GetCollectionAsync(id);
        return collection;
    }
    
    private static string SetImage(string img)
    {
        return Image + img;
    }
    
    private static Movie[] SetMedia(Movie[] media)
    {
        foreach (var movie in media)
        {
            var p = Image + movie.Poster;
            var b = Image + movie.Backdrop;
            movie.Poster = p;
            movie.Backdrop = b;
        }
        
        return media;
    }

    private async Task<int> GetRevenueAsync(IEnumerable<Movie> media)
    {
        var revenue = 0;
        foreach (var movie in media)
        {
            var movieAsync = await movieService.GetMovieAsync(movie.Id);
            revenue += movieAsync.Revenue;
        }

        return revenue;
    }

    public async Task<string> CreateFavoritesAsync(string email)
    {
        var favorites = new UserCollection
        {
            Email = email,
            Name = "Favorites"
        };
        var collectionId = await CreateCollectionAsync(favorites);
        return collectionId;
    }
    
    public async Task<string> CreateWatchListAsync(string email)
    {
        var watchList = new UserCollection
        {
            Email = email,
            Name = "WatchList"
        };
        var collectionId = await CreateCollectionAsync(watchList);
        return collectionId;
    }
}