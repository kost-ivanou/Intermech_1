using Task_5_IO;

Console.Write("Введите директорию для поиска: ");
string searchDir = Console.ReadLine();

Console.Write("Введите имя файла: ");
string fileName = Console.ReadLine();

try
{
    string foundPath = FileSearcher.FindFile(searchDir, fileName);
    if (foundPath != null)
    {
        Console.WriteLine($"\nФайл найден: {foundPath}");

        Console.WriteLine("\nСодержимое файла:");
        Console.WriteLine("-----------------");
        Console.WriteLine(FileViewer.ReadFileContent(foundPath));
        Console.WriteLine("-----------------");

        Console.Write("\nХотите сжать файл? (y/n): ");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            Console.WriteLine();
            FileCompressor.CompressFile(foundPath);
        }
    }
    else
    {
        Console.WriteLine("Файл не найден.");
    }
}
catch (Exception e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}