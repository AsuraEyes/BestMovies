using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class MovieMiddlePoint : IMovieMiddlePoint
{
    private readonly IMovieService movieService;
    private Movie movie;
    private MediaList media;
    private const string Image = "https://image.tmdb.org/t/p/original";
    private const string Youtube = "https://www.youtube.com/watch?v=";
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
        if (movie.Collection != null)
        {
            movie.Collection.Backdrop = SetImage(movie.Collection.Backdrop);
        }
        movie.Credits.Cast = SetCast();

        return movie;
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
                    movie.Trailer = Youtube + video.Key;
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
                    movie.Trailer = Youtube + video.Key;
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

    private Person[] SetCast()
    {
        foreach (var person in movie.Credits.Cast)
        {
            var img = Image + person.Picture;
            person.Picture = img;
                
        }

        return movie.Credits.Cast;
    }
}