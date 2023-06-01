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
using Newtonsoft.Json;

namespace PresentationTier.Data
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        private readonly IUserMiddlePoint userMiddlePoint;

        // API endpoints
        private const string uri1 = "https://bestmoviesapi.azurewebsites.net";
        private const string uri = "https://localhost:7254";

        public UserService(HttpClient httpClient, IUserMiddlePoint userMiddlePoint)
        {
            client = httpClient;
            this.userMiddlePoint = userMiddlePoint;
        }

        // Validate user credentials
        public async Task<User> ValidateUser(string email, string password)
        {
            var userString = await client.GetStringAsync(uri + $"/Login?email={email}&password={password}");
            var user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }

        // Save user account
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
            var userAsJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");
            var test = JsonConvert.DeserializeObject<User>(userAsJson);
            await client.PostAsync(uri + "/Register", content);
        }

        // Edit user details
        public async Task EditUser(User user)
        {
            try
            {
                //ToDo
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw;
            }
        }

        // Get logged-in user details
        public async Task<User> GetLoggedInUser(string email)
        {
            try
            {
                var response = await client.GetAsync($"{uri}/User/{email}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(content);
                    return user;
                }
                else
                {
                    throw new Exception($"Failed to retrieve the user. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the user.", ex);
            }
        }
    }
}
