using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PresentationTier.Models;
using MovieServer.Repository;
using PresentationTier.Data;
using MovieServer.Models;
using Newtonsoft.Json.Linq;
using MovieServer.Controllers;

namespace PresentationTier.Data;

public class UserService:IUserService
{
    private readonly HttpClient client;
    private const string uri = "https://bestmoviesapi.azurewebsites.net";
    private const string uri1 = "https://localhost:7254/Register";
    private readonly IUserRepository userRepository;

    public UserService(HttpClient httpClient, IUserRepository userRepository)
    {
        client = httpClient;
        this.userRepository = userRepository;
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

        user.Role = "Reviewer";
        var userJson = JsonSerializer.Serialize(user, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(userJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(uri1, content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            var errorMessage = ExtractErrorMessage(errorContent);

            // Log or print the complete error response content
            Console.WriteLine($"Error Response Content: {errorContent}");

            throw new Exception($"Failed to create user. Bad Request. Error: {errorMessage}");
        }
    }

    private string ExtractErrorMessage(string errorContent)
    {
        // Implement your custom logic to extract the error message from the errorContent
        // and return it as a string
        // You can use JSON deserialization or string manipulation depending on the structure of the error content

        // Example: assuming the error content is a JSON object with a "message" property
        var errorObj = JObject.Parse(errorContent);
        var errorMessage = errorObj["message"]?.ToString();

        return errorMessage ?? "Unknown error";
    }




}