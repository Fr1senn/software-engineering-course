using SoftwareEngineering.Interfaces.Services;

namespace SoftwareEngineering.Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public Task<List<int>> GenerateRandomNumbersAsync(int listLength = 100, int minAllowedValue = 1, int maxAllowedValue = 6)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            Task.Run(() =>
            {
                for (int i = 0; i < listLength; i++)
                {
                    lock (random)
                    {
                        numbers.Add(random.Next(minAllowedValue, maxAllowedValue + 1));
                    }
                }
            });

            return Task.FromResult(numbers);
        }
    }
}
