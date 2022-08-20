namespace Learning;

public class Dz
{
    private object[] _array;
    private int dimension = 8;
    
    public Dz()
    {
        _array = new object[dimension];
        
    }

    public void AddNewElement(int value)
    {
        
        for (int i = 0; i < _array.Length - 1; i++)
        {
            if (_array[i] == null)
            {
                _array[i] = value;
                return;
            }
        }
    }

    public int[] GetArray()
    {
        var tempArray = ArrayNullClean(_array);
        return ConvertObjectArrayToIntArray(tempArray);
    }

    public int? ElementFromIndex(int index)
    {
        var nullCleanedArray = ArrayNullClean(_array);
        if (index <= nullCleanedArray.Length - 1)
        {
            return (int)nullCleanedArray[index];
        }

        return null;
    }

    public int IndexFromElement(int element)
    {
        var nullCleanedArray = ArrayNullClean(_array);
        
        for (int i = 0; i < nullCleanedArray.Length; i++)
        {
            if ((int)nullCleanedArray[i] == element)
            {
                return i;
            }
        }
        return -1;
    }

    
    public int[] PartOfArray(int firstIndex, int secondIndex)
    {
        var count = secondIndex - firstIndex;
        var arrayNullCleaned = ArrayNullClean(_array);
        if (secondIndex >= _array.Length - 1)
        {
            Array.Copy(arrayNullCleaned, firstIndex, _array, 0, secondIndex);
        }
        
        return ConvertObjectArrayToIntArray(_array);

    }

    private object[] ArrayNullClean(object[] array)
    {
        return array.Where(x => x != null).ToArray();
    }

    private int[] ConvertObjectArrayToIntArray(object[] array)
    {
        return   Array.ConvertAll<object,int>(ArrayNullClean(array).ToArray(), (o) => (int)o);
    }

    private void CheckIndexOut(ref object[] array, int dimension)
    {
        var length = array.Length;
        if (array.Length % dimension == 0)
        {
            array = new object[length + dimension];
            
        }
    }
}