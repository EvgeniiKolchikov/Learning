namespace Learning.HomeWorks;

public class HashTableHomeWork<T>
{
    private Item<T>[] _myStorage;
    public HashTableHomeWork(int size)
    {
        _myStorage = new Item<T>[size];
        for (var i = 0; i < _myStorage.Length; i++)
        {
            _myStorage[i] = new Item<T>();
        }
    }

    public Item<T> this[int index] => _myStorage[index];

    public void AddNewElement(T value)
    {
        var key = GetHash(value);
        _myStorage[key].Notes.Add(value);
    }
    public void FindFirst(T value)
    {
        var key = GetHash(value);

        var contains = _myStorage[key].Notes.Contains(value);

        Console.WriteLine(contains
            ? $"В таблице есть такой элемент под индексом {key}"
            : "В таблице НЕТ такого элемента");
    }
    
    public T[] GetArray()
    {
        var collection = GetCollectionWithValue().ToArray();
        
        var list = new List<T>();
        for (int i = 0; i < collection.Count(); i++)
        {
            for (int j = 0; j < collection[i].Notes.Count; j++)
            {
                list.Add(collection[i].Notes[j]);
            }
            
        }
        return list.ToArray();
    }

    public int IndexFromElement(T element)
    {
        var key = GetHash(element);
        var hasElement = _myStorage[key].Notes.Contains(element);

        return hasElement ? key : throw new MyException("Нет такого элемента в таблице, невозможно получить индекс");
    }

    public T[] ElementsFromIndex(int index)
    {
        if (_myStorage[index].Notes.Count() == 0) throw new MyException("Здесь пусто");

        return _myStorage[index].Notes.ToArray();
    }
    
    public T[] PartOfArray(int firstIndex, int secondIndex)
    {
        var myArray = GetArray();
        if (secondIndex > myArray.Length - 1 || secondIndex <= firstIndex)
            throw new ArgumentOutOfRangeException($"Второй индекс должен быть больше первого и меньше {myArray.Length}");
        var count = secondIndex - firstIndex + 1;
        var tempArray = new T[count];
        Array.Copy(myArray,firstIndex,tempArray,0,count);
        return tempArray;
    }
    private IEnumerable<Item<T>> GetCollectionWithValue()
    {
        return _myStorage.Where(p => p.Notes.Count != 0);
    }
    private int GetHash(T value)
    {
        if (value == null) throw new NullReferenceException();
        return value.GetHashCode() % _myStorage.Length;
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

public class Something
{
    public int Value { get; set; }
    public string Name { get; set; }

    public Something(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override int GetHashCode()
    {
        return Math.Abs(Name.Length * Value + Name[0]);
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Something)) return false;
        var something = (Something)obj;

        return Name == something.Name && Value == something.Value;
    }
}