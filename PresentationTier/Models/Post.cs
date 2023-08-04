namespace PresentationTier.Models;
public class Post
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }
    public string PostedBy { get; set; }
    public byte[] Picture { get; set; }
    public string Username { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfDislikes { get; set; }
    public List<string> LikedByUsers { get; set; }
    public List<string> DisLikedByUsers { get; set; }
}

