namespace Task2_Delegate;

public static class Processor
{
    public static string Process(string input, ExecutionStrategy strategy, List<Func<string, string>> handlers)
    {
        string result = input;

        switch (strategy)
        {
            case ExecutionStrategy.Sequential:
                foreach (var handler in handlers)
                    result = handler(result);
                break;

            case ExecutionStrategy.Parallel:
                foreach (var handler in handlers)
                {
                    if (SafetyCheck(handler))
                        result = handler(result);
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
                    catch
                    {
                        return original;
                    }
                }
                break;

            default:
                throw new NotImplementedException("Неизвестная стратегия.");
        }

        return result;
    }

    static bool SafetyCheck(Func<string, string> _delegate)
    {
        return _delegate.Method.GetCustomAttributes(typeof(ThreadSafeAttribute), false).Any();
    }
}
