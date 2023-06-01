using System.Text.Json;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public class PersonService : IPersonService
{
    private readonly HttpClient client;
    private const string uri = "https://localhost:7254/Person";
    
    public PersonService()
    {
        client = new HttpClient();
    }
    
    public async Task<Person> GetPersonAsync(int id)
    {
        var personString = await client.GetStringAsync(uri+$"/{id}");
        var person = JsonSerializer.Deserialize<Person>(personString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return person;
    }
}