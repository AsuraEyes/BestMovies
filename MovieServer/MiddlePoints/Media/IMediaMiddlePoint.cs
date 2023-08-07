using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface IMediaMiddlePoint
{
    Task<Models.Media[]> GetTrendingAsync();
    Task<Models.Media[]> GetMoviesAsync();
    Task<Models.Media[]> GetTVShowsAsync();
    Task<MediaList> GetSearchAsync(string query, int page);
}