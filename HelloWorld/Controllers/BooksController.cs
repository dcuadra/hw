using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Model;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService libraryService;

        public BooksController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }
        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> Get()
        {
            return libraryService.LoadBooks();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<BookModel> Get(int id)
        {
            return libraryService.LoadBook(id);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put([FromBody] BookModel value)
        {
            libraryService.SaveBook(value);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            libraryService.RemoveBook(id);
        }
    }
}
