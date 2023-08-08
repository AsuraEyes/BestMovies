using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class TVMiddlePoint : ITVMiddlePoint
{
    private readonly ITVService tvService;
    private TV tv;
    private MediaList media;
    private const string Image = "https://image.tmdb.org/t/p/original";
    private const string Youtube = "https://www.youtube.com/embed/";
    private const string AutoPlay = "?autoplay=1";
    private const string Vimeo = "https://vimeo.com/";

    public TVMiddlePoint(ITVService tvService)
    {
        this.tvService = tvService;
        tv = new TV();
        media = new MediaList();
    }
    
    public async Task<TV> GetTVAsync(int id)
    {
        tv = await tvService.GetTVAsync(id);
        tv.Trailer = SetTrailer();
        tv.Poster = SetImage(tv.Poster);
        tv.Backdrop = SetImage(tv.Backdrop);
        tv.Credits.Cast = SetPeople(tv.Credits.Cast);
        tv.Credits.Crew = SetPeople(tv.Credits.Crew);
        tv.Credits.TopCast = SetCast();
        tv.Language = SetLanguage();

        return tv;
    }
    
    public async Task<MediaList> GetTVShowsAsync(int page)
    {
        if (page == 0)
        {
            page = 1;
        }
        var tv = await tvService.GetTVShowsAsync(page);

        foreach (var m in tv.ListOfMedia)
        {
            m.Poster = SetImage(m.Poster);
        }
        return tv;
    }
    
    public async Task<MediaList> GetTVShowsAsync(string query, int page)
    {
        if (page == 0)
        {
            page = 1;
        }
        var tv = await tvService.GetTVShowsAsync(query, page);

        foreach (var m in tv.ListOfMedia)
        {
            m.Poster = SetImage(m.Poster);
        }
        return tv;
    }
    
    public async Task<Models.Media[]> GetRecommendedAsync(int id)
    {
        media = await tvService.GetRecommendedAsync(id);

        foreach (var m in media.ListOfMedia)
        {
            var img = SetImage(m.Poster);
            m.Poster = img;
        }
        
        return media.ListOfMedia;
    }
    
    public async Task<Models.Media[]> GetSimilarAsync(int id)
    {
        media = await tvService.GetSimilarAsync(id);

        foreach (var m in media.ListOfMedia)
        {
            var img = SetImage(m.Poster);
            m.Poster = img;
        }
        
        return media.ListOfMedia;
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

    private string SetImage(string img)
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
        var people = tv.Credits.Cast;

        for (var i = 0; i <= 8 && i < tv.Credits.Cast.Length; i++)
        {
            tv.Credits.Cast[i] = people[i];
        }

        return people.ToArray();
    }

    private string SetLanguage()
    {
        foreach (var sl in tv.SpokenLanguages)
        {
            if (sl.iso_639_1.Equals(tv.Language))
            {
                tv.Language = sl.Name;
            }
        }

        return tv.Language;
    }
}