using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public class LogService : ILogService
    {
        private readonly ILoggingService _loggingService;
        private readonly ILogMessageFormatter _formatter;

        public LogService(LoggingServiceFactory factory, ILogMessageFormatter formatter)
        {
            _loggingService = factory.CreateLoggingService();
            _formatter = formatter;
        }

        public LogEntry CreateLogEntry(string operation, double probabilityA, double probabilityB, double result)
        {

            return new LogEntry
            {
                Operation = operation,
                ProbabilityA = probabilityA,
                ProbabilityB = probabilityB,
                Result = result
            };
        }

        public async Task LogCalculationAsync(LogEntry logEntry)
        {
            string logMessage = _formatter.Format(logEntry);

            await _loggingService.LogAsync(logMessage);
        }
    }
}
