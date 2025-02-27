using NSubstitute;
using _021_ConstrInjectionWithMoq;

namespace _023_ConstrInjectWithNsuTest
{
    /// <summary>
    /// NSubstitute � �� �������� ��� ��������� ���� (��������� ��'����) � .NET. 
    /// ���� ��������������� ��� ���������� ����������, ���� ������� ��������� ���������.
    /// �� ����� �� Moq, NSubstitute �� ���� ��������� �� ������� ���������, 
    /// �� ������ ����� ���� ������������.
    /// </summary>
    
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManager_FindFileLogByName()
        {
            // Arrange
            var testFiles = new List<string> { "file1.txt", "file2.log", "file3.exe", "main.log" };

            // ��������� mock-��'��� �� �������, �� ������� ��������� �����
            IFileLister fileLister = Substitute.For<IFileLister>(); 
            fileLister.GetFilesInCurrentDirectory().Returns(testFiles);
            
            FileManager fileManager = new FileManager(fileLister);
            
            string targetFile = "main.log";

            // Act
            bool exists = fileManager.FileExists(targetFile);

            // Assert
            Assert.IsTrue(exists, $"���� {targetFile} �� �������� �����: {string.Join(", ", testFiles)}");
        }
    }
}