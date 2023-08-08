using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface ITVService
{
    Task<TV> GetTVAsync(int id);
    Task<MediaList> GetTVShowsAsync(int page);
    Task<MediaList> GetTVShowsAsync(string query, int page);
    Task<MediaList> GetRecommendedAsync(int id);
    Task<MediaList> GetSimilarAsync(int id);
}