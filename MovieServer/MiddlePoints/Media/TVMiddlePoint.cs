using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class TVMiddlePoint : ITVMiddlePoint
{
    private readonly ITVService tvService;
    private TV tv;
    private const string Image = "https://image.tmdb.org/t/p/original";
    private const string Youtube = "https://www.youtube.com/embed/";
    private const string AutoPlay = "?autoplay=1";
    private const string Vimeo = "https://vimeo.com/";

    public TVMiddlePoint(ITVService tvService)
    {
        this.tvService = tvService;
        tv = new TV();
    }
    
    public async Task<TV> GetTVAsync(int id)
    {
        tv = await tvService.GetTVAsync(id);
        tv.Trailer = SetTrailer();
        tv.Poster = SetPoster(tv.Poster);
        tv.Backdrop = SetPoster(tv.Backdrop);
        tv.Credits.Cast = SetCast();

        return tv;
    }
    
    public async Task<MediaList> GetTVAsync(string query, int page)
    {
        if (page == 0)
        {
            page = 1;
        }
        var tv = await tvService.GetTVAsync(query, page);

        foreach (var m in tv.ListOfMedia)
        {
            m.Poster = SetPoster(m.Poster);
        }
        return tv;
    }

    private string SetTrailer()
    {
        foreach (var video in tv.Videos.VideoList)
        {
            if (video.Name.Equals("Official Trailer"))
            {
                if (video.Site.Equals("YouTube"))
                {
                    tv.Trailer = Youtube + video.Key + AutoPlay;
                    break;
                }

                if (video.Site.Equals("Vimeo"))
                {
                    tv.Trailer = Vimeo + video.Key;
                    break;
                }
            }
            else
            {
                if (video.Site.Equals("YouTube"))
                {
                    tv.Trailer = Youtube + video.Key + AutoPlay;
                    ;
                }
                else if (video.Site.Equals("Vimeo"))
                {
                    tv.Trailer = Vimeo + video.Key;
                    break;
                }
            }
        }
        return tv.Trailer;
    }

    private string SetPoster(string img)
    {
        return img.Insert(0, Image);
    }
    
    private Person[] SetCast()
    {
        foreach (var person in tv.Credits.Cast)
        {
            var img = Image + person.Picture;
            person.Picture = img;
        }
    
        return tv.Credits.Cast;
    }
}