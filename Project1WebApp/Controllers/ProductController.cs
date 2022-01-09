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
        [HttpGet("get_all_products")]
        public IActionResult GetProducts()
        {
            Console.WriteLine("GetAllProduct method1");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _productRepository.getProducts(0);
            Console.WriteLine("Done All products method2 -- " + result);

            return Ok(result);
        }

        [HttpGet("get_product_id/{storeId}")]
        public IActionResult GetProductsByStoreId(int storeId)
        {
            Console.WriteLine("GetProduct method3");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _productRepository.getProducts(storeId);
            Console.WriteLine("GetProduct method4 -- " + result);

            return Ok(result);
        }

        [HttpPost("add_product")]
        public IActionResult AddProduct([FromForm] ProductModel product)
        {
            Console.WriteLine("AddProduct method555");
            result = _productRepository.addNewProduct(product);
            Console.WriteLine("add_customer");
            return Ok("AddProduct created method666...");

        }


        [HttpPatch("update_prod_quantity")]
        public IActionResult UpdateProductQuantity([FromForm] JsonPatchDocument product, [FromForm] int ProductId, [FromForm] int ProductQuantity)
        {
            Console.WriteLine("UpdateProduct method777");
            result = _productRepository.updateProductQuantity(ProductId, ProductQuantity);
            Console.WriteLine("add_customer");
            return Ok("UpdateProduct created method888...");

        }
    } 

}


