namespace Task3_Collections;

public class CitizenCollection
{
    private readonly List<Citizen> _citizens = new();

    public int Add(Citizen citizen)
    {
        if (_citizens.Contains(citizen))
        {
            Console.WriteLine($"{citizen.Name} уже есть в списке");
            return _citizens.IndexOf(citizen) + 1;
        }

        if (citizen is Pensioner)
        {
            int index = _citizens.FindLastIndex(c => c is Pensioner);

            if (index == -1)
            {
                _citizens.Insert(0, citizen);
                return 1;
            }
            else
            {
                _citizens.Insert(index, citizen);
                return index + 1;
            }
        }
        else
        {
            _citizens.Add(citizen);
            return _citizens.Count;
        }
    }

    public bool Remove(Citizen citizen)
    {
        return _citizens.Remove(citizen);
    }

    public Citizen RemoveFirst()
    {
        if (_citizens.Count == 0)
        {
            return null;
        }
        var citizen = _citizens[0];
        _citizens.RemoveAt(0);
        return citizen;
    }

    public Citizen ReturnLast(out int pos)
    {
        if (_citizens.Count == 0)
        {
            pos = -1;
            return null;
        }
        var citizen = _citizens[^1];
        pos = _citizens.Count;
        return citizen;
    }

    public bool Contains(Citizen citizen, out int pos)
    {
        pos = _citizens.IndexOf(citizen);
        return pos != -1;
    }

    public void Clear()
    {
        _citizens.Clear();
    }

    public IEnumerator<Citizen> GetEnumerator()
    {
        return _citizens.GetEnumerator();
    }
}
