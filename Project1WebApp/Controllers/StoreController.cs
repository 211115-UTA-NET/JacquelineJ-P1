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
        private List<StoreModel> results = null;
        private StoreModel result = null;

        [HttpPost("addStore")]
        public IActionResult AddStore([FromBody] StoreModel store)
        {
            Console.WriteLine("Adding Store");
            _storeRepository.addNewStore(store);
            return Ok("Created Store ");
        }
        
        [HttpGet("stores")]
        public IActionResult GetStores()
        {
            Console.WriteLine("Get All Stores");
            results = _storeRepository.getAllStores();
            return Ok(results);
        }

        [HttpGet("stores/{storeId:int}")]
        public IActionResult GetStoreById(int storeId)
        {
            Console.WriteLine("Get Store by StoreId - "+ storeId);
            result = _storeRepository.getStore(storeId);
            Console.WriteLine("Get Store by StoreId " + result);

            return Ok(result);
        }

    }
}
