using System.Text.Json;
using MovieServer.Models;

namespace MovieServer.Data.Media;

public class PersonService : IPersonService
{
    private readonly HttpClient client;
    private const string uri = "https://api.themoviedb.org/3/person";
    private const string api_key = "?api_key=46d08791a04c0cf6ce4c24953337ad13";
    private const string append = "&append_to_response=combined_credits";
    
    public PersonService()
    {
        client = new HttpClient();
    }
    
    public async Task<Person> GetPersonAsync(int id)
    {
        var personString = await client.GetStringAsync(uri+$"/{id}"+api_key+append);
        var person = JsonSerializer.Deserialize<Person>(personString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return person;
    }
}