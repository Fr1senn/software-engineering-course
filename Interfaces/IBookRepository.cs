using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDTO>> GetBooksAsync();

        public Task DeleteBookAsync(int id);

        public Task CreateBookAsync(BookDTO book);
    }
}
