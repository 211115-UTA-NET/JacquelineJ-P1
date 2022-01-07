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

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private List<CustomerModel> result = null;
        [HttpGet("")]
        public IActionResult GetCustomers()
        {
            Console.WriteLine("GetCustomer method111");
            CustomerRepository repository = new CustomerRepository();
            Console.WriteLine("GetCustomer method222 -- "+ repository);
            result = repository.getCustomers(null);
            Console.WriteLine("GetCustomer method333 -- "+result);

            return Ok(result);
        }
    }
}
