using System.Threading.Channels;

namespace Learning;

public class ArrayLesson
{
    public void Run()
    {

        //объявление массивов
        var numbers = new int[4];
        var numbers2 = new int[4] { 1, 2, 3, 4 };
        var numbers3 = new int[] { 1, 2, 3, 4, 5 };
        var numbers4 = new[] { 1, 2, 3, 4 };
        var numbers5 = new[] { 1, 2, 3, 4, 5 };

        string[] people = { "tom", "rrj" };

        Console.WriteLine("Получение массивов");

        Console.WriteLine(numbers5[3]);

        numbers4[2] = 444;
        Console.WriteLine(numbers4[2]);

        Console.Write("Length array: \t");
        Console.WriteLine(numbers.Length);

        //Length - 1 == [^1...]
        Console.WriteLine(numbers2[numbers.Length -1]);
        Console.WriteLine(numbers2[^1]); // первый с конца

        for (int i = 0; i < numbers3.Length;)
        {
            
            numbers3[i] += 100;
            Console.WriteLine(numbers3[i]);
            i += 2;
        }
        
        
        // Двумерные массивы

        var numb1 = new int[2, 3];
        int[,] numb4 = new int[2, 2] { { 2, 1 }, { 3, 3 } };
        int[,] numb2 = new[,] { { 1, 2 }, { 3, 4 } };
        int[,] numb3 = new[,] { { 1, 1, 1 }, { 22, 2, 2 } };
        int[,] numb = { { 1, 2, 3 }, { 4, 5, 6} };
        
        foreach (var n in numb)
        {
            Console.Write(n);
        }

        Console.WriteLine();
        Console.WriteLine($"numb length = {numb.Length}");

        var row = numb.GetUpperBound(0) + 1;
        var column = numb.Length / row;
        
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write($"{numb[i,j]} \t");
            }

            Console.WriteLine();
        }
    }
}