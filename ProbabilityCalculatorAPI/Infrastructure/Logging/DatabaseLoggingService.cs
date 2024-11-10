namespace ProbabilityCalculatorAPI.Services
{
    public class DatabaseLoggingService : ILoggingService
    {
        public async Task LogAsync(string message)
        {
            await Task.CompletedTask;

            throw new NotImplementedException();
        }
    }
}
