using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.Interfaces;
using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await _bookRepository.GetBooksAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync([FromQuery] int bookId)
        {
            try
            {
                await _bookRepository.DeleteBookAsync(bookId);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDTO book)
        {
            try
            {
                await _bookRepository.CreateBookAsync(book);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
