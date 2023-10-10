using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Connection;
using Users.Model;

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
        public IActionResult Add(UserViewModel userView)
        {
            var user = new User(userView.name, userView.email, userView.userPassword, userView.role);
            _userRepository.Add(user);
            return Ok();
        }
        
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

        [HttpDelete]
        [Route("{userId}")]

        public IActionResult RemoveUser(Guid userId)
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
    }
}
