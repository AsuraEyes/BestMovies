using MovieServer.Models;

namespace MovieServer.Repository
{
    public interface IPostRepository
    {
        Task CreatePostAsync(Post post);
        Task<List<Post>> GetAllPostsAsync();
        Task UpdatePostAsync(Post post);
        Task<Post> GetPostByIdAsync(string postId);
      //  Task<Post> GetPostByUserId(string email);
    }
}
