
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProbabilityCalculatorAPI.Controllers;
using ProbabilityCalculatorAPI.Model;
using ProbabilityCalculatorAPI.Services;


namespace ProbabilityCalculatorAPI.Tests
{
    public class ProbabilityControllerTests
    {
        private readonly Mock<IProbabilityService> _probabilityServiceMock;
        private readonly Mock<ILogService> _logServiceMock;
        private readonly ProbabilityController _controller;

        public ProbabilityControllerTests()
        {
            _probabilityServiceMock = new Mock<IProbabilityService>();
            _logServiceMock = new Mock<ILogService>();
            _controller = new ProbabilityController(_probabilityServiceMock.Object, _logServiceMock.Object);
        }

        [Fact]
        public async Task Calculate_ValidRequest_ReturnsOkResult()
        {
            var request = new ProbabilityRequest
            {
                Operation = OperationType.CombinedWith,
                ProbabilityA = 0.5,
                ProbabilityB = 0.5
            };

            _probabilityServiceMock.Setup(s => s.PerformCalculation(request)).Returns(0.25);

            var result = await _controller.Calculate(request);

            // Assert that the result is an OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsType<ProbabilityResponse>(okResult.Value);
            Assert.Equal(0.25, returnValue.Result);

            _logServiceMock.Verify(l => l.LogCalculationAsync(It.IsAny<LogEntry>()), Times.Once);
        }

        //[Fact]
        //public async Task Calculate_InvalidOperation_ReturnsBadRequest()
        //{
        //    var request = new ProbabilityRequest
        //    {
        //        Operation = "InvalidOperation",
        //        ProbabilityA = 0.5,
        //        ProbabilityB = 0.5
        //    };

        //    _probabilityServiceMock.Setup(s => s.PerformCalculation(request))
        //        .Throws(new ArgumentException("Invalid operation"));

        //    var result = await _controller.Calculate(request);

        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        //    Assert.Equal("Invalid operation", badRequestResult.Value);
        //}

        [Fact]
        public async Task Calculate_ModelStateInvalid_ReturnsBadRequest()
        {
            _controller.ModelState.AddModelError("ProbabilityA", "Required");

            var result = await _controller.Calculate(new ProbabilityRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }

}