using System.Text.Json;
using System.Text;
using System;
using PresentationTier.Models;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;

namespace PresentationTier.Data
{
    public class PostService: IPostService
    {
        private readonly HttpClient client;
        private readonly IHttpContextAccessor httpContextAccessor;
        public PostService(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            client = httpClient;
            httpContextAccessor = accessor;
        }
        private const string uri1 = "https://bestmoviesapi.azurewebsites.net";
        private const string apiUrl = "https://localhost:7254";

        public async Task SavePost(Post post)
        {
            try
            {
                var postAsJson = JsonSerializer.Serialize(post);
                var content = new StringContent(postAsJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{apiUrl}/CreatePost", content);

                if (!response.IsSuccessStatusCode)
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
                    var posts = JsonSerializer.Deserialize<List<Post>>(content);
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"Post ID: {post.Id}, Content: {post.Content} FROM SERVICE");
                    }
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
    }
}
