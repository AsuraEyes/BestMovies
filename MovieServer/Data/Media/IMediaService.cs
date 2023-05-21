using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface IMediaService
{
    Task<MediaList> GetTrendingAsync();
}