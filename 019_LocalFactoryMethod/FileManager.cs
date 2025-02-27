namespace _019_LocalFactoryMethod
{
    public class FileManager
    {
        public FileManager()
        {
        }

        // Використання фабричного методу для тестування.
        // У юніт-тесті цей метод можна перевизначити, щоб він повертав заглушку.
        protected virtual IFileLister CreateDataAccessObject()
        {
            return new FileLister();
        }

        public bool FileExists(string fileName)
        {
            IFileLister fileLister = CreateDataAccessObject();
            
            IEnumerable<string> files = fileLister.GetFilesInCurrentDirectory();

            return files.Any(file => file.Contains(fileName));
        }
    }
}
