using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints.Media;
using MovieServer.Models;

namespace MovieServer.Controllers.Media;

[ApiController]
[Route("[controller]")]
public class TVController : Controller
{
    private readonly ITVMiddlePoint tvMiddlePoint;

    public TVController(ITVMiddlePoint tvMiddlePoint)
    {
        this.tvMiddlePoint = tvMiddlePoint;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<TV>> getTVAsync(int id)
    {
        try
        {
            var tv = await tvMiddlePoint.GetTVAsync(id);
            return Ok(tv);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/Shows")]
    public async Task<ActionResult<MediaList>> GetTVShowsAsync([FromQuery] int page)
    {
        try
        {
            var movies = await tvMiddlePoint.GetTVShowsAsync(page);
            return Ok(movies);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/SearchTV")]
    public async Task<ActionResult<MediaList>> GetTVShowsAsync([FromQuery] string query, int page)
    {
        try
        {
            var movies = await tvMiddlePoint.GetTVShowsAsync(query, page);
            return Ok(movies);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}/RecommendedShows")]
    public async Task<ActionResult<Models.Media[]>> GetRecommendedAsync(int id)
    {
        try
        {
            var recommendations = await tvMiddlePoint.GetRecommendedAsync(id);
            return Ok(recommendations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}/SimilarShows")]
    public async Task<ActionResult<Models.Media[]>> GetSimilarAsync(int id)
    {
        try
        {
            var recommendations = await tvMiddlePoint.GetSimilarAsync(id);
            return Ok(recommendations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}