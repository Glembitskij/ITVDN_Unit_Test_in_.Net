namespace _008_AssertSamplesTest
{
    // xUnit — це сучасний фреймворк для модульного тестування .NET-додатків,
    // який є наступником MSTest та NUnit. Він був розроблений для покращення
    // гнучкості та підтримки сучасних підходів до тестування.
    public class StringAssertMethods
    {
        [Fact]
        public void StringContainsTest()
        {
            // Перевірка на входження підрядка у строку
            Assert.Contains("sam", "Assert samples");
        }

        [Fact]
        public void StringMatchesTest()
        {
            // Перевірка з використанням регулярного виразу
            Assert.Matches(@"\d{3}", "123");
        }

        [Fact]
        public void StringStartsWithTest()
        {
            // Перевірка того, що рядок починається з певного слова
            Assert.StartsWith("Hello", "Hello world");
        }

        [Fact]
        public void StringEndsWithTest()
        {
            // Перевірка того, що рядок закінчується певним словом
            Assert.EndsWith("world", "Hello world");
        }
    }
}
