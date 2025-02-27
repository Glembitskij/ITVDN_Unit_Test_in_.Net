using _013_ConstructorInjection;

FileManager fileManager = new FileManager();

string fileName = "test.txt";

bool exists = fileManager.FileExists(fileName);

Console.WriteLine(exists);

Console.WriteLine("Hello, World!");