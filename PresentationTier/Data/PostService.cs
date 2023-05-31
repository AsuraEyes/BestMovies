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
using MongoDB.Driver;
using PresentationTier.Pages;

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
                    throw new Exception($"Failed to retrieve posts. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
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


        public async Task LikePost(Post post, string userId)
        {
            // Initialize the LikedByUsers property if it is null
            if (post.LikedByUsers == null)
            {
                post.LikedByUsers = new List<string>();
            }

            // Check if the user has already liked the post
            if (post.LikedByUsers.Contains(userId))
            {
                // User has already liked the post, handle accordingly
                return;
            }

            // Add the user ID to the LikedByUsers collection
            post.LikedByUsers.Add(userId);

            // Increment the number of likes
            post.NumberOfLikes++;

            // Update the post in the database
            await UpdatePostAsync(post);
        }

        public async Task DisLikePost(Post post, string userId)
        {
            // Initialize the LikedByUsers property if it is null
            if (post.DisLikedByUsers == null)
            {
                post.DisLikedByUsers = new List<string>();
            }

            // Check if the user has already liked the post
            if (post.DisLikedByUsers.Contains(userId))
            {
                // User has already liked the post, handle accordingly
                return;
            }

            // Add the user ID to the LikedByUsers collection
            post.DisLikedByUsers.Add(userId);

            // Increment the number of likes
            post.NumberOfLikes--;

            // Update the post in the database
            await UpdatePostAsync(post);
        }

        public async Task UpdatePostAsync(Post post)
        {
            try
            {
                var content = new StringContent(post.NumberOfLikes.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{apiUrl}/UpdatePost/{post.Id}", content);

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


    }
}

