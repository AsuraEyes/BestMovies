using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface IMediaService
{
    Task<MediaList> GetTrendingAsync();
}