using Microsoft.EntityFrameworkCore;
using SoftwareEngineering.Interfaces;
using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task CreateBookAsync(BookDTO bookDTO)
        {
            if (bookDTO is null)
                throw new NullReferenceException("Invalid Data");

            Book book = new Book
            {
                Title = bookDTO.Title,
                PublicationDate = bookDTO.PublicationDate,
                Orders = new List<Order>(),
                BooksAuthors = new List<BooksAuthor>()
            };

            if (bookDTO.Authors != null)
            {
                foreach (var authorDTO in bookDTO.Authors)
                {
                    var existingAuthor = await _libraryContext.Authors.SingleOrDefaultAsync(a => a.FullName == authorDTO.FullName);

                    if (existingAuthor != null)
                    {
                        var booksAuthor = new BooksAuthor
                        {
                            AuthorId = existingAuthor.Id,
                            Book = book
                        };

                        book.BooksAuthors.Add(booksAuthor);
                    }
                    else
                    {
                        throw new NullReferenceException("Author not found");
                    }
                }
            }

            _libraryContext.Books.Add(book);
            await _libraryContext.SaveChangesAsync();
        }

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
