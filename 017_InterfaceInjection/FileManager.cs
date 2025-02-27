namespace _017_InterfaceInjection
{
    public class FileManager
    {
        // Впровадження залежносты через інтерфейс
        public bool FileExists(string fileName, IFileLister fileLister)
        {
            if (fileLister == null)
            {
                throw new ArgumentNullException("fileLister", "Parameter fileLister cannot be null");
            }

            IEnumerable<string> files = fileLister.GetFilesInCurrentDirectory();

            return files.Any(file => file.Contains(fileName));
        }
    }
}
