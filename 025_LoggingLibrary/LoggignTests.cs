using _025_LoggingLibrary.Mocks;
using _024_LoggingLibrary;

namespace _025_LoggingLibrary
{
    [TestClass]
    public class LoggignTests
    {
        private Logger _logger;

        private MockLoggerSettings _loggerSettings;
        private MockMessageContentBuilder _contentBuilder;
        private MockMessageHeaderCreator _headerCreator;
        private MockSensitiveDataMasker _dataMasker;

        [TestInitialize]
        public void Initialize()
        {
            _loggerSettings = new MockLoggerSettings();
            _contentBuilder = new MockMessageContentBuilder();
            _headerCreator = new MockMessageHeaderCreator();
            _dataMasker = new MockSensitiveDataMasker();

            _logger = new Logger(_loggerSettings, _contentBuilder, _headerCreator, _dataMasker);
        }

        [TestMethod]
        public void Logger_WriteLogEntry_SensitiveDataMaskerShouldBeScrubed()
        {
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            Assert.IsTrue(_dataMasker.ClearSensitiveWasCalled);
        }

        [TestMethod]
        public void Logger_WriteLogEntry_HeaderCreator()
        {
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            Assert.IsTrue(_headerCreator.CreateHeaderWasCalled);
        }

        [TestMethod]
        public void Logger_CreateEntry_ÑontentBuilderCreated()
        {
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            Assert.IsTrue(_contentBuilder.CreateBodyWasCalled);
        }
    }
}