using _007_AssertSamples;

namespace _008_AssertSamplesTest
{
    // xUnit — це сучасний фреймворк для модульного тестування .NET-додатків,
    // який є наступником MSTest та NUnit. Він був розроблений для покращення
    // гнучкості та підтримки сучасних підходів до тестування.
    public class ExpectingExceptions
    {
        [Fact]
        public void MyClass_SayHello_Exception()
        {
            // Arrange
            Helper instance = new Helper();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => instance.SayHello(null));
            Assert.Equal("Value cannot be null. (Parameter 'Parameter name cannot be null!')", exception.Message);
        }

        [Fact]
        public void MyClass_SayHello_ReturnDmitriy()
        {
            // Arrange
            Helper instance = new Helper();
            string expected = "Hello Alex";

            // Act
            string actual = instance.SayHello("Alex");

            // Assert
            Assert.Equal(expected, actual);
        }
    }

}
