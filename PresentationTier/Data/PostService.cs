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
        private const string uri = "https://localhost:7254";
        private const string apiUrl = "https://localhost:7254"; 

        public async Task SavePost(Post post)
        {
            var postAsJson = JsonSerializer.Serialize(post);
            HttpContent content = new StringContent(postAsJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{apiUrl}/CreatePost", content);
            //var test = JsonSerializer.Deserialize<Post>(postAsJson, new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //});
            //await client.PostAsync(uri + "/CreatePost", content);
            //Console.WriteLine(postAsJson);
        }
    }
}
