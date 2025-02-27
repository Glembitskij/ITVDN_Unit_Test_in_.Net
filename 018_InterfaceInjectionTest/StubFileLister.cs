using _017_InterfaceInjection;

namespace _018_InterfaceInjectionTest
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
