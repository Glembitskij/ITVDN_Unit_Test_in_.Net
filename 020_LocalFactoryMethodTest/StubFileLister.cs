using _019_LocalFactoryMethod;

namespace _020_LocalFactoryMethodTest
{
    public class StubFileLister : IFileLister
    {
        public IEnumerable<string> GetFilesInCurrentDirectory()
        {
            List<string> list = new List<string>();
            list.Add("file1.txt");
            list.Add("file2.log");
            list.Add("file3.exe");
            list.Add("main.log");

            return list;
        }
    }
}
