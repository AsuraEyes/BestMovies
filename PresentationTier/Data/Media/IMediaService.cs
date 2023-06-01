using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface IMediaService
{
    Task<Models.Media[]> GetTrendingAsync();
    Task<Models.Media[]> GetMoviesAsync();
    Task<Models.Media[]> GetTVShowsAsync();
}