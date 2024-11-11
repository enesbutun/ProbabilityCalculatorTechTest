using Moq;
using Xunit;
using ProbabilityCalculatorAPI.Services;
using ProbabilityCalculatorAPI.Model;

namespace ProbabilityCalculatorAPI.Tests
{
    public class ProbabilityServiceTests
    {
        private readonly ProbabilityService _probabilityService;

        public ProbabilityServiceTests()
        {
            var strategies = new List<ICalculationStrategy>
        {
            new CombinedWithStrategy(),
            new EitherStrategy()
        };

            _probabilityService = new ProbabilityService(strategies);
        }

        [Fact]
        public void PerformCalculation_ShouldCalculateCombinedWithOperation()
        {
            var request = new ProbabilityRequest
            {
                Operation = OperationType.CombinedWith,
                ProbabilityA = 0.5,
                ProbabilityB = 0.5
            };

            var result = _probabilityService.PerformCalculation(request);

            Assert.Equal(0.25, result); // 0.5 * 0.5 = 0.25
        }

        [Fact]
        public void PerformCalculation_ShouldCalculateEitherOperation()
        {
            var request = new ProbabilityRequest
            {
                Operation = OperationType.Either,
                ProbabilityA = 0.5,
                ProbabilityB = 0.5
            };

            var result = _probabilityService.PerformCalculation(request);

            Assert.Equal(0.75, result); // 0.5 + 0.5 - (0.5 * 0.5) = 0.75
        }

    }

}