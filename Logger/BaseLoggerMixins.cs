using System;
using System.Globalization;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(string? message, BaseLogger logger, params object[] arguments)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));
            
            if (message != null)
            {
                string messageAndArguments = string.Format(message, arguments);
                logger.Log(LogLevel.Error, messageAndArguments );
            }
        }

        public static void Warning(string? message, BaseLogger logger, params object[] arguments)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            if (message != null)
            {
                string messageAndArguments = string.Format(message, arguments);
                logger.Log(LogLevel.Warning, messageAndArguments);
            }
        }

        public static void Debug(string? message, BaseLogger logger, params object[] arguments)
        {   
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            if (message != null)
            {
                string messageAndArguments = string.Format(message, arguments);
                logger.Log(LogLevel.Debug, messageAndArguments);
            }
        }

        public static void Information(string? message, BaseLogger logger, params object[] arguments)
        {  
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));
            if (message != null)
            {
                string messageAndArguments = string.Format(message, arguments);
                logger.Log(LogLevel.Information, messageAndArguments);
            }
        }
    }
}
