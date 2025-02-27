namespace _015_PropertyInjection
{
    public interface IFileLister
    {
        IEnumerable<string> GetFilesInCurrentDirectory();
    }
}
