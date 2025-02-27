using _024_LoggingLibrary.Interfaces;

namespace _025_LoggingLibrary.Mocks
{
    internal class MockMessageContentBuilder : IMessageContentBuilder
    {
        public bool CreateBodyWasCalled { get; private set; }

        public void CreateBody(string message)
        {
            CreateBodyWasCalled = true;
        }
    }
}
