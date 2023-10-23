using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Connection;
using Users.Model;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Http.Headers;
using Auth;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Users.Controller
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {           
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentException("Something is not wright...");
        }

        private bool IsAdmin()
        {
            if(User.Claims.ToArray()[1].Value != Roles.Admin.ToString())
            {
                return false;
            }
            else {return true;}
        }

        private bool IsAdmin(Users.Model.User user)
        {
            if(user.Role != Roles.Admin)
            {
                return false;
            }
            else {return true;}
        }

        private bool IsOwner(Guid userId)
        {
            if(User.Claims.ToArray()[0].Value != userId.ToString())
            {
                return false;
            }
            else {return true;}

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]

        public IActionResult Add([FromForm]UserViewModel userView)
        {
            try
            {
                var user = new User(userView.name, userView.email, userView.userPassword, userView.role);
                
                if(user.Role == Roles.Admin && ! IsAdmin())
                {
                    return Unauthorized("Only admins can create admins");
                }

                _userRepository.Add(user);
                
                return Ok();
            }    
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            if(IsAdmin())
            {
                Console.WriteLine(IsAdmin());
                var users = _userRepository.GetAllUsers();
                return Ok(users);  
            }
            else{return Unauthorized("Only an admin can do this!");
}

        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult<User> GetUser(Guid userId)
        {   
            User? searched = _userRepository.GetUser(userId);

            if(! IsOwner(userId) || ! IsAdmin())
            {
                return Unauthorized("Only the user or an admin can do this!");
            }

            if(IsAdmin(searched) && ! IsOwner(userId))
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

        [HttpDelete]
        [Route("{userId}")]

        public IActionResult RemoveUser(Guid userId)
        {
            if (! IsAdmin())
            {
                return Unauthorized("Only admins can delete profiles");
            }
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
            var user = _userRepository.GetUser(userId);
            
            if(! IsOwner(userId))
            {
                return Unauthorized("Only the owner can edit profile");
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
