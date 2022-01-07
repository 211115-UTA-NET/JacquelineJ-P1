using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        /* public EmployeeModel GetEmployees()
         {
             return new EmployeeModel() { Id = 1, Name = "Employee 1" };
         }*/
        [Route("")]
        public List<EmployeeModel> GetEmployees()
        {
            return new List<EmployeeModel>() {
                new EmployeeModel() {Id = 1, Name = "Alex" },
                new EmployeeModel() {Id = 1, Name = "Rosey" } };
        }

        /* public IEnumerable<EmployeeModel> GetEmployees()
         {
             return new List<EmployeeModel>() {
                 new EmployeeModel() {Id = 1, Name = "Alex" },
                 new EmployeeModel() {Id = 1, Name = "Rosey" } };
         }*/

        /* public IAsyncEnumerable<EmployeeModel> GetEmployees()
         {
             return new List<EmployeeModel>() {
                 new EmployeeModel() {Id = 1, Name = "Alex" },
                 new EmployeeModel() {Id = 1, Name = "Rosey" } };
         }*/
        [Route("{id}")]
        public IActionResult GetEmployees(int id)
        {
           

            if(id == 0)
            {
                return NotFound();
            }
            return Ok( new List<EmployeeModel>() {
                new EmployeeModel() {Id = 1, Name = "Alex" },
                new EmployeeModel() {Id = 1, Name = "Rosey" } } );
        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeeBasicDetails(int id)
        {


            if (id == 0)
            {
                return NotFound();
            }
            return new EmployeeModel() { Id = 1, Name = "Alex" };
                
        }

    }
}
