using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints.Media;
using MovieServer.Models;

namespace MovieServer.Controllers.Media;

[ApiController]
[Route("[controller]")]
public class PersonController : Controller
{
    private readonly IPersonMiddlePoint personMiddlePoint;

    public PersonController(IPersonMiddlePoint personMiddlePoint)
    {
        this.personMiddlePoint = personMiddlePoint;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Person>> GetPersonAsync(int id)
    {
        try
        {
            var person = await personMiddlePoint.GetPersonAsync(id);
            return Ok(person);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(e.GetHashCode(), e.Message);
        }
    }
}