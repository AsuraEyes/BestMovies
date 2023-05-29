using Microsoft.AspNetCore.Mvc;
using MovieServer.MiddlePoints;
using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;
    //private readonly IUserService userService;
    private readonly IUserMiddlePoint userMiddlePoint;
    public UserController(IUserRepository userRepository, IUserMiddlePoint userMiddlePoint)
    {
        this.userRepository = userRepository;
        this.userMiddlePoint = userMiddlePoint;
    }

    [HttpPost]
    [Route("/Register")]

    public async Task<ActionResult> CreateUserAsync([FromBody]User user)
    {
        try
        {
            await userMiddlePoint.CreateUserAsync(user);
            Console.WriteLine(user.Name);
            Console.WriteLine("TEEEEEST");
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateReviewAsync(User user)
    {
        try
        {
            await userRepository.CreateUserAsync(user);
            return Ok(user);
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