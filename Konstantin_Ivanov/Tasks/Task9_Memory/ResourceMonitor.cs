using System.Diagnostics;

namespace Task9_Memory;

public class ResourceMonitor
{
    private readonly long memoryLimit;   
    private readonly double warningLimit; 

    public ResourceMonitor(long _memoryLimit, double _warningLimit)
    {
        memoryLimit = _memoryLimit * 1024 * 1024; 
        warningLimit = _warningLimit;
    }

    public string CheckMemoryUsage()
    {
        Process currentProcess = Process.GetCurrentProcess();
        long usedMemory = currentProcess.PrivateMemorySize64;

        double usagePercent = (double)usedMemory / memoryLimit;

        if (usagePercent >= 1.0)
        {
            return $"Превышен лимит! Использовано {usedMemory / (1024 * 1024)} MB " +
                   $"из {memoryLimit / (1024 * 1024)} MB.";
        }
        else if (usagePercent >= warningLimit)
        {
            return $"Предупреждение: Использовано {usedMemory / (1024 * 1024)} MB " +
                   $"({usagePercent:P0}) из {memoryLimit / (1024 * 1024)} MB.";
        }
        else
        {
            return $"Использование памяти в норме: {usedMemory / (1024 * 1024)} MB.";
        }
    }
}
