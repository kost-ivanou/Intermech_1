using System.Text;

namespace Task_5_IO;

public class FileViewer
{
    public static string ReadFileContent(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
        {
            return reader.ReadToEnd();
        }
    }
}
