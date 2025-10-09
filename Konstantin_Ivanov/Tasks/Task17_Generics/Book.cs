namespace Task17_Generics;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public override string ToString() => $"Книга: {Title}, {Author}";
}
    