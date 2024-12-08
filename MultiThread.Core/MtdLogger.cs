using Serilog;

namespace MultiThread.Core;

public static class MtdLogger
{
    public static void InitLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
    public static void LogError(string message)
    {
        Log.Logger.Error(message);  
    }
    public static void LogWarning(string message)
    {
        Log.Logger.Warning(message);  
    }

    public static void LogInfo(string message)
    {
        Log.Logger.Information(message); 
    }
}