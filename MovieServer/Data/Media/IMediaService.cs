using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface IMediaService
{
    Task<MediaList> GetTrendingAsync();
    Task<MediaList> GetMoviesAsync();
    Task<MediaList> GetTVShowsAsync();
    Task<MediaList> GetSearchAsync(string query, int page);
}