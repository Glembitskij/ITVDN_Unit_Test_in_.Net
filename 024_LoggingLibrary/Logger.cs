using _024_LoggingLibrary.Interfaces;

namespace _024_LoggingLibrary
{
    public class Logger
    {
        private ILoggerSettings _loggerSettings;
        private IMessageContentBuilder _contentBuilder;
        private IMessageHeaderCreator _headerCreator;
        private ISensitiveDataMasker _dataMasker;

        public Logger(ILoggerSettings loggerSettings, IMessageContentBuilder contentBuilder,
            IMessageHeaderCreator headerCreator, ISensitiveDataMasker dataMasker)
        {
            _loggerSettings = loggerSettings;
            _contentBuilder = contentBuilder;
            _headerCreator = headerCreator;
            _dataMasker = dataMasker;
        }

        public void WriteLogEntry(string message, LogLevel level)
        {
            _headerCreator.CreateHeader(level);

            if (_loggerSettings.LogStackFor(level))
            {
                Console.WriteLine("Stack trace: ");
            }

            string clearMessage = _dataMasker.ClearSensitive(message);
            _contentBuilder.CreateBody(clearMessage);
        }
    }
}
