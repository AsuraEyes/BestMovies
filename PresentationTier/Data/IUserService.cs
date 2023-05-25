namespace PresentationTier.Data
{
    using PresentationTier.Models;
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        Task SaveAccount(User user);
    }
}