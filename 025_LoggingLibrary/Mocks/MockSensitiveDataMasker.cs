using _024_LoggingLibrary.Interfaces;

namespace _025_LoggingLibrary.Mocks
{
    internal class MockSensitiveDataMasker : ISensitiveDataMasker
    {
        public bool ClearSensitiveWasCalled { get; private set; }
        
        public string ClearSensitive(string message)
        {
            ClearSensitiveWasCalled = true;
            return message;
        }
    }
}
