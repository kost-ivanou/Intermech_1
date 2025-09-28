namespace Task_5_IO;

public class FileSearcher
{
    public static string FindFile(string rootDir, string fileName)
    {
        try
        {
            foreach (var file in Directory.GetFiles(rootDir))
            {
                if (Path.GetFileName(file).Equals(fileName, StringComparison.Ordinal))
                {
                    return file;
                }
            }

            foreach (var dir in Directory.GetDirectories(rootDir))
            {
                string result = FindFile(dir, fileName);
                if (result != null)
                {
                    return result;
                }
            }
        }
        catch(Exception e) 
        {
            Console.WriteLine(e.Message);
        }

        return null;
    }
}
