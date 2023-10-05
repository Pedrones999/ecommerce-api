using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Model;

namespace Users.Controller
{
    [Route("api/Users")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        [HttpGet]

        public ActionResult<List<User>> Get()
        {
            return Ok("Ok,  users");
        }
    }
}
