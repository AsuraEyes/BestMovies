using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints
{
    public class UserMiddlePoint : IUserMiddlePoint
    {
        private readonly IUserRepository userRepository;

        public UserMiddlePoint(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
