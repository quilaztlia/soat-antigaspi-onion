namespace LoggerService.Abstractions
{
    public interface ICustomLoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(Exception exception, string message);
    }
}