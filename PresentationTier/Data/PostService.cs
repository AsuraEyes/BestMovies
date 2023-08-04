using System.Text;
using PresentationTier.Models;
using Newtonsoft.Json;

namespace PresentationTier.Data
{
    public class PostService : IPostService
    {
        private readonly HttpClient client;

        public PostService()
        {
            client = new HttpClient();
        }

        // API endpoints
        //  private const string uri = "https://newbestmoviesapi.azurewebsites.net";
        private const string uri = "https://localhost:7254";

        // Save a new post
        public async Task SavePost(Post post)
        {
            try
            {
                var postAsJson = JsonConvert.SerializeObject(post);

                // Retrieve the logged-in user's email using the CustomAuthenticationStateProvider
                var email = GetLoggedInUserEmail();


                var username = GetLoggedInUserUsername();

                // Modify the post object to include the logged-in user's email
                post.PostedBy = username;

                var content = new StringContent(postAsJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{uri}/CreatePost", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Post>(responseContent);

                }
                else
                {
                    throw new Exception($"Failed to save the post. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the post.", ex);
            }
        }

        // Get all posts
        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                var response = await client.GetAsync($"{uri}/GetAllPosts");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<Post>>(content);
                    return posts;
                }
                else
                {
                    throw new Exception($"Failed to retrieve posts. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving posts.", ex);
            }
        }

        // Get the email of the currently logged-in user
        private string GetLoggedInUserEmail()
        {
            // Get the authentication state using the CustomAuthenticationStateProvider
            //var authState = authenticationStateProvider.GetAuthenticationStateAsync().Result;

            // Retrieve the user's email from the authentication state
            string email = "authState.User.FindFirstValue(ClaimTypes.Email)";

            return email;
        }

        // Get the username of the currently logged-in user
        private string GetLoggedInUserUsername()
        {
            // Get the authentication state using the CustomAuthenticationStateProvider
            //var authState = authenticationStateProvider.GetAuthenticationStateAsync().Result;

            // Retrieve the user's email from the authentication state
            string username = "authState.User.FindFirstValue(ClaimTypes.Username)";

            return username;
        }

        // Like a post
        public async Task LikePost(Post post, string userId)
        {
            // Check if the user has already liked the post
            if (post.LikedByUsers != null && post.LikedByUsers.Contains(userId))
            {
                // User has already liked the post, remove the like
                post.LikedByUsers.Remove(userId);
                post.NumberOfLikes--;
            }
            else
            {
                // User hasn't liked the post, remove the dislike (if exists) and add the like
                if (post.DisLikedByUsers != null && post.DisLikedByUsers.Contains(userId))
                {
                    post.DisLikedByUsers.Remove(userId);
                    post.NumberOfDislikes--;
                }

                // Add the user ID to the LikedByUsers collection
                if (post.LikedByUsers == null)
                {
                    post.LikedByUsers = new List<string>();
                }
                post.LikedByUsers.Add(userId);
                post.NumberOfLikes++;
            }

            // Update the post in the database
            await UpdatePostAsync(post);
        }

        // Dislike a post
        public async Task DisLikePost(Post post, string userId)
        {
            // Check if the user has already disliked the post
            if (post.DisLikedByUsers != null && post.DisLikedByUsers.Contains(userId))
            {
                // User has already disliked the post, remove the dislike
                post.DisLikedByUsers.Remove(userId);
                post.NumberOfDislikes--;
            }
            else
            {
                // User hasn't disliked the post, remove the like (if exists) and add the dislike
                if (post.LikedByUsers != null && post.LikedByUsers.Contains(userId))
                {
                    post.LikedByUsers.Remove(userId);
                    post.NumberOfLikes--;
                }

                // Add the user ID to the DisLikedByUsers collection
                if (post.DisLikedByUsers == null)
                {
                    post.DisLikedByUsers = new List<string>();
                }
                post.DisLikedByUsers.Add(userId);
                post.NumberOfDislikes++;
            }

            // Update the post in the database
            await UpdatePostAsync(post);
        }

        // Update a post
        public async Task UpdatePostAsync(Post post)
        {
            try
            {
                // Create a JSON object representing the post data including LikedByUsers and DisLikedByUsers properties
                var postData = new
                {
                    post.NumberOfLikes,
                    post.NumberOfDislikes,
                    LikedByUsers = post.LikedByUsers ?? new List<string>(),
                    DisLikedByUsers = post.DisLikedByUsers ?? new List<string>()
                };

                // Serialize the post data to JSON
                var jsonData = JsonConvert.SerializeObject(postData);

                // Create the request content with the JSON data
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send a PUT request to update the post
                var response = await client.PostAsync($"{uri}/UpdatePost/{post.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to update the post. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the post.", ex);
            }
        }



        //Get post by id

        //public async Task getPostByIdAsync(string email)
        //{

        //}
    }
}
