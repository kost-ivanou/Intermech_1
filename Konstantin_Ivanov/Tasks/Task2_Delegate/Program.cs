using Task2_Delegate;

string input = " Lfsfj_";
List<Func<string, string>> handlers = new List<Func<string, string>>();

ExecutionStrategy strategy = MenuService.ChooseExecutionStrategy();
MenuService.MenuLoop(handlers);

string result = Processor.Process(input, strategy, handlers);
Console.WriteLine($"Результат: {result}");