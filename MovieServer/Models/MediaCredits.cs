namespace MovieServer.Models;

public class MediaCredits
{
    public Media[] Cast { get; set; }
    public Media[] Crew { get; set; }
    public Media[] KnownFor { get; set; }

    public MediaCredits()
    {
        Cast = new Media[] { };
        Crew = new Media[] { };
        KnownFor = new Media[] { };
    }
}