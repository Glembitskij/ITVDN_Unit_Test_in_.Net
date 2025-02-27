using _013_ConstructorInjection;

namespace _014_ConstructorInjectionTest
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Arrange
            IFileLister fileLister = new StubFileLister();
            FileManager fileManager = new FileManager(fileLister);
            string fileName = "main.log";

            // Act
            bool exists = fileManager.FileExists(fileName);

            // Assert
            Assert.IsTrue(exists, "File {0} was not found.", fileName);
        }
    }
}