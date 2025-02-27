using _024_LoggingLibrary.Interfaces;

namespace _024_LoggingLibrary.Classes
{
    public class SensitiveDataMasker: ISensitiveDataMasker
    {
        public string ClearSensitive(string message)
        {
            Console.WriteLine("SensitiveDataMasker clear sensitive info");
            return message;
        }
    }
}
