namespace Task17_Generics;

public class Storage<T>
{
    private List<T> _storage = new List<T>();

    public void AddItem(T item)
    {
        _storage.Add(item);
        Console.WriteLine($"Добавлен товар: {item}");
    }

    public void RemoveItem(T item)
    {
        _storage.Remove(item);
        Console.WriteLine($"Удалён товар: {item}");
    }

    public List<T> GetAll() => new List<T>(_storage);
}
