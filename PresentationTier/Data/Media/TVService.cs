using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class TVService : ITVService
{
    private readonly HttpClient client;
    private const string uri = "https://localhost:7254/TV";
    
    public TVService()
    {
        client = new HttpClient();
    }

    public async Task<TV> GetTVAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri + $"/{id}");
        var tv = JsonSerializer.Deserialize<TV>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        Console.WriteLine("img: "+tv.Poster);
        return tv;
    }
}