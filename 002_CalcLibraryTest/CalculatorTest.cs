using _001_CalcLibrary;

namespace _002_CalcLibraryTest
{
    // xUnit — це сучасний фреймворк для модульного тестування .NET-додатків,
    // який є наступником MSTest та NUnit. Він був розроблений для покращення
    // гнучкості та підтримки сучасних підходів до тестування.
    public class CalculatorTest
    {
        [Fact]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            // Arrange
            double x = 10;
            double y = 20;
            double expected = 30;

            // Act
            double actual = Calculator.Addition(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtraction_TwoNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            double x = 20;
            double y = 10;
            double expected = 10;

            // Act
            double actual = Calculator.Subtraction(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}