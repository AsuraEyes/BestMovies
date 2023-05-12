namespace PresentationTier.Models;

public class Review
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public bool IsSpoiler { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfLikes { set; get; }
    public int NumberOfDislikes { set; get; }
    public string MovieId { get; set; }
}