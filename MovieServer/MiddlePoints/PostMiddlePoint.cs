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

        // Create a new post by delegating the operation to the post repository
        public async Task CreatePostAsync(Post post)
        {
            await postRepository.CreatePostAsync(post);
        }

        // Retrieve all posts by delegating the operation to the post repository
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await postRepository.GetAllPostsAsync();
        }

        // Retrieve a post by its postId by delegating the operation to the post repository
        public async Task<Post> GetPostByIdAsync(string postId)
        {
            return await postRepository.GetPostByIdAsync(postId);
        }

        // Update a post by delegating the operation to the post repository
        public async Task UpdatePostAsync(Post post)
        {
            await postRepository.UpdatePostAsync(post);
        }
    }
}
