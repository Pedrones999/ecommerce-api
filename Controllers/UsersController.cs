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
        public ActionResult<List<User>> GetAll()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);            
        }

        // [HttpGet]
        // public ActionResult<User> GetOne(Guid userId)
        // {
        //     var user = _userRepository.GetUser(userId);
        //     return Ok(user);
        // }
    
    }
}
