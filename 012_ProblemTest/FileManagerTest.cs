using _011_Problem;

namespace _012_ProblemTest
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Assert
            FileManager fileManager = new FileManager();
            string fileName = "main.log";

            // Act
            bool exists = fileManager.FileExists(fileName);

            // Assert
            Assert.IsTrue(exists, "File {0} was not found.", fileName);
        }
    }
}