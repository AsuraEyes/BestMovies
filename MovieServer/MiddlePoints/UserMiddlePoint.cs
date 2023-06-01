using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints
{
    private readonly IUserRepository userRepository;
    private readonly ICollectionRepository collectionRepository;
    private const string Role = "Reviewer";


    public UserMiddlePoint(IUserRepository userRepository, ICollectionRepository collectionRepository)
    {
        this.userRepository = userRepository;
        this.collectionRepository = collectionRepository;
    }

    // Create a new user by calling the UserRepository's CreateUserAsync method
        public async Task CreateUserAsync(User user)
        {
            await userRepository.CreateUserAsync(user);
        }

        // Update an existing user by calling the UserRepository's UpdateUserAsync method
        public async Task UpdateUserAsync(User user)
        {
            await userRepository.UpdateUserAsync(user);
        }

        // Retrieve a user from the UserRepository based on their email
        public async Task<User> GetUserAsync(string email)
        {
            var user = await userRepository.GetUserAsync(email);
            return user;
        }

        // Validate a user's credentials by retrieving the user from the UserRepository and comparing the password
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
}
