namespace Learning;


public class LambdaExpressionLesson
{
    public delegate int Operation(int x, int y);

    public delegate int Square(int x);

    public delegate void Hello();

    public delegate bool IsEqual(int n);

    public void Run()
    {
        // Анонимный делегат
        Operation operation = delegate(int x, int y)
        {
            return x + y;
        };
        // Упрощаем анонимный делегат в лямбду-выражение
        Operation lambdaOperation = (x, y) => x + y;
        Console.WriteLine(lambdaOperation(3,5));
        // После => - возращаемое значение
        Operation op = (int x, int y) => 2;
        Console.WriteLine(op(2,4)); //  2
        
        // Лямбда с одним параметром
        Square square = x => x * x; // тоже самое, что Square square = (x) => x * x;
        
        //Лямбла без параметров
        Hello hello1 = () => Console.WriteLine("Hello");
        Hello hello2 = () => Console.WriteLine("Welcome");
        hello1();
        hello2();
        
        // Набор инструкций
        Operation l = (x, y) =>
        {
            if (x > y)
            {
                return x - y;
            }

            return y - x;
        };
        Console.WriteLine(l(3,4));

        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int x1 = Sum(numbers, n => n > 5);
        int x2 = Sum(numbers, n => n % 2 == 0);
        
        Console.WriteLine(x1);
        Console.WriteLine(x2);

    }

    static int Sum(int[] numbers, IsEqual func)
    {
        var result = 0;
        foreach (var n in numbers)
        {
            if (func(n)) result += n;
        }

        return result;
    }
    
}