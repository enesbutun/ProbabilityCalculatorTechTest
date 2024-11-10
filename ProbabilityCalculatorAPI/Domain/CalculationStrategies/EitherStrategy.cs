using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public class EitherStrategy : ICalculationStrategy
    {
        public OperationType Operation => OperationType.Either;

        public double Calculate(double probA, double probB)
        {
            return probA + probB - (probA * probB);
        }
    }
}
