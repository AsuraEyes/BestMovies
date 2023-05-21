using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface IMediaMiddlePoint
{
    Task<MediaList> GetTrendingAsync();
}