namespace PresentationTier.Models;

public class Collection
{
    public string Id { set; get; }
    public string Name { set; get; }
    public int[] MovieId { set; get; }
    public int[] TVId { set; get; }
    public bool IsPublic { set; get; }
    public string UserI { set; get; }
}