using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;
using Project1WebApp.Repository;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsRepository _orderDetailspository;

        public OrderDetailsController(IOrderDetailsRepository orderDetailspository)
        {
            _orderDetailspository = orderDetailspository;
        }

        private List<OrderDetailsModel> result = null;
        [HttpGet("orders")]
        public IActionResult GetOrderDetails()
        {
            Console.WriteLine("GetOrderDetails method111");
            result = _orderDetailspository.getOrderDetails(null);
            return Ok(result);
        }

        [HttpGet("orders/{orderId}")]
        public IActionResult GetProductsByOrderId(string orderId)
        {
            Console.WriteLine("GetProductsByOrderId method");           
            result = _orderDetailspository.getOrderDetails(orderId);

            return Ok(result);
        }


        [HttpGet("stores/{storeId:int}")]
        public IActionResult GetOrdersByStore(int storeId)
        {
            Console.WriteLine("GetOrdersByStore method");            
            result = _orderDetailspository.getOrdersByStore(storeId);
            return Ok(result);
        }

        [HttpGet("customers/{custId}")]
        public IActionResult GetOrdersByCostumerId(string custId)
        {
            Console.WriteLine("GetOrdersByCostumerId method");
            result = _orderDetailspository.getOrdersByCustomer(custId);
            return Ok(result);
        }
    }
}

