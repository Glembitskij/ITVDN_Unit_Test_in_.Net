using _015_PropertyInjection;

FileManager fileManager = new FileManager();

fileManager.FileLister = new FileLister();  

string fileName = "test.txt";

bool exists = fileManager.FileExists(fileName);

Console.WriteLine(exists);

Console.WriteLine("Hello, World!");

