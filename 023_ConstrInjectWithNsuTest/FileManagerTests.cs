using NSubstitute;
using _021_ConstrInjectionWithMoq;

namespace _023_ConstrInjectWithNsuTest
{
    /// <summary>
    /// NSubstitute — це бібліотека для створення моків (підставних об'єктів) у .NET. 
    /// Вона використовується для модульного тестування, коли потрібно ізолювати залежності.
    /// На відміну від Moq, NSubstitute має більш лаконічний та зручний синтаксис, 
    /// що робить тести більш читабельними.
    /// </summary>
    
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Arrange
            var testFiles = new List<string> { "file1.txt", "file2.log", "file3.exe", "main.log" };

            // Створюємо mock-об'єкт та вказуємо, що повинен повертати метод
            IFileLister fileLister = Substitute.For<IFileLister>(); 
            fileLister.GetFilesInCurrentDirectory().Returns(testFiles);
            
            FileManager fileManager = new FileManager(fileLister);
            
            string targetFile = "main.log";

            // Act
            bool exists = fileManager.FileExists(targetFile);

            // Assert
            Assert.IsTrue(exists, $"Файл {targetFile} не знайдено серед: {string.Join(", ", testFiles)}");
        }
    }
}