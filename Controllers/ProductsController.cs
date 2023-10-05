using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Model;

namespace Products.Controller
{
    [Route("api/Products")]
    [ApiController]

    public class ProductsController : ControllerBase 
    {
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok("Ok, products");

        }
    }
}       