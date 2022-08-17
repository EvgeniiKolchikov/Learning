namespace Learning;

public class LoopLesson
{
    public void Run()
    {
        Console.WriteLine("For цикл");
        for (var i = 0; i < 4; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("do while цикл");
        
        var j = 0;
        do
        {
            Console.WriteLine(j);
            j++;
        } 
        while (j < 4 && j > 0);

        Console.WriteLine("while цикл");

        int k = 8;
        while (k > 4)
        {
            Console.WriteLine(k + "\t");
            k--;
        }
    
        Console.WriteLine("foreach цикл");

        int[] myArray = new[] { 1, 2, 3, 4, 5 };
        foreach (var value in myArray)
        {
            Console.WriteLine(value.ToString());
        }

        Console.WriteLine("break команда c for");

        for (int l = 0; l < 7; l++)
        {
            Console.WriteLine(l);
            if (l==4)
                break;
        }

        Console.WriteLine("c foreach");
        
        foreach (var val in myArray)
        {
            if (val > 3)
            {
                Console.WriteLine("break val > 3");
                break;
            }

            Console.WriteLine(val.ToString());
        }

        

        Console.WriteLine("Двойной цикл");

        for (int r = 1; r < 3; r++)
        {
            for (int t = 1; t < 3; t++)
            {
                Console.Write($"{r * t} \t");
            }

            Console.WriteLine();
        }
    }
}