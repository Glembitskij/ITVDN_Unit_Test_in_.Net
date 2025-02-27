namespace _017_InterfaceInjection
{
    public interface IFileLister
    {
        IEnumerable<string> GetFilesInCurrentDirectory();
    }
}
