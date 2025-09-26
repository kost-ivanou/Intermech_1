namespace Task2_Delegate;

public static class HandlerService
{
    public static void AddHandler(List<Func<string, string>> handlers)
    {
        Console.WriteLine("Выберите обработчик для добавления:");
        Console.WriteLine("1. Trim");
        Console.WriteLine("2. ToUpper");
        Console.WriteLine("3. Replace '_' with ' '");
        Console.WriteLine("4. Substring (начиная с индекса 10)");
        Console.Write("Введите номер обработчика: ");

        string choice = Console.ReadLine();
        Func<string, string> handler = choice switch
        {
            "1" => StringHandlers.Trim,
            "2" => StringHandlers.StrToUpper,
            "3" => StringHandlers.StrReplace,
            "4" => StringHandlers.SubstringFrom10,
            _ => null
        };

        if (handler == null)
        {
            Console.WriteLine("Некорректный выбор.");
            return;
        }

        handlers.Add(handler);
        Console.WriteLine("Обработчик добавлен.");
    }

    public static void RemoveHandler(List<Func<string, string>> handlers)
    {
        ShowHandlers(handlers);
        Console.Write("Введите номер обработчика для удаления: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= handlers.Count)
        {
            handlers.RemoveAt(index - 1);
            Console.WriteLine("Обработчик удален.");
        }
        else
        {
            Console.WriteLine("Некорректный номер.");
        }
    }

    public static void ShowHandlers(List<Func<string, string>> handlers)
    {
        if (handlers.Count == 0)
        {
            Console.WriteLine("Список обработчиков пуст.");
            return;
        }

        Console.WriteLine("Текущие обработчики:");
        for (int i = 0; i < handlers.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {handlers[i].Method.Name}");
        }
    }
}
