using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints;
using MovieServer.Models;

namespace MovieServer.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : Controller
{
    private readonly IReviewMiddlePoint reviewMiddlePoint;

    public ReviewController(IReviewMiddlePoint reviewMiddlePoint)
    {
        this.reviewMiddlePoint = reviewMiddlePoint;
    }

    [HttpPost]
    public async Task<ActionResult<Review>> CreateReviewAsync([FromBody] Review review)
    {
        try
        {
            await reviewMiddlePoint.CreateReviewAsync(review);
            return Ok(review);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/Movie/{mediaId:int}/Reviews")]
    public async Task<ActionResult<IList<Review>>> GetAllMovieReviewsAsync(int mediaId)
    {
        try
        {
            var reviews = await reviewMiddlePoint.GetAllMovieReviewsAsync(mediaId);
            return Ok(reviews);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}