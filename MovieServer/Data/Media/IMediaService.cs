using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface IMediaService
{
    Task<MediaList> GetTrendingAsync();
    Task<MediaList> GetMoviesAsync();
    Task<MediaList> GetTVShowsAsync();
}