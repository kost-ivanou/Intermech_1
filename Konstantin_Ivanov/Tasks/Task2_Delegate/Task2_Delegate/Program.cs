string input = " Lfsfj_";

List<Func<string, string>> handlers = new List<Func<string, string>> { };

ExecutionStrategy strategy;

bool running = true;

while (running)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Добавить обработчик");
    Console.WriteLine("2. Удалить обработчик");
    Console.WriteLine("3. Показать текущие обработчики");
    Console.WriteLine("4. Выход");
    Console.Write("Введите номер действия: ");

    string handlerChoice = Console.ReadLine();

    switch (handlerChoice)
    {
        case "1":
            AddHandler(handlers);
            break;
        case "2":
            RemoveHandler(handlers);
            break;
        case "3":
            ShowHandlers(handlers);
            break;
        case "4":
            running = false;
            break;
        default:
            Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
            break;
    }
}

[ThreadSafe]
static string strReplace(string input)
{
    return input.Replace('_', ' ');
}

[ThreadSafe]
static string strToUpper(string input)
{
    return input.ToUpper();
}

static void AddHandler(List<Func<string, string>> handlers)
{
    Func<string, string> trim = str => str.Trim();
    Func<string, string> toUpper = strToUpper;
    Func<string, string> replace = strReplace;
    Func<string, string> substring = str => str.Substring(10);

    Console.WriteLine("Выберите обработчик для добавления:");
    Console.WriteLine("1. Trim");
    Console.WriteLine("2. ToUpper");
    Console.WriteLine("3. Replace '_' with ' '");
    Console.WriteLine("4. Substring (начиная с индекса 10)");
    Console.Write("Введите номер обработчика: ");

    string choice = Console.ReadLine();
    Func<string, string> handler = null;

    switch (choice)
    {
        case "1":
            handler = trim;
            break;
        case "2":
            handler = toUpper;
            break;
        case "3":
            handler = replace;
            break;
        case "4":
            handler = substring;
            break;
        default:
            Console.WriteLine("Некорректный выбор.");
            return;
    }

    handlers.Add(handler);
    Console.WriteLine("Обработчик добавлен.");
}

static void RemoveHandler(List<Func<string, string>> handlers)
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

static void ShowHandlers(List<Func<string, string>> handlers)
{
    List<string> handlerNames = new List<string>() { "trim", "toUpper", "replace", "substring" };

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

string Process(string input, ExecutionStrategy strategy)
{
    string result = input;

    switch (strategy)
    {
        case ExecutionStrategy.Sequential:
            foreach (var handler in handlers)
            {
                result = handler(result);
            }
            break;

        case ExecutionStrategy.Parallel:
            foreach (var handler in handlers)
            {
                if (SafetyCheck(handler))
                {
                    result = handler(result);
                }
            }
            break;

        case ExecutionStrategy.WithRollback:
            string original = input;
            foreach (var handler in handlers)
            {
                try
                {
                    result = handler(result);
                }
                catch (Exception e)
                {
                    return original;
                }
            }
            break;

        default:
            throw new NotImplementedException("choose the strategy");
    }

    return result;
}

Console.WriteLine("Выберите стратегию выполнения:");
Console.WriteLine("1. Sequential");
Console.WriteLine("2. Parallel");
Console.WriteLine("3. WithRollback");
Console.Write("Введите номер стратегии: ");

string choice = Console.ReadLine();

switch(choice)
{
    case "1": strategy = ExecutionStrategy.Sequential;
        break;
    case "2": strategy = ExecutionStrategy.Parallel;
        break;
    case "3": strategy = ExecutionStrategy.WithRollback;
        break;
    default:
        throw new NotImplementedException("Некорректный выбор стратегии.");
};

string result = Process(input, strategy);

Console.WriteLine(result);

bool SafetyCheck(Func<string, string> _delegate)
{
    if (_delegate.Method.GetCustomAttributes(typeof(ThreadSafeAttribute), false).Any())
    {
        return true;
    }
    else
    {
        return false;
    }
}

enum ExecutionStrategy
{
    Sequential,
    Parallel,
    WithRollback
}

[AttributeUsage(AttributeTargets.Method)]
class ThreadSafeAttribute : Attribute { }
