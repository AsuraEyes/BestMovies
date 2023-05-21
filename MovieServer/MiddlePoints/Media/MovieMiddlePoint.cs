using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class MovieMiddlePoint : IMovieMiddlePoint
{
    private readonly IMovieService movieService;
    private Movie movie = new ();
    private readonly string image = "https://image.tmdb.org/t/p/original";
    private readonly string youtube = "https://www.youtube.com/watch?v=";

    public MovieMiddlePoint(IMovieService movieService)
    {
        this.movieService = movieService;
    }
    
    public async Task<Movie> GetMovieAsync(int id)
    {
        movie = await movieService.GetMovieAsync(id);
        movie.Trailer = SetTrailer();
        movie.Poster = SetPoster();
        movie.Backdrop = SetBackdrop();
        movie.Credits.Cast = SetCast();

        return movie;
    }

    private string SetTrailer()
    {
        foreach (var video in movie.Videos.VideoList)
        {
            if (video.Name.Equals("Official Trailer"))
            {
                if (video.Site.Equals("YouTube"))
                {
                    movie.Trailer = youtube + video.Key;
                    break;
                }
            }
            else
            {
                if (video.Site.Equals("YouTube"))
                {
                    movie.Trailer = youtube + video.Key;
                }
            }
        }

        return movie.Trailer;
    }

    private string SetPoster()
    {
        return movie.Poster.Insert(0, image);
    }
    
    private string SetBackdrop()
    {
        return movie.Backdrop.Insert(0, image);
    }
    
    private Person[] SetCast()
    {
        foreach (var person in movie.Credits.Cast)
        {
           var img = image + person.Picture;
            person.Picture = img;
        }

        return movie.Credits.Cast;
    }
}