using System.Text.Json;
using System.Text;
using System;
using PresentationTier.Models;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Blazorise;
using PresentationTier.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Newtonsoft.Json;

namespace PresentationTier.Data
{
    public class PostService : IPostService
    {
        private readonly HttpClient client;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public PostService(HttpClient httpClient, IHttpContextAccessor accessor, AuthenticationStateProvider authStateProvider)
        {
            client = httpClient;
            httpContextAccessor = accessor;
            authenticationStateProvider = authStateProvider;
        }
        private const string uri1 = "https://bestmoviesapi.azurewebsites.net";
        private const string apiUrl = "https://localhost:7254";

        public async Task SavePost(Post post)
        {
            try
            {
                var postAsJson = JsonConvert.SerializeObject(post);

                // Retrieve the logged-in user's email using the CustomAuthenticationStateProvider
                string email = GetLoggedInUserEmail();

                // Modify the post object to include the logged-in user's email
                post.PostedBy = email;

                var content = new StringContent(postAsJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{apiUrl}/CreatePost", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var createdPost = JsonConvert.DeserializeObject<Post>(responseContent);

                    // Optionally, you can return the created post or perform any other actions

                    // Refresh the page using the NavigationManager
                }
                else
                {
                    // Handle the case when the request was not successful
                    // You can log the error or throw an exception if needed
                    throw new Exception($"Failed to save the post. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                // You can log the error or throw a custom exception if needed
                throw new Exception("An error occurred while saving the post.", ex);
            }
        }


        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                var response = await client.GetAsync($"{apiUrl}/GetAllPosts");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<Post>>(content);
                    return posts;
                }
                else
                {
                    // Handle the case when the request was not successful
                    // You can log the error or throw an exception if needed
                    throw new Exception($"Failed to retrieve posts. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                // You can log the error or throw a custom exception if needed
                throw new Exception("An error occurred while retrieving posts.", ex);
            }
        }



        private string GetLoggedInUserEmail()
        {
            // Get the authentication state using the CustomAuthenticationStateProvider
            var authState = authenticationStateProvider.GetAuthenticationStateAsync().Result;

            // Retrieve the user's email from the authentication state
            string email = authState.User.FindFirstValue(ClaimTypes.Email);

            return email;
        }
     
        public async Task LikePost(Post post)
        {
            try
            {
                // Perform the necessary operations to indicate that the post is liked
                post.NumberOfLikes++; // Increment the number of likes

                // Update the post on the server
                var content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{apiUrl}/UpdatePost/{post.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle the case when the request was not successful
                    // You can log the error or throw an exception if needed
                    throw new Exception($"Failed to update the post. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                // You can log the error or throw a custom exception if needed
                throw new Exception("An error occurred while liking the post.", ex);
            }
        }

        public async Task DislikePost(Post post)
        {
            try
            {
                // Perform the necessary operations to indicate that the post is disliked
                post.NumberOfLikes--; // Decrement the number of likes

                // Update the post on the server
                var content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{apiUrl}/UpdatePost/{post.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle the case when the request was not successful
                    // You can log the error or throw an exception if needed
                    throw new Exception($"Failed to update the post. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                // You can log the error or throw a custom exception if needed
                throw new Exception("An error occurred while disliking the post.", ex);
            }
        }
    }
}

