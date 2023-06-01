using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class PersonMiddlePoint : IPersonMiddlePoint
{
    private readonly IMovieService movieService;
    private readonly IPersonService personService;
    private readonly ITVService tvService;
    private const string Image = "https://image.tmdb.org/t/p/original";

    public PersonMiddlePoint(IMovieService movieService, IPersonService personService, ITVService tvService)
    {
        this.movieService = movieService;
        this.personService = personService;
        this.tvService = tvService;
    }
    
    public async Task<Person> GetPersonAsync(int id)
    {
        var person = await personService.GetPersonAsync(id);
        
        person.Picture = SetImage(person.Picture);
        person.MediaCredits.Cast = await SetMedia(person.MediaCredits.Cast);
        person.MediaCredits.Crew = await SetMedia(person.MediaCredits.Crew);

        person.MediaKnownFor = await SetMedia(person.KnownFor.Equals("Acting") ? SetKnownFor(person.MediaCredits.Cast) : SetKnownFor(person.MediaCredits.Crew));
        person.MediaCredits.KnownFor = person.MediaKnownFor;
        
        return person;
    }
    
    private static string SetImage(string img)
    {
        return Image + img;
    }

    private static async Task<Models.Media[]> SetMedia(Models.Media[] media)
    {
        foreach (var m in media)
        {
            m.Poster = SetImage(m.Poster);
        }

        return media;
    }

    private static Models.Media[] SetKnownFor(IReadOnlyList<Models.Media> media)
    {
        var m = new List<Models.Media>();

        for (var i = 0; i < 4; i++)
        {
            m.Add(media[i]);
        }
        
        return m.ToArray();
    }
}