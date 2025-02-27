using _019_LocalFactoryMethod;

FileManager fileManager = new FileManager();

string fileName = "test.txt";

bool exists = fileManager.FileExists(fileName);

Console.WriteLine(exists);
