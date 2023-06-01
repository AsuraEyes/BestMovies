using Microsoft.AspNetCore.Components.Authorization;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PresentationTier.Data;
using PresentationTier.Models;
using Newtonsoft.Json;


namespace TestProject.Data.PostServices
{
    public class PostServiceTest
    {
        private Mock<HttpClient> _mockHttpClient;
        private Mock<AuthenticationStateProvider> _mockAuthStateProvider;
        private PostService _postService;
        private string ApiUrl = "https://localhost:7254";

        [SetUp]
        public void Setup()
        {
            _mockHttpClient = new Mock<HttpClient>();
            _mockAuthStateProvider = new Mock<AuthenticationStateProvider>();
            _postService = new PostService(_mockHttpClient.Object, _mockAuthStateProvider.Object);
        }

        [Test]
        public async Task SavePost_ValidPost_SendsPostRequest()
        {
            // Arrange
            var post = new Post { /* Initialize post properties */ };
            _mockAuthStateProvider.Setup(a => a.GetAuthenticationStateAsync())
                .ReturnsAsync(new AuthenticationState(new ClaimsPrincipal()));

            _mockHttpClient.Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<StringContent>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            // Act
            await _postService.SavePost(post);

            // Assert
            _mockHttpClient.Verify(c => c.PostAsync($"{ApiUrl}/CreatePost", It.IsAny<StringContent>()), Times.Once);
        }

        [Test]
        public async Task GetAllPosts_ReturnsListOfPosts()
        {
            // Arrange
            var expectedPosts = new List<Post> { /* Initialize expected posts */ };

            _mockHttpClient.Setup(c => c.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(expectedPosts))
                });

            // Act
            var posts = await _postService.GetAllPosts();

            // Assert
            Assert.NotNull(posts);
            Assert.AreEqual(expectedPosts.Count, posts.Count);
        }



        [Test]
        public async Task UpdatePostAsync_ValidPost_UpdatesThePost()
        {
            // Arrange
            var post = new Post { /* Initialize post properties */ };

            _mockHttpClient.Setup(c => c.PutAsync(It.IsAny<string>(), It.IsAny<StringContent>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            // Act
            await _postService.UpdatePostAsync(post);

            // Assert
            _mockHttpClient.Verify(c => c.PutAsync($"{ApiUrl}/UpdatePost/{post.Id}", It.IsAny<StringContent>()), Times.Once);
        }

    }
}
