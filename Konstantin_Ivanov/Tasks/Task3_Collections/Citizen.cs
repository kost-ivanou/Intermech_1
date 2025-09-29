namespace Task3_Collections;

public abstract class Citizen
{
    public string Name { get; set; }
    public int id { get; set; }

    protected Citizen(string name, int iD)
    {
        Name = name;
        id = iD;
    }

    public override bool Equals(object other)
    {
        if (other is Citizen cit)
        {
            return id == cit.id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}
