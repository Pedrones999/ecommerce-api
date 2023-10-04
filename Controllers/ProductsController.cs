using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Model;

namespace Products.ControllerS
{
    [Route("api/Products")]
    [ApiController]

    public class ProductsController : ControllerBase 
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Ok();

        }
    }
}       