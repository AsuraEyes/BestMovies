using MovieServer.Data.Media;
using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public class MediaMiddlePoint : IMediaMiddlePoint
{
    private readonly IMediaService mediaService;
    private MediaList media;

    public MediaMiddlePoint(IMediaService mediaService)
    {
        this.mediaService = mediaService;
        media = new MediaList();
    }


    public async Task<MediaList> GetTrendingAsync()
    {
        media = await mediaService.GetTrendingAsync();
        foreach (var m in media.ListOfMedia)
        {
            var image = "https://image.tmdb.org/t/p/original" + m.Poster;
            var carousel = "https://image.tmdb.org/t/p/original" + m.Backdrop;
            m.Poster = image;
            m.Backdrop = carousel;
        }
        return media;
    }
}