using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints;

public class UserMiddlePoint : IUserMiddlePoint
{
    private readonly IUserRepository userRepository;
    private readonly ICollectionRepository collectionRepository;
    private const string Role = "Reviewer";


    public UserMiddlePoint(IUserRepository userRepository, ICollectionRepository collectionRepository)
    {
        this.userRepository = userRepository;
        this.collectionRepository = collectionRepository;
    }

    public async Task CreateUserAsync(User user)
    {
        await userRepository.CreateUserAsync(user);
        Console.WriteLine(user.Name);
    }

    public async Task UpdateUserAsync(User user)
    {
        await userRepository.UpdateUserAsync(user);
    }
    public async Task<User> GetUserAsync(string email)
    {
        var user = await userRepository.GetUserAsync(email);
        return user;
    }


    public async Task<User> ValidateUserAsync(string email, string password)
    {
        var user = await userRepository.GetUserAsync(email);
        if (user == null)
        {
            return null;
        }

        return password.Equals(user.Password) ? user : null;
    }
}