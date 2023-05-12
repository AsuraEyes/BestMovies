using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationTier.Models
{
    public class User
    {
        public string Id{ get; set; }
    
        [Required(ErrorMessage = "Please enter a username")]
        public string Username{ get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string Password{ get; set; }
        
        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", 
            ErrorMessage = "The Passwords do not match.\nPlease try again")]
        public string ConfirmPassword { get; set; }
    
        public string Role{ get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }

        public string CountryCallingCode { get; set; }
        public string ProfilePictureUrl { get; set; }

        public int PhoneNumber{ get; set; }
        public DateTime Joined { get; set; } = DateTime.Now;
        public DateTime DateOfBirth { get; set; }
    }
}
