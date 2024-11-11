using Xunit;
using ProbabilityCalculatorAPI.Services;

namespace ProbabilityCalculatorAPI.Tests
{
    public class CalculationStrategiesTests
    {
        [Fact]
        public void CombinedWithStrategy_ShouldReturnCorrectResult()
        {
            var strategy = new CombinedWithStrategy();
            var result = strategy.Calculate(0.5, 0.5);
            Assert.Equal(0.25, result); // 0.5 * 0.5 = 0.25
        }

        [Fact]
        public void EitherStrategy_ShouldReturnCorrectResult()
        {
            var strategy = new EitherStrategy();
            var result = strategy.Calculate(0.5, 0.5);
            Assert.Equal(0.75, result); // 0.5 + 0.5 - (0.5 * 0.5) = 0.75
        }

        [Fact]
        public void CombinedWithStrategy_ProbabilitiesAtZero_ShouldReturnZero()
        {
            var strategy = new CombinedWithStrategy();
            var result = strategy.Calculate(0, 0);
            Assert.Equal(0, result); // 0 * 0 = 0
        }

        [Fact]
        public void CombinedWithStrategy_ProbabilitiesAtOne_ShouldReturnOne()
        {
            var strategy = new CombinedWithStrategy();
            var result = strategy.Calculate(1, 1);
            Assert.Equal(1, result); // 1 * 1 = 1
        }

        [Fact]
        public void CombinedWithStrategy_OneProbabilityIsZero_ShouldReturnZero()
        {
            var strategy = new CombinedWithStrategy();
            var result = strategy.Calculate(0, 0.5);
            Assert.Equal(0, result); // 0 * 0.5 = 0
        }

        [Fact]
        public void CombinedWithStrategy_NonStandardProbabilities_ShouldReturnCorrectResult()
        {
            var strategy = new CombinedWithStrategy();
            var result = strategy.Calculate(0.3, 0.7);
            Assert.Equal(0.21, result); // 0.3 * 0.7 = 0.21
        }

        [Fact]
        public void EitherStrategy_ProbabilitiesAtZero_ShouldReturnZero()
        {
            var strategy = new EitherStrategy();
            var result = strategy.Calculate(0, 0);
            Assert.Equal(0, result); // 0 + 0 - (0 * 0) = 0
        }

        [Fact]
        public void EitherStrategy_ProbabilitiesAtOne_ShouldReturnOne()
        {
            var strategy = new EitherStrategy();
            var result = strategy.Calculate(1, 1);
            Assert.Equal(1, result); // 1 + 1 - (1 * 1) = 1
        }

        [Fact]
        public void EitherStrategy_OneProbabilityIsZero_ShouldReturnOtherProbability()
        {
            var strategy = new EitherStrategy();
            var result = strategy.Calculate(0, 0.6);
            Assert.Equal(0.6, result); // 0 + 0.6 - (0 * 0.6) = 0.6
        }

        [Fact]
        public void EitherStrategy_NonStandardProbabilities_ShouldReturnCorrectResult()
        {
            var strategy = new EitherStrategy();
            var result = strategy.Calculate(0.3, 0.7);
            Assert.Equal(0.79, result, 2); // 0.3 + 0.7 - (0.3 * 0.7) = 0.79
        }
    }

}
