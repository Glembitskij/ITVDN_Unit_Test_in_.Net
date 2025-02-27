namespace _011_Problem
{
    public class FileManager
    {
        public bool FileExists(string fileName)
        {
            // Клас FileManager напряму залежить від об'єкта доступу до файлів,
            // що ускладнює його розширення та тестування.
            // При написанні тестів для цього класу ми проводимо інтеграційне тестування,
            // оскільки тестуємо не тільки логіку, але й файлову систему.

            //FileLister fileData = new FileLister();
            // Для цілей тестування слід використовувати цей об'єкт
            TestDataObject fileData = new TestDataObject(); 

            IEnumerable<string> files = fileData.GetFilesInCurrentDirectory();

            return files.Any(file => file.Contains(fileName));
        }
    }
}
