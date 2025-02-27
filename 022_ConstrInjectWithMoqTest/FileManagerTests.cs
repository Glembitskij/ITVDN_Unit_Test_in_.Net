using Moq;
using _021_ConstrInjectionWithMoq;

// Один із найпопулярніших у .NET — Moq. Він дозволяє легко створювати
// stub-об’єкти без необхідності написання окремих класів (StubFileLister або FakeFileLister).

namespace _022_ConstrInjectWithMoqTest
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Arrange 
            var testFiles = new List<string> { "file1.txt", "file2.log", "file3.exe", "main.log" };

            var mockFileLister = new Mock<IFileLister>();
            
            mockFileLister
                .Setup(lister => lister.GetFilesInCurrentDirectory())
                .Returns(testFiles);

            FileManager fileManager = new FileManager(mockFileLister.Object);
            string targetFile = "main.log";

            // Act
            bool exists = fileManager.FileExists(targetFile);

            // Assert
            Assert.IsTrue(exists, $"Файл {targetFile} не знайдено серед: {string.Join(", ", testFiles)}");
        }
    }
}