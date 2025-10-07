namespace Task10_Polymorphism;

public class Professor : Citizen
{
    protected override void ShowDocuments()
    {
        Console.WriteLine("Показал крутую карточку профессора");
    }

    protected override void DoingBusiness()
    {
        Console.WriteLine("Пошел вести лекцию у студентов");
    }
}
