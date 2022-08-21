
using LoggerService.Abstractions;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LoggerService
{    
    public class CustomLoggerManager : ICustomLoggerManager
    {
        private static ILogger _logger = default!;

        public CustomLoggerManager(IConfiguration configuration)
        {
             _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Console()
            .WriteTo.File("serilog.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(Exception exception, string message)
        {
            _logger.Error(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogWarn(string message)
        {
            _logger.Warning(message);
        }
    }
}
