using Task9_Memory;

long memoryLimitMB = 0;
double warningLimit = 0;

try
{
    Console.Write("Введите лимит памяти в MB: ");
    long.TryParse(Console.ReadLine(), out memoryLimitMB);

    Console.Write("Введите порог предупреждения (например, 0.8 = 80%): ");
    double.TryParse(Console.ReadLine(), out warningLimit);
}
catch(Exception e)
{
    Console.WriteLine("Введите корректные значения");
}

var monitor = new ResourceMonitor(memoryLimitMB, warningLimit);

Console.WriteLine(monitor.CheckMemoryUsage());

byte[] data = new byte[50 * 1024 * 1024];
Console.WriteLine(monitor.CheckMemoryUsage());
