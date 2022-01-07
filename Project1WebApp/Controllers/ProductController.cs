using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;
using Project1WebApp.Repository;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        
        [HttpPost("")]
        public IActionResult AddProduct([FromBody]ProductModel product)
        {
            _productRepository.AddProduct(product);
            var products = _productRepository.GetAllProducts();

            return Ok(products);
        }
    }
}
