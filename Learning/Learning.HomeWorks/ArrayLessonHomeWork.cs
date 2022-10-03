namespace Learning;

public class ArrayLessonHomeWork
{
    private int?[] _array;
    
    public ArrayLessonHomeWork()
    {
        _array = new int?[8];
    }

    public void AddNewElement(int value)
    {
        for (var i = 0; i <= _array.Length - 1; i++)
        {
            if (_array[i] != null) continue;
            _array[i] = value;
            CheckIndexOut(ref _array);
            return;
        }
    }

    public int?[] GetArray()
    {
        return ArrayNullClean(_array);
    }

    public int? ElementFromIndex(int index)
    {
        var nullCleanedArray = ArrayNullClean(_array);
        if (index <= nullCleanedArray.Length - 1)
        {
            return nullCleanedArray[index];
        }

        return null;
    }

    public int IndexFromElement(int element)
    {
        var nullCleanedArray = ArrayNullClean(_array);
        
        for (var i = 0; i < nullCleanedArray.Length; i++)
        {
            if (nullCleanedArray[i] == element)
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

    private static int?[] ArrayNullClean(int?[] array)
    {
        return array.Where(x => x != null).ToArray();
    }
    
    private static void CheckIndexOut(ref int?[] array)
    {
        var tempArray = array;
        var length = array.Length;
        if (array[^1] == null) return;
        array = new int?[length + 8];
        Array.Copy(tempArray,array,tempArray.Length);
    }
}