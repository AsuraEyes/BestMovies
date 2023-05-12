namespace PresentationTier.Models;

public class Credits
{
    public Person[] Cast { get; set; }
    public Person[] Crew { get; set; }

    public Credits()
    {
        Cast = new Person[] { };
        Crew = new Person[] { };
    }
}