namespace _021_ConstrInjectionWithMoq
{
    public class FileManager
    {
        private IFileLister _fileLister;

        public FileManager()
        {
            _fileLister = new FileLister();
        }

        public FileManager(IFileLister fileLister)
        {
            _fileLister = fileLister;
        }

        public bool FileExists(string fileName)
        {
            IEnumerable<string> files = _fileLister.GetFilesInCurrentDirectory();

            return files.Any(file => file.Contains(fileName));
        }
    }
}
