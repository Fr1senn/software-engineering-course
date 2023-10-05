namespace SoftwareEngineering.Interfaces
{
    public interface IRandomNumberGenerator
    {
        public Task<List<int>> GenerateRandomNumbersAsync(int listLength = 100, int minAllowedValue = 1, int maxAllowedValue = 6);
    }
}
