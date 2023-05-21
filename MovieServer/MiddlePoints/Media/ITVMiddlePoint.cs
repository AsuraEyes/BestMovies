using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface ITVMiddlePoint
{
    Task<TV> GetTVAsync(int id);
}