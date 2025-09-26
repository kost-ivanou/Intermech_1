namespace Task2_Delegate;

public static class StringHandlers
{
    [ThreadSafe]
    public static string StrReplace(string input) => input.Replace('_', ' ');

    [ThreadSafe]
    public static string StrToUpper(string input) => input.ToUpper();

    public static string Trim(string input) => input.Trim();

    public static string SubstringFrom10(string input) => input.Substring(10);
}
