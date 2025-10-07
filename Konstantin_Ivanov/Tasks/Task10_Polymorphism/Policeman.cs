namespace Task10_Polymorphism;

public class Policeman : Citizen
{
    protected override void ShowDocuments()
    {
        Console.WriteLine("Показал ксиву");
    }

    protected override void DoingBusiness()
    {
        Console.WriteLine("Пошел кошмарить курящих студентов");
    }
}
