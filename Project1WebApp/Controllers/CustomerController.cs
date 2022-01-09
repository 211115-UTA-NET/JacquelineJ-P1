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
           //Console.WriteLine("GetCustomer method111");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- "+ repository);
            result = _customerRepository.getCustomers(null);
            //Console.WriteLine("GetCustomer method333 -- "+result);

            return Ok(result);
        }

        [HttpGet("{cusName}")]
        public IActionResult GetCustomerByName(string cusName)
        {
            //Console.WriteLine("GetCustomer method111");
            //CustomerRepository repository = new CustomerRepository();
            //Console.WriteLine("GetCustomer method222 -- "+ repository);
            result = _customerRepository.getCustomers(cusName);
            //Console.WriteLine("GetCustomer method333 -- "+result);

            return Ok(result);
        }
        /*
          public int Customer_Id { get; set; }
        public string? Customer_FirstName { get; set; }
        public string? Customer_LastName { get; set; }
        public string? Customer_City { get; set; }
        
        public string? Customer_State { get; set; }
         */

        [HttpPost("add_customer")]
        public IActionResult AddCustomer([FromForm]CustomerModel customer)
        {
            Console.WriteLine("AddCustomer...");
            result = _customerRepository.addCustomerNew(customer);
            Console.WriteLine("add_customer");
           return Ok("customer created...");

        }
        /*

        [HttpPost("addcountry3")]
        public IActionResult AddCountry()
        {
            return Ok($"Name = {this.Country.Name}, State = {this.Country.State}, Zipcode = {this.Country.Zipcode}");

        }
        */
    }
}
