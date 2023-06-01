using MovieServer.Models;

namespace MovieServer.MiddlePoints.Media;

public interface IPersonMiddlePoint
{
    Task<Person> GetPersonAsync(int id);
}