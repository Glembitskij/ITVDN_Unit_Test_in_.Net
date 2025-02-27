using _024_LoggingLibrary;
using _024_LoggingLibrary.Interfaces;
using Moq;

namespace _026_LoggingLibraryMockTest
{
    // Moq � �� ��������� ��� ��������� � .NET.
    // ��������������� ��� ���-���������� � ����� �������� �����, �� ���������, �� ���� �����������.
    // �������� ���������, �� �������� ������ ���� �������� �� �����������,
    // � ����� ������ �������� ������ ��� ����������� ���� ��� �����䳿 � ��������� �����������.

    [TestClass]
    public class LoggignTests
    {
        private Logger _logger;

        private Mock<ILoggerSettings> _loggerSettings;
        private Mock<IMessageContentBuilder> _contentBuilder;
        private Mock<IMessageHeaderCreator> _headerCreator;
        private Mock<ISensitiveDataMasker> _dataMasker;

        [TestInitialize]
        public void Initialize()
        {
            // ��������� mock �����
            _loggerSettings = new Mock<ILoggerSettings>();
            _contentBuilder = new Mock<IMessageContentBuilder>();
            _headerCreator = new Mock<IMessageHeaderCreator>();
            _dataMasker = new Mock<ISensitiveDataMasker>();

            // _mockLoggingConfig.Object - ���� �������� � ����������� ���������
            _logger = new Logger(_loggerSettings.Object, _contentBuilder.Object, _headerCreator.Object, _dataMasker.Object);
        }

        [TestMethod]
        public void Logger_WriteLogEntry_SensitiveDataMaskerScrubed()
        {
            // Arrange
            // � ����� Setup - ������������ ���������, �� ���������� ����������
            // ������ ����������� ����. .Setup(x => x.ClearSensitive(It.IsAny<string>()))
            // - ������� ������ ������ ClearSensitive � ����-���� �������� ��������� �� ����������.
            _dataMasker.Setup(row => row.ClearSensitive(It.IsAny<string>()));

            // Act
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            // Assert
            // VerifyAll - ����������, �� ��������� �������� ���������� ����� �� mock-��'�����.
            _dataMasker.VerifyAll();
        }

        [TestMethod]
        public void Logger_WriteLogEntry_HeaderCreator()
        {
            // Arrange
            _headerCreator.Setup(x => x.CreateHeader(It.IsAny<LogLevel>()));

            // Act
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            // Assert
            _headerCreator.VerifyAll();
        }

        [TestMethod]
        public void Logger_CreateEntry_BodyGeneratedCreated()
        {
            // Arrange
            _contentBuilder.Setup(x => x.CreateBody(It.IsAny<string>()));

            // Act
            _logger.WriteLogEntry("Test log", LogLevel.Error);

            // Assert
            _contentBuilder.VerifyAll();
        }
    }
}