using System.ComponentModel;
using static GenericTools.GenericTools;
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
    public IActionResult Auth([FromForm] string username, [FromForm] string password)
    {
        try
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
        catch(Exception error)
        {
            string message = errorFilter(error);
            return BadRequest(message);
        }
    }
}   

