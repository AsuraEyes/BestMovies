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
    public async Task<ActionResult<Movie>> GetMovieAsync(int id)
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
    
    [HttpGet]
    [Route("{id:int}/Recommended")]
    public async Task<ActionResult<Models.Media[]>> GetRecommendedAsync(int id)
    {
        try
        {
            var recommendations = await movieMiddlePoint.GetRecommendedAsync(id);
            return Ok(recommendations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}/Similar")]
    public async Task<ActionResult<Models.Media[]>> GetSimilarAsync(int id)
    {
        try
        {
            var recommendations = await movieMiddlePoint.GetSimilarAsync(id);
            return Ok(recommendations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}