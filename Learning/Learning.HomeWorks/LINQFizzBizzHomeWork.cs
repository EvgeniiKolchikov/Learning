namespace Learning.HomeWorks;

public class LINQFizzBizzHomeWork
{
    private List<int> MyList { get; }

    public LINQFizzBizzHomeWork()
    {
        var rnd = new Random(); 
        MyList = new List<int>();

        for (int i = 0; i < 30; i++)
        {
            MyList.Add(rnd.Next(1, 31));
        }
    }

    public void Run()
    {
        var resCollection = MyList.Select(n => new string($"{n} - {Check(n)}"));
       
        foreach (var elem in resCollection)
        {
            Console.WriteLine(elem);
        }

    }

    private string Check(int n)
    {
        if (n % 3 == 0 && n % 5 == 0)
        {
            return "FizzBizz";
        }
        if (n % 3 == 0)
        {
            return "Fizz";
        } 
        if (n % 5 == 0)
        {
            return "Bizz";
        }
        return "";
    }
}