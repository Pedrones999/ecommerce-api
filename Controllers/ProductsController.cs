using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Connection;

namespace Products.Controller
{
    [Route("api/Products")]
    [ApiController]

    public class ProductsController : ControllerBase 
    {
        
        private readonly ProdConnectionDb _connectionDb;
        
        public ProductsController(ProdConnectionDb connectionDb)
        {
            _connectionDb = connectionDb;
        }
    }
}       