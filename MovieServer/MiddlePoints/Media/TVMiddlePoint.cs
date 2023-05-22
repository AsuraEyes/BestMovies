using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class TVMiddlePoint : ITVMiddlePoint
{
    private readonly ITVService tvService;
    private TV tv;
    private readonly string image = "https://image.tmdb.org/t/p/original";
    private string trailer = "https://www.youtube.com/watch?v=";

    public TVMiddlePoint(ITVService tvService)
    {
        this.tvService = tvService;
        tv = new TV();
    }
    
    public async Task<TV> GetTVAsync(int id)
    {
        tv = await tvService.GetTVAsync(id);
        tv.Trailer = SetTrailer();
        tv.Poster = SetPoster();
        tv.Backdrop = SetBackdrop();
        tv.Credits.Cast = SetCast();

        return tv;
    }

    private string SetTrailer()
    {
        foreach (var video in tv.Videos.VideoList)
        {
            if (video.Name.Equals("Official Trailer"))
            {
                trailer += video.Key;
                break;
            }
            trailer += video.Key;
        }
        
        return trailer;
    }

    private string SetPoster()
    {
        return tv.Poster.Insert(0, image);
    }
    
    private string SetBackdrop()
    {
        return tv.Backdrop.Insert(0, image);
    }
    
    private Person[] SetCast()
    {
        foreach (var person in tv.Credits.Cast)
        {
            var img = image + person.Picture;
            person.Picture = img;
        }
    
        return tv.Credits.Cast;
    }
}