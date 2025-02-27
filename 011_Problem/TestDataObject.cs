namespace _011_Problem
{
    public class TestDataObject
    {
        public List<string> GetFilesInCurrentDirectory()
        {
            List<string> list = new List<string>();
            list.Add("main.log");
            list.Add("file1.txt");
            list.Add("file2.log");
            list.Add("file3.exe");

            return list;
        }
    }
}
