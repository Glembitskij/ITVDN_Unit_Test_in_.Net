﻿namespace _013_ConstructorInjection
{
    internal class FileLister: IFileLister
    {
        public IEnumerable<string> GetFilesInCurrentDirectory()
        {
            string path = Directory.GetCurrentDirectory();

            List<string> list = new List<string>();

            IEnumerable<string> files = Directory.EnumerateFiles(path);

            return files;
        }
    }
}
