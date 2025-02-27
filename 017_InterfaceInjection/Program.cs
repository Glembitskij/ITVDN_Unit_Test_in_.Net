using _017_InterfaceInjection;

FileManager fileManager = new FileManager();

FileLister fileLister = new FileLister();

string fileName = "test.txt";

bool exists = fileManager.FileExists(fileName, fileLister);

Console.WriteLine(exists);
