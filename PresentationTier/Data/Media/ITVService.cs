using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface ITVService
{
    Task<TV> GetTVAsync(int id);
    Task<MediaList> GetTVShowsAsync(int page);
    Task<MediaList> GetTVShowsAsync(string query, int page);
}