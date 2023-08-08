using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;


        // API endpoints
          private const string uri = "https://newbestmoviesapi.azurewebsites.net";

        public UserService()
        {
            client = new HttpClient();
        }

        // Validate user credentials
        public async Task<User> ValidateUser(string email, string password)
        {
            var userString = await client.GetStringAsync(uri + $"/login?email={email}&password={password}");
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
            else
            {
                // Set profile image to null if not provided
                user.Profile = new byte[0];
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
            else
            {
                // Set backdrop image to null if not provided
                user.Backdrop = new byte[0];
            }

            user.Role = "Reviewer";
            var userAsJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/Register", content);
        }

        // Get logged-in user details
        public async Task<User> GetUserInfo(string email)
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

                throw new Exception($"Failed to retrieve the user. StatusCode: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the user.", ex);
            }
        }
    }
}
