
using Library.Application.Dto;
using Library.Core.Models;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetBooksAsync();
        Task<BookViewModel> GetBookByIdAsync(int bookId);
        Task AddBookAsync(AddBookViewModel book);
        Task UpdateBookAsync(BookViewModel book);
        Task DeleteBookAsync(int bookId);
    }
}
