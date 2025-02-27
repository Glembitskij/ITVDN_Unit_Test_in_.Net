namespace _021_ConstrInjectionWithMoq
{
    public interface IFileLister
    {
        IEnumerable<string> GetFilesInCurrentDirectory();
    }
}
