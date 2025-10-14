class Program
{
    static async Task Main()
    {
        var parallelTasks = Task.Run(() =>
        {
            Parallel.Invoke(
                MethodA,
                MethodB
            );
        });

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Главный поток, i = {i}");
            Thread.Sleep(700);
        }

        await parallelTasks;
        Console.WriteLine("Главный поток завершил работу");
    }

    static void MethodA()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Метод A, i = {i}");
            Thread.Sleep(700);
        }
        Console.WriteLine("Метод A завершён.");
    }

    static void MethodB()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Метод B, i = {i}");
            Thread.Sleep(600);
        }
        Console.WriteLine("Метод B завершён.");
    }
}
