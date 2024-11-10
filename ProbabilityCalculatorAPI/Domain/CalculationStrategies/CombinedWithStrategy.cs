using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public class CombinedWithStrategy : ICalculationStrategy
    {
        public OperationType Operation => OperationType.CombinedWith;
        public double Calculate(double probA, double probB)
        {
            return probA * probB;
        }
    }
}
