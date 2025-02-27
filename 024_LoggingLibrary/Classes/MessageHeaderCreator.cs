using _024_LoggingLibrary.Interfaces;

namespace _024_LoggingLibrary.Classes
{
    public class MessageHeaderCreator: IMessageHeaderCreator
    {
        /// <summary>
        ///  Cтворення заголовку повідомлення
        /// </summary>
        public void CreateHeader(LogLevel level)
        {
            Console.WriteLine("MessageHeaderCreator create header message");
        }
    }
}
