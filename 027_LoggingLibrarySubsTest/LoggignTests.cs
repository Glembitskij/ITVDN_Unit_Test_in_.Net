using _024_LoggingLibrary;
using _024_LoggingLibrary.Interfaces;
using NSubstitute;

namespace _027_LoggingLibrarySubsTest
{
    [TestClass]
    public class LoggignTests
    {
        private Logger _logger;

        private ILoggerSettings _loggerSettings;
        private IMessageContentBuilder _contentBuilder;
        private IMessageHeaderCreator _headerCreator;
        private ISensitiveDataMasker _dataMasker;

        [TestInitialize]
        public void Initialize()
        {
            // Створення заглушок (substitutes)
            _loggerSettings = Substitute.For<ILoggerSettings>();
            _contentBuilder = Substitute.For<IMessageContentBuilder>();
            _headerCreator = Substitute.For<IMessageHeaderCreator>();
            _dataMasker = Substitute.For<ISensitiveDataMasker>();

            // Передача заглушок у конструктор
            _logger = new Logger(_loggerSettings, _contentBuilder, _headerCreator, _dataMasker);
        }

        [TestMethod]
        public void Logger_WriteLogEntry_SensitiveDataMaskerScrubed()
        {
            // Act
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            // Assert
            _dataMasker.Received(1).ClearSensitive(Arg.Any<string>());
        }

        [TestMethod]
        public void Logger_WriteLogEntry_HeaderCreator()
        {
            // Act
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            // Assert
            _headerCreator.Received(1).CreateHeader(Arg.Any<LogLevel>());
        }

        [TestMethod]
        public void Logger_CreateEntry_BodyGeneratedCreated()
        {
            // Act
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            // Assert
            _contentBuilder.Received(1).CreateBody(Arg.Any<string>());
        }
    }
}