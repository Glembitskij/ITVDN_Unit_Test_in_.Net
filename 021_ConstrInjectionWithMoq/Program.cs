using _021_ConstrInjectionWithMoq;

FileManager fileManager = new FileManager();

string fileName = "test.txt";

bool exists = fileManager.FileExists(fileName);

Console.WriteLine(exists);

Console.WriteLine("Hello, World!");