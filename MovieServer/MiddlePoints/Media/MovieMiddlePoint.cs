using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class MovieMiddlePoint : IMovieMiddlePoint
{
    private readonly IMovieService movieService;
    private Movie movie;
    private MediaList media;
    private const string Image = "https://image.tmdb.org/t/p/original";
    private const string Youtube = "https://www.youtube.com/embed/";
    private const string AutoPlay = "?autoplay=1";
    private const string Vimeo = "https://vimeo.com/";

    public MovieMiddlePoint(IMovieService movieService)
    {
        this.movieService = movieService;
        movie = new Movie();
        media = new MediaList();
    }
    
    public async Task<Movie> GetMovieAsync(int id)
    {
        movie = await movieService.GetMovieAsync(id);
        movie.Trailer = SetTrailer();
        movie.Poster = SetImage(movie.Poster);
        movie.Backdrop = SetImage(movie.Backdrop);
        if (movie.MovieCollection != null)
        {
            movie.MovieCollection.Backdrop = SetImage(movie.MovieCollection.Backdrop);
        }
        movie.Credits.Cast = SetPeople(movie.Credits.Cast);
        movie.Credits.Crew = SetPeople(movie.Credits.Crew);
        movie.Credits.TopCast = SetCast();
        movie.Language = SetLanguage();

        return movie;
    }

    public async Task<MediaList> GetMoviesAsync(int page)
    {
        if (page == 0)
        {
            page = 1;
        }
        var movies = await movieService.GetMoviesAsync(page);

        foreach (var m in movies.ListOfMedia)
        {
            var img = SetImage(m.Poster);
            m.Poster = img;
        }
        return movies;
    }
    
    public async Task<MediaList> GetMoviesAsync(string query, int page)
    {
        if (page == 0)
        {
            page = 1;
        }
        var movies = await movieService.GetMoviesAsync(query, page);

        foreach (var m in movies.ListOfMedia)
        {
            var img = SetImage(m.Poster);
            m.Poster = img;
        }
        return movies;
    }

    public async Task<Models.Media[]> GetRecommendedAsync(int id)
    {
        media = await movieService.GetRecommendedAsync(id);

        foreach (var m in media.ListOfMedia)
        {
            var img = SetImage(m.Poster);
            m.Poster = img;
        }
        
        return media.ListOfMedia;
    }
    
    public async Task<Models.Media[]> GetSimilarAsync(int id)
    {
        media = await movieService.GetSimilarAsync(id);

        foreach (var m in media.ListOfMedia)
        {
            var img = SetImage(m.Poster);
            m.Poster = img;
        }
        
        return media.ListOfMedia;
    }

    private string SetTrailer()
    {
        foreach (var video in movie.Videos.VideoList)
        {
            if (video.Name.Equals("Official Trailer"))
            {
                if (video.Site.Equals("YouTube"))
                {
                    movie.Trailer = Youtube + video.Key + AutoPlay;
                    break;
                }

                if (video.Site.Equals("Vimeo"))
                {
                    movie.Trailer = Vimeo + video.Key;
                    break;
                }
            }
            else
            {
                if (video.Site.Equals("YouTube"))
                {
                    movie.Trailer = Youtube + video.Key + AutoPlay;;
                }
                else if (video.Site.Equals("Vimeo"))
                {
                    movie.Trailer = Vimeo + video.Key;
                    break;
                }
            }
        }

        return movie.Trailer;
    }

    private static string SetImage(string img)
    {
        return Image + img;
    }
    
    private Person[] SetPeople(Person[] people)
    {
        foreach (var person in people)
        {
            person.Picture = SetImage(person.Picture);
        }
        return people;
    }

    private Person[] SetCast()
    {
        Person[] people = {};

        var cast = movie.Credits.Cast;

        for (var i = 0; i <= 8 && i < cast.Length; i++)
        {
            people[i] = cast[i];
        }

        return people.ToArray();
    }

    private string SetLanguage()
    {
        foreach (var sl in movie.SpokenLanguages)
        {
            if (sl.iso_639_1.Equals(movie.Language))
            {
                movie.Language = sl.Name;
            }
        }

        return movie.Language;
    }
}