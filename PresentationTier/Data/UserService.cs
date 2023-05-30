using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PresentationTier.Models;
using PresentationTier.Data;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using MovieServer.MiddlePoints;

namespace PresentationTier.Data;

public class UserService:IUserService
{
    private readonly HttpClient client;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IUserMiddlePoint userMiddlePoint;



    private const string uri1 = "https://bestmoviesapi.azurewebsites.net";
    private const string uri = "https://localhost:7254";


    public UserService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IUserMiddlePoint userMiddlePoint)
    {
        client = httpClient;
        this.httpContextAccessor = httpContextAccessor;
        this.userMiddlePoint = userMiddlePoint;
    }

    public async Task<User> ValidateUser(string email, string password)
    {
      //  Console.WriteLine("Test 1 Email: " + email + "\nPassword: " + password);
        var userString = await client.GetStringAsync(uri + $"/Login?email={email}&password={password}");
        var user = JsonSerializer.Deserialize<User>(userString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
       // Console.WriteLine("Test 2 Email: " + user.Email + "\nPassword: " + user.Password);
        return user;
    }

    public async Task SaveAccount(User user, IBrowserFile profileImage, IBrowserFile backdropImage)
    {
        if (profileImage != null)
        {
            // Convert profile image to byte array
            using (var memoryStream = new MemoryStream())
            {
                await profileImage.OpenReadStream().CopyToAsync(memoryStream);
                user.Profile = memoryStream.ToArray();
            }
        }

        if (backdropImage != null)
        {
            // Convert backdrop image to byte array
            using (var memoryStream = new MemoryStream())
            {
                await backdropImage.OpenReadStream().CopyToAsync(memoryStream);
                user.Backdrop = memoryStream.ToArray();
            }
        }
        user.Role = "Reviewer";
        Console.WriteLine(uri);
        var userAsJson = JsonSerializer.Serialize(user);
        HttpContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");
        var test = JsonSerializer.Deserialize<User>(userAsJson, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        await client.PostAsync(uri + "/Register", content);
        Console.WriteLine(userAsJson);

    }


    public async Task EditUser(User user)
    {
        // Perform any necessary validation or business logic checks

        try
        {
            // Update the user in the database using the repository
            //await userMiddlePoint.UpdateUserAsync(user);
        }
        catch (Exception ex)
        {
            // Handle any exceptions or errors that occur during the update process
            Console.WriteLine($"Error updating user: {ex.Message}");
            throw; // Optionally, you can handle the exception and return a specific error message or result
        }
    }

    public async Task<User> GetLoggedInUser(string userEmail)
    {
        if (!string.IsNullOrEmpty(userEmail))
        {
            var user = await userMiddlePoint.GetUserAsync(userEmail);
           // return user;
        }

        // If userEmail is empty or null, you may want to handle that case accordingly.
        // For now, let's return a default User object or create a new instance.
        return new User();
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