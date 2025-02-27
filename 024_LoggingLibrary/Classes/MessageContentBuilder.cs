using _024_LoggingLibrary.Interfaces;

namespace _024_LoggingLibrary.Classes
{
    public class MessageContentBuilder: IMessageContentBuilder
    {
        /// <summary>
        /// Створення тіла повідомлення
        /// </summary>
        public void CreateBody(string message)
        {
            Console.WriteLine("MessageContentBuilder - сreate message");
        }
    }
}
