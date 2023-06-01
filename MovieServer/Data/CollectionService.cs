using System.Text.Json;
using MovieServer.Models;

namespace MovieServer.Data;

public class CollectionService : ICollectionService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3/collection";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13";

    public CollectionService()
    {
        client = new HttpClient();
    }

    public async Task<MovieCollection> GetMovieCollectionAsync(int id)
    {
        var collectionString = await client.GetStringAsync(uri+$"/{id}"+api_key);
        var collection = JsonSerializer.Deserialize<MovieCollection>(collectionString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return collection;
    }
}