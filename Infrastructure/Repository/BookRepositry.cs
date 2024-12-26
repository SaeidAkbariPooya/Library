using Library.Core.Interfaces;
using Library.Core.Models;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class BookRepositry : IBookRepository
    {
        #region Cto
        private readonly LibraryDbContext _context;
        public BookRepositry(LibraryDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetById
        public async Task<Book> GetByIdAsync(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(o => o.BookId == id);
            return result;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        #endregion

        #region Add
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
