using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Data;
using Project1WebApp.Models;
using Project1WebApp.Repository;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        private List<OrderModel> result = null;
        [HttpGet("")]
        public IActionResult GetOrders()
        {
            Console.WriteLine("GetCustomer method111");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _orderRepository.getOrder(0);
            Console.WriteLine("GetCustomer method333 -- " + result);

            return Ok(result);
        }

        [HttpGet("{order_Id}")]
        public IActionResult GetOrdersByOrderId(int order_Id)
        {
            Console.WriteLine("GetCustomer method111");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- " + repository);
            result = _orderRepository.getOrder(order_Id);
            Console.WriteLine("GetCustomer method333 -- " + result);

            return Ok(result);
        }

        [HttpPost("addorder")]
        public IActionResult AddOrder([FromBody] List<OrderRequest> orderReq)
        {
            Console.WriteLine("Adding Order...");
            return Ok("Created Order with Order-ID: "+ _orderRepository.addOrder(orderReq));
        }
    }
}
