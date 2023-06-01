using MovieServer.Models;

namespace MovieServer.MiddlePoints;

public interface IUserMiddlePoint
{
    Task CreateUserAsync(User user);
    Task<User> ValidateUserAsync(string email, string password);
    Task UpdateUserAsync(User user);
    Task<User> GetUserAsync(string email);

}