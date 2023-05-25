using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints;

public class UserMiddlePoint : IUserMiddlePoint
{
    private readonly IUserRepository userRepository;


    public UserMiddlePoint(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task CreateUserAsync(User user)
    {
        // var role = "Reviewer";
        //user.Role = role;
        await userRepository.CreateUserAsync(user);
    }

    public async Task<User> ValidateUserAsync(string email, string password)
    {
        Console.WriteLine("testtttt");
        var user = await userRepository.GetUserAsync(email);
        if (user == null)
        {
            return null;
        }
        Console.WriteLine("Email: " + user.Email + "\nPassword: " + user.Password);

        return password.Equals(user.Password) ? user : null;
    }
}