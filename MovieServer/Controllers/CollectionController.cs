using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MovieServer.Data;
using MovieServer.MiddlePoints;
using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CollectionController : Controller
{
    private readonly ICollectionMiddlePoint collectionMiddlePoint;

    public CollectionController(ICollectionMiddlePoint collectionMiddlePoint)
    {
        this.collectionMiddlePoint = collectionMiddlePoint;
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<UserCollection>> GetMovieCollectionAsync(int id)
    {
        try
        {
            var result = await collectionMiddlePoint.GetMovieCollectionAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateCollectionAsync(Collection collection)
    {
        try
        {
            await collectionMiddlePoint.CreateCollectionAsync(collection);
            return Ok(collection);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/UserCollections")]
    public async Task<ActionResult<IList<Collection>>> GetUserCollectionsAsync([FromQuery] string email)
    {
        try
        {
            var result = await collectionMiddlePoint.GetUserCollectionsAsync(email);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/UserCollection")]
    public async Task<ActionResult<Collection>> GetCollectionAsync([FromQuery] ObjectId id)
    {
        try
        {
            var result = await collectionMiddlePoint.GetCollectionAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}