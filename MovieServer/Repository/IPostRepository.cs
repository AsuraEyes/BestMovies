using MovieServer.Models;

namespace MovieServer.Repository
{
    public interface IPostRepository
    {
        Task CreatePostAsync(Post post);

    }
}
