using _007_AssertSamples;

namespace _008_AssertSamplesTest
{
    // xUnit — це сучасний фреймворк для модульного тестування .NET-додатків,
    // який є наступником MSTest та NUnit. Він був розроблений для покращення
    // гнучкості та підтримки сучасних підходів до тестування.
    public class HelperTests
    {
        [Fact]
        public void IsSqrtTest()
        {
            // Arrange
            const double input = 4;
            const double expected = 2;

            // Act
            double actual = Helper.GetSqrt(input);

            // Assert
            // Assert.Equal(expected, actual, precision): цей метод порівнює два числа з плаваючою точкою,
            // використовуючи задану точність, Якщо різниця між значеннями більша за задану точність, тест не пройде.
            Assert.Equal(expected, actual, precision: 10);
        }

        [Fact]
        public void DeltaTest()
        {
            const double expected = 3.1;
            const double delta = 0.07;

            double actual = Helper.GetSqrt(10);

            // Перевірка значень на рівність з урахуванням похибки delta
            Assert.InRange(actual, expected - delta, expected + delta);
        }

        [Fact]
        public void StringAreEqualTest()
        {
            // arrange
            const string input = "HELLO";
            const string expected = "hello";

            // act and assert
            Assert.Equal(expected, input, ignoreCase: true);
        }

        [Fact]
        public void StringSameTest()
        {
            string a = "Hello";
            string b = "Hello";

            // Перевірка рівності посилань (для рядків це працює через інтернування рядків у C#)
            Assert.Same(a, b);
        }

        [Fact]
        public void IntegersSameTest()
        {
            int i = 10;
            int j = 10;

            // У xUnit Assert.Same() не працює з Value Type (int, double тощо),
            // тому тут треба використовувати Assert.Equal()
            Assert.Equal(i, j);
        }
    }
}
