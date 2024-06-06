

using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly DataAccess service;

        public AuthorController(DataAccess service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("/author")]

        public async Task<ActionResult> CreateAuthorAsync(Author author)
        {
            try
            {
                Author createdAuthor = await service.CreateAuthorAsync(author);
                return Created($"/author/{createdAuthor.LastName}", author);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/authors")]
        public async Task<ActionResult<ICollection<Author>>> GetAllAuthorsAsync()
        {
            try
            {
                var authors = await service.GetAllAuthorsAsync();
                return Ok(authors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("/AddBookToAuthor")]
        public async Task<ActionResult> AddBookToAuthor(string title, int pubYear, int numOfPages, string genre, int id)
        {
            try
            {
                Book bookToAdd = new Book(title, pubYear, numOfPages, genre);

                await service.AddBookToAuthor(bookToAdd, id);
                return Created($"/AddBookToAuthor/{bookToAdd.ISBN}", bookToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
