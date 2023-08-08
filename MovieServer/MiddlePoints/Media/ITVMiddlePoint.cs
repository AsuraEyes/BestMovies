using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface ITVMiddlePoint
{
    Task<TV> GetTVAsync(int id);
    Task<MediaList> GetTVAsync(string query, int page);
}