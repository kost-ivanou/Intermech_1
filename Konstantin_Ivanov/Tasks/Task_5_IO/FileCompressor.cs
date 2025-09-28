using System.IO.Compression;

namespace Task_5_IO;

public class FileCompressor
{
    public static void CompressFile(string filePath)
    {
        string compressedFile = filePath + ".gz";
        try
        {
            using (FileStream sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (FileStream targetStream = new FileStream(compressedFile, FileMode.Create, FileAccess.Write))
            using (GZipStream gzip = new GZipStream(targetStream, CompressionMode.Compress))
            {
                sourceStream.CopyTo(gzip);
            }

            Console.WriteLine($"Файл успешно сжат в: {compressedFile}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при сжатии: {e.Message}");
        }
    }
}
