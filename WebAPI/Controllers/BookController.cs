using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DataAccess service;

        public BookController(DataAccess service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/books")]
        public async Task<ActionResult<ICollection<Book>>> GetAllBooksAsync()
        {
            try
            {
                var books = await service.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("/DeleteBook/{isbn}")]
        public async Task<ActionResult> DeleteBookAsync(int isbn)
        {
            try
            {
                await service.DeleteBookAsync(isbn);
                return NoContent(); // 204 No Content
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message); // 404 Not Found
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
