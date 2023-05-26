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
using Microsoft.AspNetCore.Components.Forms;

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

    public async Task SaveAccount(User user, IBrowserFile profileImage, IBrowserFile backdropImage)
    {
        // Set the role
        user.Role = "Reviewer";

        // Convert profile image to byte array
        using (var memoryStream = new MemoryStream())
        {
            await profileImage.OpenReadStream().CopyToAsync(memoryStream);
            user.ProfileImage = memoryStream.ToArray();
        }

        // Convert backdrop image to byte array
        using (var memoryStream = new MemoryStream())
        {
            await backdropImage.OpenReadStream().CopyToAsync(memoryStream);
            user.BackdropImage = memoryStream.ToArray();
        }

        await userRepository.CreateUserAsync(user);

        // Save the user to the database or perform any other required operations
        // Example: userRepository.SaveUser(user);
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