namespace _019_LocalFactoryMethod
{
    public interface IFileLister
    {
        IEnumerable<string> GetFilesInCurrentDirectory();
    }
}
