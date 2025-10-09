object fileLock = new object();

string file1 = "file1.txt";
string file2 = "file2.txt";
string resultFile = "result.txt";

Thread t1 = new Thread(() => ReadAndWrite(file1, resultFile, fileLock));
Thread t2 = new Thread(() => ReadAndWrite(file2, resultFile, fileLock));

t1.Start();
t2.Start();

t1.Join();
t2.Join();

void ReadAndWrite(string sourceFile, string destinationFile, object locker)
{
    try
    {
        string[] lines = File.ReadAllLines(sourceFile);

        foreach (string line in lines)
        {
            lock (locker)
            {
                File.AppendAllText(destinationFile, $"{line}\n");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка при обработке файла {sourceFile}: {e.Message}");
    }
}
