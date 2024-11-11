using System.Threading.Tasks;
using Moq;
using Xunit;
using ProbabilityCalculatorAPI.Services;
using ProbabilityCalculatorAPI.Model;
using Microsoft.Extensions.Configuration;

namespace ProbabilityCalculatorAPI.Tests
{  
    public class LogServiceTests
    {
        private readonly Mock<LoggingServiceFactory> _loggingServiceFactoryMock;
        private readonly Mock<ILoggingService> _loggingServiceMock;
        private readonly Mock<ILogMessageFormatter> _logMessageFormatterMock;
        private readonly LogService _logService;

        public LogServiceTests()
        {
            _loggingServiceMock      = new Mock<ILoggingService>();
            _logMessageFormatterMock = new Mock<ILogMessageFormatter>();

            var serviceProviderMock = new Mock<IServiceProvider>();
            var configurationMock = new Mock<IConfiguration>();

            _loggingServiceFactoryMock = new Mock<LoggingServiceFactory>(serviceProviderMock.Object, configurationMock.Object);


            _loggingServiceFactoryMock.Setup(factory => factory.CreateLoggingService())
                .Returns(_loggingServiceMock.Object);
             
            _logService = new LogService(_loggingServiceFactoryMock.Object, _logMessageFormatterMock.Object);
        }

        [Fact]
        public async Task LogCalculationAsync_ShouldLogCorrectEntry()
        {
            // Arrange
            var logEntry = new LogEntry
            {
                Operation = OperationType.CombinedWith.ToString(),
                ProbabilityA = 0.5,
                ProbabilityB = 0.5,
                Result = 0.25
            };

            // Set up the formatter mock
            _logMessageFormatterMock.Setup(formatter => formatter.Format(logEntry))
                .Returns("2023-11-01: Operation=CombinedWith, P(A)=0.5, P(B)=0.5, Result=0.25");

            // Act
            await _logService.LogCalculationAsync(logEntry);

            // Assert
            _loggingServiceMock.Verify(log => log.LogAsync(It.Is<string>(msg =>
                msg == "2023-11-01: Operation=CombinedWith, P(A)=0.5, P(B)=0.5, Result=0.25")), Times.Once);
        }
    }




}
