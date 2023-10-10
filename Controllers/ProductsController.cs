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

        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetOne(Guid productId)
        {
            var product = _productRepository.GetProduct(productId);

            if(product != null)
            {
                return Ok(product);
            }
            
            else{ return NotFound(); }
        }

        [HttpDelete]
        [Route("{productId}")]

        public IActionResult RemoveProduct(Guid productId)
        {
            var product = _productRepository.GetProduct(productId);
            if(product != null)
            {
                _productRepository.RemoveProduct(productId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}       