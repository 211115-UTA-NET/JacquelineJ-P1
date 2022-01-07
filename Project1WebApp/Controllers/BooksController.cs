using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("{id:int:min(10):max(100)}")]
        public string GetByIdl(int id)
        {
            return "hello Jackie from int "+id;
        }

        [Route("{id:minlength(5):alpha}")]
        public string GetByString(string id)
        {
            return "hello from get string "+id;
        }

        [Route("{id:regex(a(b|c))}")]
        public string GetByIdRegex(string id)
        {
            return "hello from get string " + id;
        }
    }
}
