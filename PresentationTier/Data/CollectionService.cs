using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data;

public class CollectionService : ICollectionService
{
    private readonly HttpClient client;
    private const string uri = "https://newbestmoviesapi.azurewebsites.net/Collection";

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