using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Model;
using Products.Model;
using Microsoft.AspNetCore.Authorization;
using static GenericTools.GenericTools;


namespace Products.Controller
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]

    public class ProductsController : ControllerBase 
    {
        private bool IsAdmin()
        {
            if(User.Claims.ToArray()[1].Value != Roles.Admin.ToString())
            {
                return false;
            }
            else {return true;}
        }
        private readonly IProductRepository _productRepository;
        
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpPost]
        public IActionResult Add([FromForm]ProductViewModel productView)
        {
            if(! IsAdmin())
            {
                return Unauthorized("Only admins can do this");
            }

            try
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
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }

            }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            try
            {
                var claims = User.Claims;

                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch(Exception error)
            {
                string message = errorFilter(error);
                return BadRequest(message);
            }
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetOne(Guid productId)
        {
            try
            {
                var product = _productRepository.GetProduct(productId);

                if(product != null)
                {
                    return Ok(product);
                }
                
                else{ return NotFound(); }    
            }
            
            catch(Exception error)
            {
                string message = errorFilter(error);
                return BadRequest(message);
            }
        }

        [HttpDelete]
        [Route("{productId}")]

        public IActionResult RemoveProduct(Guid productId)
        {
            if(! IsAdmin())
            {
                return Unauthorized("Only admins can do this");
            }

            try
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
            
            catch(Exception error)
            {
                string message = errorFilter(error);
                return BadRequest(message);
            }
            
        }

        [HttpPatch]
        [Route("{productId}")]
        
        public IActionResult UpdateProduct([FromForm]ProductViewModel productView, Guid productId)
        {
            if(! IsAdmin())
            {
                return Unauthorized("Only admins can do this");
            }
        
            try
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
            
            catch(Exception error)
            {
                string message = errorFilter(error);
                return BadRequest(message);
            }
        }
    }
}       