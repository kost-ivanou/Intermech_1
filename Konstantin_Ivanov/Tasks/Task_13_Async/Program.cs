using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        Action<string> work = msg => Console.WriteLine(msg);

        string success = "Успешно";

        IAsyncResult result = work.BeginInvoke(input, ar => {
            Console.WriteLine($"Callback получил сообщение {ar.AsyncState}");
        }, success);

        work.EndInvoke(result);
    }
}
