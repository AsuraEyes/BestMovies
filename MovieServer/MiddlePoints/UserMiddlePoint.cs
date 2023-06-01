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
        user.Role = Role;
        var watchList = new UserCollection
        {
            Name = "Watchlist",
            Email = user.Email
        };
        
        var favorites = new UserCollection
        {
            Name = "Favorites",
            Email = user.Email
        };

        await collectionRepository.CreateCollectionAsync(watchList);
        await collectionRepository.CreateCollectionAsync(favorites);
        await userRepository.CreateUserAsync(user);
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