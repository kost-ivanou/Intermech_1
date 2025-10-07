using Task9_Memory;

long memoryLimitMB = 0;
double warningLimit = 0;

Console.Write("Введите лимит памяти в MB: ");
if (!long.TryParse(Console.ReadLine(), out memoryLimitMB) || memoryLimitMB <= 0)
{
    Console.WriteLine("Ошибка: введите положительное число для лимита памяти.");
    return;
}

Console.Write("Введите порог предупреждения (например, 0.8 = 80%): ");
if (!double.TryParse(Console.ReadLine(), out warningLimit) || warningLimit <= 0 || warningLimit >= 1)
{
    Console.WriteLine("Ошибка: введите число между 0 и 1 для порога предупреждения.");
    return;
}

var monitor = new ResourceMonitor(memoryLimitMB, warningLimit);

Console.WriteLine(monitor.CheckMemoryUsage());

byte[] data = new byte[50 * 1024 * 1024];
Console.WriteLine(monitor.CheckMemoryUsage());
