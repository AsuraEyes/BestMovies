using Microsoft.AspNetCore.Components.Forms;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        Task SaveAccount(User user, IBrowserFile profileImage, IBrowserFile backdropImage);
        Task<User> GetUserInfo(string userEmail);
    }
}