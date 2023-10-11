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

        public async Task DeleteBookAsync(int id)
        {
            Book? book = await _libraryContext.Books.FindAsync(id);
            if (book is null)
                throw new NullReferenceException("Book not found");
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
        }
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
