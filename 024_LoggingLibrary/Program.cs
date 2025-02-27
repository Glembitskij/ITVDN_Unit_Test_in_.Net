// See https://aka.ms/new-console-template for more information


using _024_LoggingLibrary;
using _024_LoggingLibrary.Classes;
using _024_LoggingLibrary.Interfaces;

ILoggerSettings loggerSettings = new LoggerSettings();
IMessageContentBuilder contentBuilder = new MessageContentBuilder();
IMessageHeaderCreator messageHeader = new MessageHeaderCreator();
ISensitiveDataMasker dataMasker = new SensitiveDataMasker();

Logger logger = new Logger(loggerSettings, contentBuilder, messageHeader, dataMasker);

logger.WriteLogEntry("Error log", LogLevel.Error);

