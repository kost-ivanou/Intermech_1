using Task3_Collections;

var list = new CitizenCollection();

var s1 = new Student("Иван", 1111);
var w1 = new Worker("Петр", 2222);
var p1 = new Pensioner("Анна", 3333);
var p2 = new Pensioner("Мария", 4444);

Console.WriteLine($"Добавлен {s1.Name}, позиция: {list.Add(s1)}");
Console.WriteLine($"Добавлен {w1.Name}, позиция: {list.Add(w1)}");
Console.WriteLine($"Добавлен {p1.Name}, позиция: {list.Add(p1)}");
Console.WriteLine($"Добавлен {p2.Name}, позиция: {list.Add(p2)}");

Console.WriteLine("\nТекущая очередь:");
foreach (var citizen in list)
    Console.WriteLine(citizen.Name);

Console.WriteLine("\nУдаляем первого:");
var removed = list.RemoveFirst();
Console.WriteLine($"Удален: {removed.Name}");

Console.WriteLine("\nПроверка Contains:");
if (list.Contains(w1, out int pos))
    Console.WriteLine($"{w1.Name} есть в очереди на позиции {pos + 1}");

Console.WriteLine("\nПоследний в очереди:");
var last = list.ReturnLast(out int lastPos);
Console.WriteLine($"{last.Name} на позиции {lastPos}");