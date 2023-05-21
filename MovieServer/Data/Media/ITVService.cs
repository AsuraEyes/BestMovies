using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface ITVService
{
    Task<TV> GetTVAsync(int id);
}