ManualResetEvent manualEvent = new ManualResetEvent(false);
AutoResetEvent autoEvent = new AutoResetEvent(false);

Thread manualThread = new Thread(ManualWorker);
Thread autoThread = new Thread(AutoWorker);

manualThread.Start();
autoThread.Start();


Console.WriteLine("\nглавный поток подает сигнал мануалу(все потоки)");
manualEvent.Set();
Thread.Sleep(2000);

Console.WriteLine("сбросили мануал\n");
manualEvent.Reset();

Thread.Sleep(1000);

Console.WriteLine("главный поток дает сигнал авто(один поток)");
autoEvent.Set();
Console.WriteLine("сразу и закрыли");
Thread.Sleep(2000);

void ManualWorker()
{
    Console.WriteLine("ManualWorker: ожидает сигнал...");
    manualEvent.WaitOne();
    Console.WriteLine("ManualWorker: получил сигнал и выполняет работу!");
}

void AutoWorker()
{
    Console.WriteLine("AutoWorker: ожидает сигнал...");
    autoEvent.WaitOne();
    Console.WriteLine("AutoWorker: получил сигнал и выполняет работу!");
}
