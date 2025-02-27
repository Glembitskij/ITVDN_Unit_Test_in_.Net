namespace _011_Problem
{
    public class FileLister
    {
        public IEnumerable<string> GetFilesInCurrentDirectory()
        {
            string path = Directory.GetCurrentDirectory();

            List<string> list = new List<string>();

            IEnumerable<string> files = Directory.EnumerateFiles(path);

            return files;
        }
    }
}
