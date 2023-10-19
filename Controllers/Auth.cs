using ecommerce_api.Service;
using Microsoft.AspNetCore.Mvc;
using Users.Model;
namespace Auth.Controller;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
        
    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentException("Something is not wright...");
    }
    
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        User? user = _userRepository.GetUser(_userRepository.GetIdByName(username));
        
        if (user == null)
        {
            return NotFound();
        }

        if (user.UserPassword != password)
        {
            return BadRequest();
        }

        if (user.Role != Roles.Admin)
        {
            return BadRequest();
        }

        else
        {
            var token = TokenService.GenerateToken(user).ToString().Trim('{','}').Trim().Remove(0,8);

            return Ok("Bearer " + token);
        }
    }
}
