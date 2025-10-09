namespace Task17_Generics;

public class Fruit
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public override string ToString() => $"Фрукт: {Name}, {Weight} кг";
}
