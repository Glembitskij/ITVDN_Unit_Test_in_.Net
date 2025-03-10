using _017_InterfaceInjection;

namespace _018_InterfaceInjectionTest
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Arrange
            IFileLister fileLister = new StubFileLister();
            FileManager fileManager = new FileManager();
            string fileName = "main.log";

            // Act
            bool exists = fileManager.FileExists(fileName, fileLister);

            // Assert
            Assert.IsTrue(exists, "File {0} was not found.", fileName);
        }
    }
}