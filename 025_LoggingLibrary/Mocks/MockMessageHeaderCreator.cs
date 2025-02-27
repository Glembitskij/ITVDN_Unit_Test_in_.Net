using _024_LoggingLibrary;
using _024_LoggingLibrary.Interfaces;

namespace _025_LoggingLibrary.Mocks
{
    internal class MockMessageHeaderCreator : IMessageHeaderCreator
    {
        public bool CreateHeaderWasCalled { get; private set; }
       
        public void CreateHeader(LogLevel level)
        {
            CreateHeaderWasCalled = true;
        }
    }
}
