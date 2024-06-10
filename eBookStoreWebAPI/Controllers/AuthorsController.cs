using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> CreateAuthor(Author author)
        {
            _authorService.CreateAuthor(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorId }, author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }
            _authorService.UpdateAuthor(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            _authorService.DeleteAuthor(author);
            return NoContent();
        }
    }
}
