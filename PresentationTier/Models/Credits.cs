namespace PresentationTier.Models;

public class Credits
{
    public Person[] TopCast { get; set; }
    public Person[] Cast { get; set; }
    public Person[] Crew { get; set; }

    public Credits()
    {
        TopCast = new Person[] { };
        Cast = new Person[] { };
        Crew = new Person[] { };
    }
}