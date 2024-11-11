
namespace ProbabilityCalculatorAPI.Services
{
    public class LoggingServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public LoggingServiceFactory(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public virtual ILoggingService CreateLoggingService()
        {
            var loggingType = _configuration["LoggingType"];

            return loggingType switch
            {
                "Database" => _serviceProvider.GetRequiredService<DatabaseLoggingService>(),
                "File" => _serviceProvider.GetRequiredService<FileLoggingService>(),
                _ => throw new InvalidOperationException("Invalid logging type configuration")
            };
        }
    }
}
