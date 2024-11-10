using ProbabilityCalculatorAPI.Exceptions;
using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Services
{
    public class ProbabilityService : IProbabilityService
    {
        private readonly Dictionary<OperationType, ICalculationStrategy> _strategies;

        public ProbabilityService(IEnumerable<ICalculationStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(strategy => strategy.Operation, strategy => strategy);
        }

        public double PerformCalculation(ProbabilityRequest request)
        {
            //if (!Enum.TryParse<OperationType>(request.Operation, true, out var operation))
            //{
            //    throw new ArgumentException("Invalid operation type.");
            //}


            //if (!_strategies.TryGetValue(operation.ToString(), out var strategy))
            //{
            //    throw new UnsupportedOperationException(request.Operation!);
            //}

            if (!_strategies.TryGetValue(request.Operation, out var strategy))
            {
                throw new UnsupportedOperationException($"Operation '{request.Operation}' is not supported.");
            }

            return strategy.Calculate(request.ProbabilityA, request.ProbabilityB);
        }
    }
}
