using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class MediaMiddlePoint : IMediaMiddlePoint
{
    private readonly IMediaService mediaService;
    private MediaList media;
    private const string Image = "https://image.tmdb.org/t/p/original";

    public MediaMiddlePoint(IMediaService mediaService)
    {
        this.mediaService = mediaService;
        media = new MediaList();
    }


    public async Task<Models.Media[]> GetTrendingAsync()
    {
        media = await mediaService.GetTrendingAsync();
        
        foreach (var m in media.ListOfMedia)
        {
            m.Poster = SetImage(m.Poster);
        }
        
        return media.ListOfMedia;
    }
    
    public async Task<Models.Media[]> GetMoviesAsync()
    {
        media = await mediaService.GetMoviesAsync();
        
        foreach (var m in media.ListOfMedia)
        {
            m.Poster = SetImage(m.Poster);
        }
        
        return media.ListOfMedia;
    }
    
    public async Task<Models.Media[]> GetTVShowsAsync()
    {
        media = await mediaService.GetTVShowsAsync();
        
        foreach (var m in media.ListOfMedia)
        {
            m.Poster = SetImage(m.Poster);
        }
        
        return media.ListOfMedia;
    }

    public async Task<MediaList> GetSearchAsync(string query, int page)
    {
        if (page == 0)
        {
            page = 1;
        }
        media = await mediaService.GetSearchAsync(query, page);
        
        foreach (var m in media.ListOfMedia)
        {
            Console.WriteLine("Name: " + m.Name);
        }

        foreach (var m in media.ListOfMedia)
        {
            m.Poster = SetImage(m.Poster);
            m.Picture = SetImage(m.Picture);
        }
        
        return media;
    }
    
    private static string SetImage(string img)
    {
        return Image + img;
    }
}