using MovieServer.Models;

namespace MovieServer.Data.Media;

public interface IPersonService
{
    Task<Person> GetPersonAsync(int id);
}