namespace Task3_Collections;

public abstract class Citizen
{
    public string Name { get; set; }
    public int ID { get; set; }

    protected Citizen(string name, int iD)
    {
        Name = name;
        ID = iD;
    }

    public override bool Equals(object other)
    {
        if (other is Citizen cit)
        {
            return ID == cit.ID;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}
