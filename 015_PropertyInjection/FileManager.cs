namespace _015_PropertyInjection
{
    public class FileManager
    {
        private IFileLister _fileLister;

        public FileManager() {}

        public IFileLister FileLister 
        {
            get
            {
                if (_fileLister == null)
                {
                    throw new MemberAccessException("FileLister has not been initialized.");
                }

                return _fileLister;
            }
            set { _fileLister = value; } 
        }

        public bool FileExists(string fileName)
        {
            IEnumerable<string> files = _fileLister.GetFilesInCurrentDirectory();

            return files.Any(file => file.Contains(fileName));
        }
    }
}
