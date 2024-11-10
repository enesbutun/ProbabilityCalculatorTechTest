using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public interface ICalculationStrategy
    {
        OperationType Operation { get; }
        double Calculate(double probA, double probB);
    }
}
