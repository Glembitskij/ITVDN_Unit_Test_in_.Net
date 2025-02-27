using _019_LocalFactoryMethod;

namespace _020_LocalFactoryMethodTest
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Arrange
            IFileLister fileLister = new StubFileLister();
            FileManagerUnderTest fileManager = new FileManagerUnderTest();
            string fileName = "main.log";

            // Act
            bool exists = fileManager.FileExists(fileName);

            // Assert
            Assert.IsTrue(exists, "File {0} was not found.", fileName);
        }
    }

    class FileManagerUnderTest: FileManager
    {
        protected override IFileLister CreateDataAccessObject()
        {
            return new StubFileLister();
        }
    }
}