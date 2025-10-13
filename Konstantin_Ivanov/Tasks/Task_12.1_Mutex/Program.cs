bool createdNew;

using (Mutex mutex = new Mutex(true, "Global\\singleapp", out createdNew))
{
    if (!createdNew)
    {
        Console.WriteLine("Приложение уже запущено");
        return;
    }

    Console.WriteLine("Нажмите enter для выхода.");
    Console.ReadLine();
}