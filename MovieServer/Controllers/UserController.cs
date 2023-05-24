using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints;
using MovieServer.Models;

namespace MovieServer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserMiddlePoint userMiddlePoint;

    public UserController(IUserMiddlePoint userMiddlePoint)
    {
        this.userMiddlePoint = userMiddlePoint;
    }

    [HttpPost]
    public async Task<ActionResult> CreateReviewAsync(User user)
    {
        try
        {
            await userMiddlePoint.CreateUserAsync(user);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/Login")]
    public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string email, string password)
    {
        try
        {
            var user = await userMiddlePoint.ValidateUserAsync(email, password);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}