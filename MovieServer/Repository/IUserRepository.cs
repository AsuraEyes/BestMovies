using MovieServer.Models;

namespace MovieServer.Repository;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<User> GetUserAsync(string email);

    Task UpdateUserAsync(User user);
}