﻿using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PresentationTier.Models;

public class User
{
    [Required(ErrorMessage = "Please enter a username")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please confirm your password.")]


    public string Role { get; set; }
    public string Name { get; set; }
    public int CountryCallingCode { get; set; }
    [Required]
    public string Email { get; set; }
    public byte[] Profile { get; set; }  // Profile picture URL

    public int PhoneNumber { get; set; }
    public byte[] Backdrop { get; set; }  // Backdrop picture URL
    public DateTime Joined { get; set; } = DateTime.Now;
    public DateTime DateOfBirth { get; set; }
    public ObjectId Id { get; set; }
    
    public User()
    {
        Id = ObjectId.GenerateNewId();
    }
}
