using Microsoft.Extensions.Logging;

namespace Teams.Extensions
{
    public static class ILoggerExtension
    {
        public static void LogInformation(this ILogger logger)
        {
            logger.LogInformation("");
        }
    }
}
