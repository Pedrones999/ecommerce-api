using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Connection;
using Products.Model;

namespace Products.Controller
{
    [Route("api/[Controller]")]
    [ApiController]

    public class ProductsController : ControllerBase 
    {
        
        private readonly AppDbContext _connectionDb;
        
        public ProductsController(AppDbContext connectionDb)
        {
            _connectionDb = connectionDb;
        }
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok();            
        }
    }
}       