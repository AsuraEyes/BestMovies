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
    
    private static string SetImage(string img)
    {
        return img.Insert(0, Image);
    }
}