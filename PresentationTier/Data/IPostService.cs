using PresentationTier.Models;
namespace PresentationTier.Data
{
    public interface IPostService
    {
        Task SavePost(Post post);
        Task<List<Post>> GetAllPosts();
        Task DislikePost(Post post);
        Task LikePost(Post post);
    }
}
