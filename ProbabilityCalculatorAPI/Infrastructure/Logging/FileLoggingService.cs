using Microsoft.Extensions.Configuration;

namespace ProbabilityCalculatorAPI.Services
{
    public class FileLoggingService : ILoggingService
    {
        private readonly string _logDirectory;
        private readonly string _logFilePath;


        public FileLoggingService(IConfiguration configuration)
        {
            _logDirectory      = configuration["FileLoggingOptions:LogDirectory"];
            string logFileName = configuration["FileLoggingOptions:LogFileName"];


            _logFilePath = Path.Combine(_logDirectory, logFileName);

            Directory.CreateDirectory(_logDirectory); 
        }

        public async Task LogAsync(string message)
        {
            await File.AppendAllTextAsync(_logFilePath, message + Environment.NewLine);
        }
    }
}
