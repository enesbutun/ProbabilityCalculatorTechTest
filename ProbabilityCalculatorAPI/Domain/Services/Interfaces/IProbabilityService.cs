using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public interface IProbabilityService
    {
        double PerformCalculation(ProbabilityRequest request);
    }
}
