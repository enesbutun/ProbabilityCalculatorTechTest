using ProbabilityCalculatorAPI.Model;
using System.Threading.Tasks;

namespace ProbabilityCalculatorAPI.Services
{
    public class LogMessageFormatter : ILogMessageFormatter
    {
        public string Format(LogEntry logEntry)
        {
            return $"{logEntry.Timestamp}: Operation={logEntry.Operation}, P(A)={logEntry.ProbabilityA}, P(B)={logEntry.ProbabilityB}, Result={logEntry.Result}";
        }
    }
}
