namespace Task2_Delegate;

public static class MenuService
{
    public static void MenuLoop(List<Func<string, string>> handlers)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить обработчик");
            Console.WriteLine("2. Удалить обработчик");
            Console.WriteLine("3. Показать текущие обработчики");
            Console.WriteLine("4. Выход");
            Console.Write("Введите номер действия: ");

            string choice = Console.ReadLine();
            running = HandleMenuChoice(choice, handlers);
        }
    }

    public static ExecutionStrategy ChooseExecutionStrategy()
    {
        Console.WriteLine("Выберите стратегию выполнения:");
        Console.WriteLine("1. Sequential");
        Console.WriteLine("2. Parallel");
        Console.WriteLine("3. WithRollback");
        Console.Write("Введите номер стратегии: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1": return ExecutionStrategy.Sequential;
            case "2": return ExecutionStrategy.Parallel;
            case "3": return ExecutionStrategy.WithRollback;
            default: throw new NotImplementedException("Некорректный выбор стратегии.");
        }
    }

    static bool HandleMenuChoice(string choice, List<Func<string, string>> handlers)
    {
        switch (choice)
        {
            case "1":
                HandlerService.AddHandler(handlers);
                break;
            case "2":
                HandlerService.RemoveHandler(handlers);
                break;
            case "3":
                HandlerService.ShowHandlers(handlers);
                break;
            case "4":
                return false;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }
        return true;
    }
}
