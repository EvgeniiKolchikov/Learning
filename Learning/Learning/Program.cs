using System.Collections;
using Learning;

static IEnumerable<string> GetListString()
{
    var retList = new List<string>();
    var value = "1";
    for (int i = 0; i < 10; i++)
    {
        retList.Add(value);
        value += "i";
        yield return retList[i];
    }
    
}

foreach (var i in GetListString())
{
    Console.WriteLine(i);
    Console.ReadKey();
}


IEnumerable<int> GetPrimeNumbers(int count)
{
    
    for (var i = 2; i < count; i++)
    {
        if (count % i != 0)
        {
            yield return i;
        }
    }
}

foreach (var t in GetPrimeNumbers(100))
{
    Console.WriteLine(t);
    Console.ReadKey();
}

