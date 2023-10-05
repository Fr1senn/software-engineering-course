using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.Interfaces;

namespace SoftwareEngineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController : ControllerBase
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public RandomNumberController(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomGeneratedNumbers()
        {
            return Ok(await _randomNumberGenerator.GenerateRandomNumbersAsync());
        }
    }
}
