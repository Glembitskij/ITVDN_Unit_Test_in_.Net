namespace _013_ConstructorInjection
{
    public interface IFileLister
    {
        IEnumerable<string> GetFilesInCurrentDirectory();
    }
}
