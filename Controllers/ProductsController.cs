using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Connection;
using Products.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Products.Controller
{
    [Route("api/[Controller]")]
    [ApiController]

    public class ProductsController : ControllerBase 
    {
        
        private readonly IProductRepository _productRepository;
        
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpPost]
        public IActionResult Add(ProductViewModel productView)
        {
            var product = new Product(productView.name, productView.price, productView.description);
            _productRepository.Add(product);
            return Ok();            
        }
    
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products);
        }

        // [HttpGet]
        // public IActionResult GetOne(Guid productId)
        // {
        //     var product = _productRepository.GetProduct(productId);
        //     return Ok(product);
        // }
    }
}       