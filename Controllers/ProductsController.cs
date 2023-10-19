using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Connection;
using Products.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

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
        
        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm]ProductViewModel productView)
        {
            string? imagePath = null;

            if (productView.image != null)
            {
                imagePath = Path.Combine("Images", productView.image.FileName);
            }
            
            var product = new Product(productView.name, productView.price, productView.description, imagePath);
            
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

        [Authorize]
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

        [Authorize]
        [HttpPatch]
        [Route("{productId}")]
        
        public IActionResult UpdateProduct([FromForm]ProductViewModel productView, Guid productId)
        {
            var product = _productRepository.GetProduct(productId);
            
            if(product != null)
            {   
                if(productView.image != null)
                {
                    var imagePath = Path.Combine("Images", productView.image.FileName);
                    _productRepository.UpdateProduct(productId, imagePath: imagePath);
                }
                
                if (productView.name != null)
                {
                    _productRepository.UpdateProduct(productId, name: productView.name);
                }

                if (productView.price != null && productView.price > 0)
                {
                    _productRepository.UpdateProduct(productId, price: productView.price);
                }
                if(productView.description != null)
                {
                    _productRepository.UpdateProduct(productId, description: productView.description);
                }
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}       