namespace PresentationTier.Data
{
    using Microsoft.AspNetCore.Components.Forms;
    using MovieServer.Models;
    using PresentationTier.Models;
    public interface IUserService
    {
        Task<UserModel> ValidateUser(string email, string password);
        Task SaveAccount(User user, IBrowserFile profileImage, IBrowserFile backdropImage);
        Task EditUser(User user);
        Task<User> GetLoggedInUser(string userEmail);
    }
}