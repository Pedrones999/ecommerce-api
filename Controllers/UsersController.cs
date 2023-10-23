using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Connection;
using Users.Model;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Http.Headers;
using Auth;

namespace Users.Controller
{
    [Route("api/[Controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {           
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentException("Something is not wright...");
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult Add([FromForm]UserViewModel userView)
        {
            try
            {
                var user = new User(userView.name, userView.email, userView.userPassword, userView.role);

                _userRepository.Add(user);
                
                return Ok();
            }    
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        
        [Authorize]
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);  

        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult<User> GetUser(Guid userId)
        {
            if(Request.Headers["Authorization"] != Keys.HashingPassword(userId.ToString()))
            {
                return Unauthorized("Only the user can do this!");
            }
            try
            {
                var user = _userRepository.GetUser(userId);
                
                if(user != null)
                {
                    return Ok(user);
                }
                
                else
                {
                    return NotFound();
                }
            }
            
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        [Route("{userId}")]

        public IActionResult RemoveUser(Guid userId)
        {
            try
            {
                var user = _userRepository.GetUser(userId);
                
                if(user != null)
                {
                    _userRepository.RemoveUser(userId);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception error)
            
            {
                return BadRequest(error.Message);    
            }
        
        }

        
        [HttpPatch]
        [Route("{userId}")]
        
        public IActionResult UpdateUser([FromForm]UserViewModel userView, Guid userId)
        {
            var login = Request.Headers["Authorization"];             
            var user = _userRepository.GetUser(userId);
            
            if (login != Keys.HashingPassword(userId.ToString()))
            {
                return Unauthorized("Only the user can do this!");
            }
            try
            {
                if(user != null)
                {   
                    if(userView.userPassword != null)
                    {
                        _userRepository.UpdateUser(userId, password: userView.userPassword);
                    }
                    
                    if(userView.name != null)
                    {   
                        _userRepository.UpdateUser(userId, name: userView.name);
                    }
                    
                    if(userView.email != null)
                    {
                        _userRepository.UpdateUser(userId, email: userView.email);
                    }

                    if(userView.role != null)
                    {
                        _userRepository.UpdateUser(userId, role: userView.role);
                    }
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
