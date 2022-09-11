namespace Learning;


public class Storage<T>
{ 
    private ArrayElement<T>[] MyStorage { get; set; }
    public Storage()
    {
        MyStorage = new ArrayElement<T>[8];
        for (var i = 0; i < MyStorage.Length; i++)
        {
            MyStorage[i] = new ArrayElement<T>();
        }
    }
    public void AddNewElement(T value)
    {
        foreach (var element in MyStorage)
        {
            if (element.IsActive) continue;
            element.Value = value;
            element.IsActive = true;
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
    
    // public T ElementFromIndex(int index)
    // {
    //     var activeArray = GetActiveElementsFromArray(MyStorage);
    //     if (index <= nullCleanedArray.Length - 1)
    //     {
    //         return nullCleanedArray[index];
    //     }
    //
    //     return null;
    // }
    /*
    public T IndexFromElement(T element)
    {
        var nullCleanedArray = ArrayNullClean(_array);
        
        for (var i = 0; i < nullCleanedArray.Length; i++)
        {
            if (nullCleanedArray[i] )
            {
                return i;
            }
        }
        return -1;
    }
    
    public int?[] PartOfArray(int firstIndex, int secondIndex)
    {
        var arrayNullCleaned = ArrayNullClean(_array);
        if (secondIndex > arrayNullCleaned.Length - 1 || secondIndex <= firstIndex) return null;
        var count = secondIndex - firstIndex + 1;
        var tempArray = new int?[count];
            
        Array.Copy(arrayNullCleaned,firstIndex, tempArray,0,count);
        return tempArray;
    }
    */
    
    private static ArrayElement<T>[] GetActiveElementsFromArray(ArrayElement<T>[] array)
    {
        return array.Where(x => x.IsActive).ToArray();
    }
    /*
    private static void CheckIndexOut(ref T[] array)
    {
        var tempArray = array;
        var length = array.Length;
        if (array[^1] == null) return;
        array = new T[length + 8];
        Array.Copy(tempArray,array,tempArray.Length);
    }*/

    private class ArrayElement<T>
    {
        public T Value { get; set; }
        public bool IsActive { get; set; }
    }
}