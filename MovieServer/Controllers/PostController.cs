using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints;
using MovieServer.Models;
using MovieServer.Repository;


namespace MovieServer.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IPostMiddlePoint postMiddlePoint;
        public PostController( IPostMiddlePoint postMiddlePoint, IPostRepository postRepository)
        {
            this.postMiddlePoint = postMiddlePoint;
               this.postRepository = postRepository;
        }
   
        [HttpPost]
        [Route("/CreatePost")]
        public async Task<ActionResult> CreatePost([FromBody] Post post)
        {
            try
            {
                await postMiddlePoint.CreatePostAsync(post);

                return Ok(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [Route("/GetAllPosts")]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            try
            {
                var posts = await postMiddlePoint.GetAllPostsAsync();
                return Ok(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        //   [HttpPut("{id}")]
        [HttpPut("/UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(string id, [FromBody] int numberOfLikes)
        {
            var existingPost = await postMiddlePoint.GetPostByIdAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            // Update the NumberOfLikes property of the existing post
            existingPost.NumberOfLikes = numberOfLikes;

            await postMiddlePoint.UpdatePostAsync(existingPost);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(string id)
        {
            var post = await postMiddlePoint.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

    }
}
