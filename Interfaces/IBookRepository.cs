using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDTO>> GetBooksAsync();

        public Task DeleteBookAsync(int bookId);

        public Task CreateBookAsync(BookDTO book);
    }
}
