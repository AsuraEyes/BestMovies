using System.ComponentModel.DataAnnotations;

namespace PresentationTier.Models;

public class Review
{
    public string Id { get; set; }
    [Required]
    public string Title { get; set; }
    public double Rating { get; set; }
    [Required]
    public string Description { get; set; }
    public bool IsSpoiler { get; set; }
    public DateTime Created { get;}
    public DateTime Edited { get; set; }
    public int Count { set; get; } = 0;
    public int NumberOfLikes { set; get; }
    public User User { get; set; }
    public int MediaId { get; set; }
    public string[] LikedUsers { set; get; }
}