namespace PresentationTier.Data
{
    using Microsoft.AspNetCore.Components.Forms;
    using PresentationTier.Models;
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        Task SaveAccount(User user, IBrowserFile profileImage, IBrowserFile backdropImage);
        Task<User> GetUserInfo(string userEmail);
    }
}