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
            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<IUserMiddlePoint> mockUserMiddlePoint = new Mock<IUserMiddlePoint>();
            UserService userService = new UserService(mockHttpClient.Object,mockUserMiddlePoint.Object);

            string expectedEmail = "testEmail";
            string expectedPassword = "testPassword";

            User user = await userService.ValidateUser(expectedEmail, expectedPassword);

            string actualPassword = user.Password;
            Assert.AreEqual(expectedEmail, actualPassword);
        }
    }
}
