using _015_PropertyInjection;

namespace _016_PropertyInjectionTest
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
