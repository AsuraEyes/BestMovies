using System;
using System.Threading.Tasks;
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
    public async Task<ActionResult<Models.Media[]>> GetTrendingAsync()
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
    
    [HttpGet]
    [Route("/NowPlaying")]
    public async Task<ActionResult<Models.Media[]>> GetMoviesAsync()
    {
        try
        {
            var media = await mediaMiddlePoint.GetMoviesAsync();
            return Ok(media);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return  StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/AiringToday")]
    public async Task<ActionResult<Models.Media[]>> GetTVShowsAsync()
    {
        try
        {
            var media = await mediaMiddlePoint.GetTVShowsAsync();
            return Ok(media);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return  StatusCode(500, e.Message);
        }
    }
}