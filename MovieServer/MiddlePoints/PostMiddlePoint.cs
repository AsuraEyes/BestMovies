using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints
{
    public class PostMiddlePoint : IPostMiddlePoint
    {
        private readonly IPostRepository postRepository;
        public PostMiddlePoint(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public async Task CreatePostAsync(Post post)
        {
            await postRepository.CreatePostAsync(post);
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await postRepository.GetAllPostsAsync();
        }
    }
}
