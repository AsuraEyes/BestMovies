using Microsoft.AspNetCore.Mvc;
using MovieServer.Data.Media;
using MovieServer.MiddlePoints.Media;
using MovieServer.Models;

namespace MovieServer.Controllers.Media;

[ApiController]
[Route("[controller]")]
public class MediaController : Controller
{
    private readonly IMediaMiddlePoint mediaMiddlePoint;

    public MediaController(IMediaMiddlePoint mediaMiddlePoint)
    {
        this.mediaMiddlePoint = mediaMiddlePoint;
    }

    [HttpGet]
    [Route("/Trending")]
    public async Task<ActionResult<MediaList>> GetTrendingAsync()
    {
        try
        {
            var media = await mediaMiddlePoint.GetTrendingAsync();
            return Ok(media);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return  StatusCode(500, e.Message);
        }
    }
}