using _024_LoggingLibrary.Interfaces;

namespace _024_LoggingLibrary.Classes
{
    public class LoggerSettings: ILoggerSettings
    {
        /// <summary>
        /// Визначення необхідності логування стеку викликів
        /// </summary>
        public bool LogStackFor(LogLevel level)
        {
            if (level == LogLevel.Error)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
