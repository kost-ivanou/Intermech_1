using Task10_Polymorphism;

List<Citizen> citizens = new List<Citizen> {new Policeman(), new Student(), new Professor()};

foreach(var c in citizens)
{
    c.EnterTheUniversity();
}