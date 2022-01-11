using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;
using Project1WebApp.Repository;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerModel customer { get; set; }

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private List<CustomerModel> result = null;
        [HttpGet("")]
        public IActionResult GetCustomers()
        {
           Console.WriteLine("GetCustomers ");
            result = _customerRepository.getCustomers(null);
            return Ok(result);
        }

        [HttpGet("{cusName:alpha}")]
        public IActionResult GetCustomerByName(string cusName)
        {            
            result = _customerRepository.getCustomers(cusName);
            return Ok(result);
        }

        [HttpPost("add_customer")]
        public IActionResult AddCustomer([FromForm]CustomerModel customer)
        {
            Console.WriteLine("AddCustomer...");
            result = _customerRepository.addCustomerNew(customer);
            Console.WriteLine("add_customer");
           return Ok("customer created...");

        }        
    }
}
