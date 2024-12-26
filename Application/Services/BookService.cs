using Library.Application.Dto;
using Library.Application.Interfaces;
using Library.Core.Interfaces;
using Library.Core.Models;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        #region Cto
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(book => new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear,
                Genre = book.Genre
            });
        }
        #endregion

        #region GetById
        public async Task<BookViewModel> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null) return null;

            return new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear,
                Genre = book.Genre
            };
        }
        #endregion

        #region Add
        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                PublishedYear = model.PublishedYear,
                Genre = model.Genre
            };
            await _bookRepository.AddAsync(book);
        }
        #endregion

        #region Update
        public async Task UpdateBookAsync(BookViewModel model)
        {
            var book = new Book
            {
                BookId = model.BookId,
                Title = model.Title,
                Author = model.Author,
                PublishedYear = model.PublishedYear,
                Genre = model.Genre
            };
            await _bookRepository.UpdateAsync(book);
        }
        #endregion

        #region Delete
        public async Task DeleteBookAsync(int bookId) => await _bookRepository.DeleteAsync(bookId);
        #endregion
    }
}
