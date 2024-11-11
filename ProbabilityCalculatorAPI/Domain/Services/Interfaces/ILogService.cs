using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public interface ILogService
    {
        LogEntry CreateLogEntry(string operation, double probabilityA, double probabilityB, double result);

        Task LogCalculationAsync(LogEntry logEntry);

    }
}
