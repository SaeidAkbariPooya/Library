using Library.Application.Dto;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Cto
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAsync()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }
        #endregion

        #region GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> GetByIdAsync(int id)
        {
            if (id == 0) return BadRequest();
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
        #endregion

        #region Add
        [HttpPost]
        public async Task<ActionResult<AddBookViewModel>> PostAsync(AddBookViewModel book)
        {
            await _bookService.AddBookAsync(book);
            return Ok();
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, BookViewModel book)
        {
            if (id != book.BookId || id == 0 || book.BookId == 0) return BadRequest();
            await _bookService.UpdateBookAsync(book);
            return Ok();
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest();
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
        #endregion
    }
}
