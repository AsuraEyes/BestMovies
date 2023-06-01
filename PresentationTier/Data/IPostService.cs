using PresentationTier.Models;
namespace PresentationTier.Data
{
    public interface IPostService
    {
        Task SavePost(Post post);
        Task<List<Post>> GetAllPosts();
        Task DisLikePost(Post post, string userId);
        Task LikePost(Post post, string userId);
        Task UpdatePostAsync(Post post);
    }
}
