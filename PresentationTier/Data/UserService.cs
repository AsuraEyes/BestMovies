using System;
using System.Collections.Generic;
using System.Linq;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public class UserService:IUserService
    {
        private List<User> _users;
        
        public UserService()
        {
            _users = new[]
            {
                new User
                {
                    Email = "123@via.dk",
                    Password = "1234"
                },
                new User
                {
                    Email = "abc@via.dk",
                    Password = "abcd"
                }
            }.ToList();
        }
        public User ValidateUser(string email, string password)
        {
            User first = _users.FirstOrDefault(user => user.Email.Equals(email));
            if (first == null) {
                throw new Exception("User not found"); }
            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password"); }
            return first; }
    }
    
  
}