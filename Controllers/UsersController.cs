using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Connection;

namespace Users.Controller
{
    [Route("api/Users")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        
        private readonly UserConnectionDb _connectionDb;
        
        public UsersController(UserConnectionDb connectionDb)
        {
            _connectionDb = connectionDb;
        }
    }
}
