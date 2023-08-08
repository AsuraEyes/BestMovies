using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface ITVService
{
    Task<TV> GetTVAsync(int id);
    Task<MediaList> GetTVShowsAsync(int page);
    Task<MediaList> GetTVShowsAsync(string query, int page);
    Task<Models.Media[]> GetRecommendedAsync(int id);
    Task<Models.Media[]> GetSimilarAsync(int id);
}