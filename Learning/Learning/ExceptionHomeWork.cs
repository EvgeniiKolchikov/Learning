namespace Learning;

public class ExceptionHomeWork<T>
{
    private Element<T>[] _myStorage;
    private Element<T>[] MyStorage
    {
        get => _myStorage;
        set => _myStorage = value;
    }
    public ExceptionHomeWork()
    {
        MyStorage = new Element<T>[8];
        for (var i = 0; i < MyStorage.Length; i++)
        {
            MyStorage[i] = new Element<T>();
        }
    }
    public Element<T> this[int index]
    {
        get => MyStorage[index];
        set => MyStorage[index] = value;
    }
    public void AddNewElement(T value)
    {
        foreach (var element in MyStorage)
        {
            if (element.IsActive) continue;
            element.Value = value;
            element.IsActive = true;
            CheckIndexOut(ref _myStorage);
            return;
        }
    }

    public T[] GetArray()
    {
        var activeArray = GetActiveElementsFromArray(MyStorage);
        var resultArray = new T[activeArray.Length];
        for (var i = 0; i < activeArray.Length; i++)
        {
            resultArray[i] = activeArray[i].Value;
        }
        return resultArray;
    }
    
    public T ElementFromIndex(int index)
    {
        var activeArray = GetActiveElementsFromArray(MyStorage);

        switch (activeArray.Length)
        {
            case 0 when index != 0:
                throw new ArgumentOutOfRangeException($"Индекс должен быть от 0, т.к. массив пустой");
            case > 0 when index != 0:
                throw new ArgumentOutOfRangeException($"Индекс должен быть от 0 до {activeArray.Length - 1}");
        }

        if (index >= 0 && index < activeArray.Length && activeArray.Length > 0)
        {
            return activeArray[index].Value;
        }
        return default; 
    }
    
    public int IndexFromElement(T element)
    {
        var activeArray = GetActiveElementsFromArray(MyStorage);
        
        for (var i = 0; i < activeArray.Length; i++)
        {
            if (activeArray[i].Value.Equals(element))
            {
                return i;
            }
        }
        return -1;
    }
    
    public T[] PartOfArray(int firstIndex, int secondIndex)
    {
        var myArray = GetArray();
        if (myArray.Length == 0) throw new MyException("Массив пустой, нельзя получить данные");
        if (secondIndex > myArray.Length - 1 || secondIndex <= firstIndex)
            throw new MyException($"Второй индекс должен быть больше первого и меньше {myArray.Length + 1}");
        var count = secondIndex - firstIndex + 1;
        var tempArray = new T[count];
        Array.Copy(myArray,firstIndex,tempArray,0,count);

        return tempArray;
    }

    public void DeleteElement(int index)
    {
        var activeArray = GetActiveElementsFromArray(MyStorage);
        if (activeArray.Length == 0) throw new MyException("Нельзя удалить из пустого массива");
        if (index >= activeArray.Length || index < 0)
            throw new MyException($"индекс должен быть больше 0 и меньше {activeArray.Length + 1}");
        activeArray[index].Value = default!;
        activeArray[index].IsActive = false;
    }
    private Element<T>[] GetActiveElementsFromArray(Element<T>[] array)
    {
        return array.Where(x => x.IsActive).ToArray();
    }
    
    private void CheckIndexOut(ref Element<T>[] array)
    {
        if (array[^1].IsActive == false) return;
        var tempArray = array;
        array = new Element<T>[array.Length + 8];
        Array.Copy(tempArray,array,tempArray.Length);
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] is not null) continue;
            array[i] = new Element<T>();
        }
    }
   
}
public class Element<T>
{
    public T Value { get; set; }
    public bool IsActive { get; set; }
}

public class MyException : Exception
{
    public MyException(string message)
    {
        Console.WriteLine(message);
    }
}