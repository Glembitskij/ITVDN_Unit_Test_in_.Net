using _024_LoggingLibrary;
using _024_LoggingLibrary.Interfaces;

namespace _025_LoggingLibrary.Mocks
{
    internal class MockLoggerSettings : ILoggerSettings
    {
        public bool LogStackFor(LogLevel level)
        {
            return false;
        }
    }
}
