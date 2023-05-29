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
    }
}
