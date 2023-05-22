namespace PresentationTier.Models;

public class Collection
{
    public string Id { set; get; }
    public string Name { set; get; }
    public int[] MediaId { set; get; }
    public bool IsPublic { set; get; }
    public string UserI { set; get; }
}