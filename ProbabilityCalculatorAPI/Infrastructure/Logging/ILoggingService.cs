
using System.Threading.Tasks;

namespace ProbabilityCalculatorAPI.Services
{
    public interface ILoggingService
    {
        Task LogAsync(string message);
    }
}
