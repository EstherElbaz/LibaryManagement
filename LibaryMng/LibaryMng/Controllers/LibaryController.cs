using LibaryMng.Entities;
using LibaryMng.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibaryMng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibaryController : ControllerBase
    {
        private readonly ILibaryService _libaryService;
        public LibaryController(ILibaryService libaryService)
        {
            _libaryService = libaryService;
        }

        [HttpGet]
        public async Task<ActionResult> LoadBooks()
        {
            await _libaryService.LoadBooks();
            return Ok();
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            await _libaryService.LoadBooks();
            List<Book> booksToReturn = _libaryService.getAllBooks();
            if (booksToReturn != null &&booksToReturn.Any())
            {
                return Ok(booksToReturn);
            }
            return NoContent();
        }

        [HttpPost("addBook")]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book bookToAdd)
        {
            await _libaryService.LoadBooks();
            Book newBook = await _libaryService.addBook(bookToAdd);
            return Ok(newBook);
        }

        [HttpPost("archiveBook/{bookId}")]
        public async Task<ActionResult> archiveBook(string bookId)
        {
            await _libaryService.LoadBooks();
            await _libaryService.archiveBook(bookId);
            return Ok();
        }

        [HttpGet("getBookByName")]
        public async Task<ActionResult<Book>> getBookByName([FromQuery] string Title)
        {
            await _libaryService.LoadBooks();
            Book bookToReturn =  _libaryService.getBookByName(Title);
            if (bookToReturn != null)
            {
                return Ok(bookToReturn);
            }
            return NoContent();
        }

        [HttpGet("getBookByAuthor")]
        public async Task<ActionResult<IEnumerable<Book>>> getBookByAuthor([FromQuery] string authorId)
        {
            await _libaryService.LoadBooks();
            List<Book> booksToReturn = _libaryService.getBooksByAuthor(authorId);
            if (booksToReturn != null &&booksToReturn.Count!=0)
            {
                return Ok(booksToReturn);
            }
            return NotFound();
        }

        [HttpGet("getBookByCategory")]
        public async Task<ActionResult<IEnumerable<Book>>> getBookByCategory([FromQuery] string category)
        {
            await _libaryService.LoadBooks();
            List<Book> booksToReturn = _libaryService.getBooksByCategory(category);
            if (booksToReturn != null && booksToReturn.Count != 0)
            {
                return Ok(booksToReturn);
            }
            return NotFound();
        }

        [HttpGet("availableBooks")]
        public async Task<ActionResult<IEnumerable<Book>>> getAvailableBooks()
        {
            await _libaryService.LoadBooks();
            List<Book> booksToReturn = _libaryService.getAvailableBooks();
            if (booksToReturn != null&& booksToReturn.Count!=0)
            {
                return Ok(booksToReturn);
            }
            return NoContent();
        }

        [HttpGet("getOverdueBooks")]
        public async Task<ActionResult<List<Book>>> getOverdueBooks([FromQuery] int days)
        {
            await _libaryService.LoadBooks();
            List<Book> booksToReturn = _libaryService.getOverdueBooks(days);
            if (booksToReturn != null && booksToReturn.Count != 0)
            {
                return Ok(booksToReturn);
            }
            return NoContent();
        }
    }
}
