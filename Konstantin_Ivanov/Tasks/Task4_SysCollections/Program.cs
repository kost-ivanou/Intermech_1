using System.Collections;
using System.Collections.Immutable;
using System.Globalization;

Dictionary<string, int> dictAccounts = new Dictionary<string, int>();//ключ-значение

SortedDictionary<string, int> sortDictAccounts = new SortedDictionary<string, int>();//ключ-значение, но сортировано по ключу + нет доступа по индексу, но изменение за log n

SortedList<string, int> sortListAccounts = new SortedList<string, int>();//ключ-значение, сортировка по ключу, есть доступ по индексу, круто для читки, плохо для изменения за n

OrderedDictionary<string, int> orderedDictAccounts = new OrderedDictionary<string, int>
{
    { "def", 30000 },
    { "abc", 15000 },
    { "ghj", 20000 }
};// ключ-значение, нет сортировки, есть доступ по индексу

Console.WriteLine("Исходная коллекция:");
foreach (var acc in orderedDictAccounts)
{
    Console.WriteLine($"{acc.Key}, {acc.Value}");
}

var sortedOrderedDict = SortByKey(orderedDictAccounts);

Console.WriteLine("\nСортировка по ключу:");
foreach (var acc in sortedOrderedDict)
{
    Console.WriteLine($"{acc.Key}, {acc.Value}");
}

OrderedDictionary<string, int> SortByKey(OrderedDictionary<string, int> dict)
{
    var sortedPairs = new List<KeyValuePair<string, int>>(dict);
    sortedPairs.Sort((x, y) => string.Compare(x.Key, y.Key, StringComparison.OrdinalIgnoreCase));

    var sorted = new OrderedDictionary<string, int>();
    foreach (var kv in sortedPairs)
        sorted.Add(kv.Key, kv.Value);

    return sorted;
}

