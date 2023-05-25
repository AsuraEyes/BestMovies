using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using PresentationTier.Models;

namespace PresentationTier.Data;

public class UserService:IUserService
{
    private readonly HttpClient client;
    private const string uri = "https://bestmoviesapi.azurewebsites.net";
        
    public UserService()
    {
        client = new HttpClient();
    }

    public async Task<User> ValidateUser(string email, string password)
    {
        Console.WriteLine("Test 1 Email: " + email + "\nPassword: " + password);
        var userString = await client.GetStringAsync(uri + $"/Login?email={email}&password={password}");
        var user = JsonSerializer.Deserialize<User>(userString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        Console.WriteLine("Test 2 Email: " + user.Email + "\nPassword: " + user.Password);
        return user;
    }

    public async Task SaveAccount(User user)
    {
        var userJson = JsonSerializer.Serialize(user, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(userJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(uri + "/users", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to create user. Please try again.");
        }

    }



}