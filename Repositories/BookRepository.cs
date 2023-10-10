using Microsoft.EntityFrameworkCore;
using SoftwareEngineering.Interfaces;
using SoftwareEngineering.Models;

namespace SoftwareEngineering.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<BooksAuthor>> GetBooksAsync()
        {
            List<BooksAuthor> books = await _libraryContext.BooksAuthors
                .Include(bA => bA.Book)
                .Include(bA => bA.Author)
                .AsNoTracking()
                .ToListAsync();
            return books;
        }
    }
}
