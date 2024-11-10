using ProbabilityCalculatorAPI.Model;
using System.Threading.Tasks;

namespace ProbabilityCalculatorAPI.Services
{
    public interface ILogMessageFormatter
    {
        string Format(LogEntry logEntry);
    }
}
