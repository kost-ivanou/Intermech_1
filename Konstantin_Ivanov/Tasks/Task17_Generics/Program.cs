using Task17_Generics;

var bookStorage = new Storage<Book>();
bookStorage.AddItem(new Book { Title = "1984", Author = "Дж. Оруэлл" });
bookStorage.AddItem(new Book { Title = "Мастер и Маргарита", Author = "М. Булгаков" });

var phoneStorage = new Storage<Phone>();
phoneStorage.AddItem(new Phone { Model = "iPhone 15", Price = 1200 });
phoneStorage.AddItem(new Phone { Model = "Samsung Galaxy S24", Price = 950 });

var fruitStorage = new Storage<Fruit>();
fruitStorage.AddItem(new Fruit { Name = "Яблоко", Weight = 0.2 });
fruitStorage.AddItem(new Fruit { Name = "Банан", Weight = 0.25 });

Console.WriteLine("\n Поиск книги по названию:");
var foundBook = StorageSearch.FindItem(bookStorage.GetAll(), b => b.Title.Contains("1984"));
Console.WriteLine(foundBook != null ? $"Найдена: {foundBook}" : "Книга не найдена");

Console.WriteLine("\n Поиск телефона с ценой > 1000$:");
var foundPhone = StorageSearch.FindItem(phoneStorage.GetAll(), p => p.Price > 1000);
Console.WriteLine(foundPhone != null ? $"Найден: {foundPhone}" : "Телефон не найден");

Console.WriteLine("\n Поиск фрукта весом больше 0.22 кг:");
var foundFruit = StorageSearch.FindItem(fruitStorage.GetAll(), f => f.Weight > 0.22);
Console.WriteLine(foundFruit != null ? $"Найден: {foundFruit}" : "Фрукт не найден");

Console.WriteLine("\n Все книги на складе:");
foreach (var book in bookStorage.GetAll())
{
    Console.WriteLine(book);
}

Console.WriteLine("\n Все телефоны на складе:");
foreach (var phone in phoneStorage.GetAll())
{
    Console.WriteLine(phone);
}

Console.WriteLine("\n Все фрукты на складе:");
foreach (var fruit in fruitStorage.GetAll())
{
    Console.WriteLine(fruit);
}
