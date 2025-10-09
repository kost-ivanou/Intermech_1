namespace Task17_Generics;


public class Phone
{
    public string Model { get; set; }
    public double Price { get; set; }

    public override string ToString() => $"Телефон: {Model}, {Price}$";
}
