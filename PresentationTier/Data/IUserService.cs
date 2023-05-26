namespace PresentationTier.Data
{
    using Microsoft.AspNetCore.Components.Forms;
    using MovieServer.Models;
    using PresentationTier.Models;
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        Task SaveAccount(User user, IBrowserFile profileImage, IBrowserFile backdropImage);
    }
}