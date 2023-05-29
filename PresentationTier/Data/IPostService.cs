using PresentationTier.Models;
namespace PresentationTier.Data
{
    public interface IPostService
    {
        Task SavePost(Post post);
    }
}
