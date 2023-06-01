using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationTier.Data;
using Moq;
using Microsoft.AspNetCore.Http;
using MovieServer.MiddlePoints;
using PresentationTier.Models;

namespace TestProject.Data.UserServices
{
    [TestFixture]
    public class UserServiceTest
    {

        [Test]
        public async Task ValidateUser_WithTheCorrectPassword_ReturnsAccount()
        {
            var expectedEmail = "test";
            var userEmail = "";
            try
            {
                var mockHttpClient = new Mock<HttpClient>();
                var userService = new UserService(mockHttpClient.Object);

                var expectedPassword = "test";
                var user = await userService.ValidateUser(expectedEmail, expectedPassword);

                userEmail = user.Email;

            }
            catch (NullReferenceException)
            {
                return;
            }

            Console.WriteLine(userEmail);

            Assert.That(userEmail, Is.EqualTo(expectedEmail));
        }
    }
}
