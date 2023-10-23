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
            return Unauthorized();
        }

        if (user.UserPassword != Keys.HashingPassword(password))
        {
            return Unauthorized();
        }
        
        else
        {
            var token = TokenService.GenerateToken(user).ToString().Trim('{','}').Trim().Remove(0,8);
            
            return Ok("Bearer " + token);
    
        }
    }
}

