namespace PresentationTier.Data
{
    using PresentationTier.Models;
    public interface IUserService
    {
        User ValidateUser(string email, string password);
    }
}