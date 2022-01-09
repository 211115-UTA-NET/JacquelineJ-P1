using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[BindProperties]
    [BindProperties(SupportsGet = true)]
    public class CountriesController : ControllerBase
    {
        public CountryModel Country { get; set; }
        /*
        [BindProperty]
        public CountryModel Country { get; set; }

        [HttpPost("addcountry1")]
        public IActionResult AddCountry()
        {
            return Ok($"Name = {this.Country.Name}, State = {this.Country.State}, Zipecode = {this.Country.Zipcode}");
            
        }
        */
        /*
        [BindProperty(SupportsGet = true)]
        public CountryModel Country { get; set; }

        [HttpGet("addcountry2")]
        public IActionResult AddCountry()
        {
            return Ok($"Name = {this.Country.Name}, State = {this.Country.State}, Zipecode = {this.Country.Zipcode}");

        }
        */       

        [HttpPost("addcountry3")]
        public IActionResult AddCountry()
        {
            return Ok($"Name = {this.Country.Name}, State = {this.Country.State}, Zipcode = {this.Country.Zipcode}");

        }
        [HttpGet("search")]
        public IActionResult SearchCountries([ModelBinder(typeof(CustomBinder))]string[] countries)
        {
            return Ok(countries);
        }


    }
}
