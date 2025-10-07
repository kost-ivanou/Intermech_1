namespace Task10_Polymorphism;

public abstract class Citizen
{
    public void EnterTheUniversity()
    {
        OpenTheDoor();
        ShowDocuments();
        DoingBusiness();
    }

    protected void OpenTheDoor()
    {
        Console.WriteLine("Открыл дверь");
    }

    protected abstract void ShowDocuments();

    protected virtual void DoingBusiness() {
        Console.WriteLine("Пошел в столовку");
    }
}
