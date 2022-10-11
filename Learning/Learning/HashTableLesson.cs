namespace Learning;

public class HashTableLesson<T>
{
    private Item<T>[] _items;

    public HashTableLesson(int size)
    {
        _items = new Item<T>[size];
        for (var i = 0; i < _items.Length; i++)
        {
            _items[i] = new Item<T>();
        }
    }

    public void Add(T item)
    {
        var key = GetHash(item);
        _items[key].Notes.Add(item);
    }

    public bool Search(T item)
    {
        var key = GetHash(item);
        return _items[key].Notes.Contains(item);
    }

    
    
    public int GetHash(T item)
    {
        return item.GetHashCode() % _items.Length;
    }
}


public class Item<T>
{
    public List<T> Notes { get; set; }
    public Item()
    {
        Notes = new List<T>();
    }
}

public class PersonHash
{
    public string Name { get; set; }
    public int Age { get; set; }

    public PersonHash(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public override string ToString()
    {
        return Name;
    }

    public override int GetHashCode()
    {
        return Name.Length + Age + Name[0];
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is PersonHash)) return false;
        PersonHash person = (PersonHash)obj;
        return Name == person.Name && Age == person.Age;
    }
}