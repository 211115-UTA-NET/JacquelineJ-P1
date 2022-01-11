using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        
        /*
        [HttpPost("")]
        public IActionResult AddProduct([FromBody]ProductModel product)
        {
            _productRepository.AddProduct(product);
            var products = _productRepository.GetAllProducts();

            return Ok(products);
        }
        */


        private List<ProductModel> result = null;
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            Console.WriteLine("GetAllProduct start");
            result = _productRepository.getProducts(0);
            Console.WriteLine("Done GetAllProduct " + result);
            return Ok(result);
        }

        [HttpGet("products/{storeId:int}")]
        public IActionResult GetProductsByStoreId(int storeId)
        {
            Console.WriteLine("GetProductsByStoreId start");
            result = _productRepository.getProducts(storeId);
            Console.WriteLine("Done GetProductsByStoreId -- " + result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromForm] ProductModel product)
        {
            Console.WriteLine("AddProduct start..");
            _productRepository.addNewProduct(product);
            return Ok("Added Product ..");
        }

        [HttpPatch("update")]
        public IActionResult UpdateProductQuantity([FromForm] JsonPatchDocument product, [FromForm] int ProductId, [FromForm] int ProductQuantity)
        {
            Console.WriteLine(" UpdateProductQuantity Start ..");
            _productRepository.updateProductQuantity(ProductId, ProductQuantity);            
            return Ok("Updated Product Quantity...");
        }
    } 
}


