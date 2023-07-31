using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data;

public class CollectionService : ICollectionService
{
    private readonly HttpClient client;
    //private const string uri = "https://bestmoviesapi.azurewebsites.net/Collection";
    private const string uri = "https://localhost:7254";


    public CollectionService()
    {
        client = new HttpClient();
    }

    public async Task<MovieCollection> GetMovieCollectionAsync(int id)
    {
        var collectionString = await client.GetStringAsync(uri+$"/{id}");
        var collection = JsonSerializer.Deserialize<MovieCollection>(collectionString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return collection;
    }
}