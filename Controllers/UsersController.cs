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
        
        private readonly AppDbContext _connectionDb;
        
        public UsersController(AppDbContext connectionDb)
        {
            _connectionDb = connectionDb;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok();            
        }
    }
}
