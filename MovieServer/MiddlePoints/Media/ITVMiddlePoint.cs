using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface ITVMiddlePoint
{
    Task<TV> GetTVAsync(int id);
    Task<MediaList> GetTVShowsAsync(int page);
    Task<MediaList> GetTVShowsAsync(string query, int page);
    Task<Models.Media[]> GetRecommendedAsync(int id);
    Task<Models.Media[]> GetSimilarAsync(int id);
}