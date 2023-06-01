using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface IPersonService
{
    Task<Person> GetPersonAsync(int id);
}