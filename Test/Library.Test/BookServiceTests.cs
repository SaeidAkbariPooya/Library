using Library.Application.Dto;
using Library.Application.Services;
using Library.Core.Interfaces;
using Library.Core.Models;
using Moq;
using Xunit;

namespace Library.Test
{
    public class BookServiceTests
    {
        #region Ctr
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockRepository.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetBooksAsync()
        {
            // Arrange  
            var books = new List<Book>
            {
                new Book { BookId = 1, Title = "My Life 1", Author = "Saeid AkbariPooya", PublishedYear = 2022, Genre = "Social" },
                new Book { BookId = 2, Title = "My Life 2", Author = "Saeid AkbariPooya", PublishedYear = 2025, Genre = "Drama" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(books);

            // Act  
            var result = await _bookService.GetBooksAsync();

            // Assert  
            Assert.Equal(2, result.Count());
            Assert.Equal("My Life 1", result.First().Title);
        }
        #endregion

        #region GetById
        [Fact]
        public async Task GetBookByIdAsync()
        {
            // Arrange  
            var book = new Book { BookId = 1, Title = "My Life 1", Author = "Saeid AkbariPooya", PublishedYear = 2022, Genre = "Social" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(book);

            // Act  
            var result = await _bookService.GetBookByIdAsync(1);

            // Assert  
            Assert.NotNull(result);
            Assert.Equal("My Life 1", result.Title);
        }
        #endregion

        #region Add
        [Fact]
        public async Task AddBookAsync()
        {
            // Arrange  
            var newBook = new AddBookViewModel
            {
                Title = "My Life 1",
                Author = "Saeid AkbariPooya",
                PublishedYear = 2022,
                Genre = "Social"
            };

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);

            // Act  
            await _bookService.AddBookAsync(newBook); // فراخوانی متد  

            // Assert  
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Book>()), Times.Once);
        }
        #endregion

        #region Update
        [Fact]
        public async Task UpdateBookAsync()
        {
            var bookToUpdateViewModel = new BookViewModel
            {
                BookId = 1,
                Title = "My Life 1",
                Author = "Saeid AkbariPooya",
                PublishedYear = 2022,
                Genre = "Social"
            };

            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);

            // Act  
            await _bookService.UpdateBookAsync(bookToUpdateViewModel); // فراخوانی متد  

            // Assert  
            _mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Book>()), Times.Once);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task DeleteBookAsync()
        {
            // Arrange  
            int bookIdToDelete = 1;

            // Act  
            await _bookService.DeleteBookAsync(bookIdToDelete);

            // Assert  
            _mockRepository.Verify(repo => repo.DeleteAsync(bookIdToDelete), Times.Once);
        }
        #endregion
    }
}
