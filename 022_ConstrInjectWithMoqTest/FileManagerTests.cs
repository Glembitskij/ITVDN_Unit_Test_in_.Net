using Moq;
using _021_ConstrInjectionWithMoq;

// ���� �� �������������� � .NET � Moq. ³� �������� ����� ����������
// stub-�ᒺ��� ��� ����������� ��������� ������� ����� (StubFileLister ��� FakeFileLister).

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
            Assert.IsTrue(exists, $"���� {targetFile} �� �������� �����: {string.Join(", ", testFiles)}");
        }
    }
}