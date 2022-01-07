using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1WebApp.Models;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<AnimalModel> animals = null;
        public AnimalsController()
        {
            animals = new List<AnimalModel>()
            {
                new AnimalModel() { Id =1,Name ="Dog"},
                new AnimalModel() { Id =2,Name ="Lion"}
            };

        }
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel() { Id =1,Name ="Dog"},
                new AnimalModel() { Id =2,Name ="Lion"}
            };
            return Ok(animals);
        }

        [Route("test")]
        public IActionResult GetAnimalsTest()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel() { Id =1,Name ="Dog"},
                new AnimalModel() { Id =2,Name ="Lion"}
            };
            return Accepted();
        }
        [Route("test2")]
        public IActionResult GetAnimalsTest2()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel() { Id =1,Name ="Dog"},
                new AnimalModel() { Id =2,Name ="Lion"}
            };
            return AcceptedAtAction("GetAnimals");
        }

        [Route("{name}")]
        public IActionResult GetAnimalsByName(string name)
        {
            if (!name.Contains("ABC"))
            {
                return BadRequest();

            }
            return Ok(animals);
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalsById(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }
            return Ok(animals.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("",Name ="All")]
        public IActionResult GetAnimals(AnimalModel animal)
        {
            animals.Add(animal);

            return Created("~/api/animals"+ animal.Id,animal);
        }
    }
}
