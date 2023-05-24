using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class TVService : ITVService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3/tv";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13";
    
    public TVService()
    {
        client = new HttpClient();
    }

    public async Task<TV> GetTVAsync(int id)
    {
        var movieString = await client.GetStringAsync(uri + $"/{id}" + api_key);
        var tv = JsonSerializer.Deserialize<TV>(movieString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return tv;
    }
}