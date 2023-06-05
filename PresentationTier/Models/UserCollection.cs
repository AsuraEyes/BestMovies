namespace PresentationTier.Models;

public class UserCollection
{
    public string Id { get; set; }
    public string Email { set; get; }
    public string Name { set; get; }
    public string Poster { get; set; }
    public string Backdrop { get; set; }
    public Media[] Media { set; get; }
    public bool IsPublic { set; get; }
}