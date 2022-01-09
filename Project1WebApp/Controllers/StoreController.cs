using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;
using Project1WebApp.Repository;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        private List<StoreModel> result = null;

        [HttpPost("add_store")]
        public IActionResult AddStore([FromForm] StoreModel store)
        {
            Console.WriteLine("AddStore method555");
            result = _storeRepository.addNewStore(store);
            Console.WriteLine("add_customer");
            return Ok("AddStore created method666...");

        }

        
        [HttpGet("get_all_stores")]
        public IActionResult GetStore()
        {
            Console.WriteLine("GetAllStore method11111111111111");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _storeRepository.getStores(0);
            Console.WriteLine("Done All products method2 -- " + result);

            return Ok(result);
        }

        [HttpGet("get_store_id/{storeId}")]
        public IActionResult GetProductsByStoreId(int storeId)
        {
            Console.WriteLine("GetStore method333333333");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _storeRepository.getStores(storeId);
            Console.WriteLine("GetStore method4111111144444444 -- " + result);

            return Ok(result);
        }

    }
}
