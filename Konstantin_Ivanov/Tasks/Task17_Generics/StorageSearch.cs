namespace Task17_Generics;

public class StorageSearch
{
    public static T FindItem<T>(IEnumerable<T> items, Predicate<T> condition)
    {
        return items.Where(x => condition(x)).FirstOrDefault();
    }
}
