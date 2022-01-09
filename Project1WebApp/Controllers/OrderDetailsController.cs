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
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _orderDetailspository.getOrderDetails(null);
            //Console.WriteLine("GetCustomer method333 -- " + result);

            return Ok(result);
        }

        [HttpGet("orders/{order_Id}")]
        public IActionResult GetProductsByOrderId(string order_Id)
        {
            Console.WriteLine("GetProductsByOrderId method");
            //CustomerRepository repository = new CustomerRepository();
           
            result = _orderDetailspository.getOrderDetails(order_Id);
            //Console.WriteLine("GetCustomer method333 -- " + result);

            return Ok(result);
        }


        [HttpGet("stores/{store_Id}")]
        public IActionResult GetOrdersByStore(int store_Id)
        {
            Console.WriteLine("GetOrdersByStore method");
            //CustomerRepository repository = new CustomerRepository();
            
            result = _orderDetailspository.getOrdersByStore(store_Id);
            //Console.WriteLine("GetCustomer method333 -- " + result);

            return Ok(result);
        }

        [HttpGet("customers/{cust_Id}")]
        public IActionResult GetOrdersByCostumerId(string cust_Id)
        {
            Console.WriteLine("GetOrdersByCostumerId method");
            //CustomerRepository repository = new CustomerRepository();

            result = _orderDetailspository.getOrdersByCustomer(cust_Id);
            //Console.WriteLine("GetCustomer method333 -- " + result);

            return Ok(result);
        }
    }
}

