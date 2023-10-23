using System.Net.Http.Headers;
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
        _userRepository = userRepository;
    }
    
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        User? user = _userRepository.GetUser(_userRepository.GetIdByName(username));
        
        if (user == null)
        {
            return NotFound();
        }

        if (user.UserPassword != Keys.HashingPassword(password))
        {
            return BadRequest();
        }
        
        else
        {
            var token = TokenService.GenerateToken(user).ToString().Trim('{','}').Trim().Remove(0,8);
            
            switch(user.Role)
            {
                case Roles.Common: return Ok(Keys.HashingPassword(user.UserId.ToString()));
                case Roles.Admin : return Ok("Bearer " + token);
                default : return BadRequest();
            }
        }
    }
}
