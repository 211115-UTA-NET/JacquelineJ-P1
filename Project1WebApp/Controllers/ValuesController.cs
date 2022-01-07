using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1WebApp.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        
        [Route("api/get-all")]
        public string GetAll()
        {
            return "hello from get all";
        }

        //[Route("[controller]/[action]")]
        [Route("getallauthors")]
        [Route("~api/get-all-authors")]
        public string GetAllAuthor()
        {
            return "Hello from get all author";
        }

        //[Route("[controller]/[action]")]
        [Route("books/{id}")]
        public string GetById(int id)
        {
            return "Hello from get "+id;
        }

        //[Route("[controller]/[action]")]
        [Route("books/{id}/author/{authorId}")]
        public string GetAuthorById(int id,int authorId)
        {
            return "Hello from get " + id +" Author "+ authorId;
        }

       // [Route("[action]/[controller]")]
        //[Route("[controller]/[action]")]


        [Route("search")]
        public string SearchBooks(int id, int authorId, string name,int rating, int price)
        {
            return "Hello from get " + id + " Author " + authorId+" name "+name+" rating "+rating;
        }

    }
}
