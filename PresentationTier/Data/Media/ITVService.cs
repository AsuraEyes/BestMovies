using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.Media;

public interface ITVService
{
    Task<TV> GetTVAsync(int id);
}