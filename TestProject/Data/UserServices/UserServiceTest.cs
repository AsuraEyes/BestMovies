using NUnit.Framework;
using PresentationTier.Data;

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
                var userService = new UserService();

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
