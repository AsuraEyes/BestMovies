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
    [Route("/SearchTV")]
    public async Task<ActionResult<MediaList>> GetTVAsync([FromQuery] string query, int page)
    {
        try
        {
            var movies = await tvMiddlePoint.GetTVAsync(query, page);
            return Ok(movies);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}