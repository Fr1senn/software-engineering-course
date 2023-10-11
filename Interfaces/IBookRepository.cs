using SoftwareEngineering.Models;

namespace SoftwareEngineering.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDTO>> GetBooksAsync();

        public Task DeleteBookAsync(int id);
    }
}
