using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints.Media;
using MovieServer.Models;

namespace MovieServer.Controllers.Media;

[ApiController]
[Route("[controller]")]
public class MovieController : Controller
{
    private readonly IMovieMiddlePoint movieMiddlePoint;

    public MovieController(IMovieMiddlePoint movieMiddlePoint)
    {
        this.movieMiddlePoint = movieMiddlePoint;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Movie>> getMovieAsync(int id)
    {
        try
        {
            var movie = await movieMiddlePoint.GetMovieAsync(id);
            return Ok(movie);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}