using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            _bookService.CreateBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }
            _bookService.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(book);
            return NoContent();
        }
    }
}
