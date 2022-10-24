namespace Learning;

public class ParallelLesson
{
    public void Run()
    {
        Parallel.Invoke(
            Print,
            () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            },
            () => Square(5)
            );
    }

    private void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
        Console.WriteLine($"Результат {n * n}");
    }


    private void Print()
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
    }
}

public class ParallelForLesson
{
    public void Run()
    {
        Parallel.For(1, 5, Square);
    }
    
    private void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Console.WriteLine($"Результат {n * n}");
        Thread.Sleep(1000);
    }
}

public class ParallelForeachLesson
{
    public void Run()
    {
        ParallelLoopResult result = Parallel.ForEach(new List<int> { 1, 3, 5, 7 }, Square);
    }
    
    private void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Console.WriteLine($"Результат {n * n}");
        Thread.Sleep(1000);
    }
}

public class ParallelBreakLesson
{
    public void Run()
    {
        ParallelLoopResult result = Parallel.For(1, 10, Square);
        if (!result.IsCompleted)
        {
            Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
        }
        
        
    }
    private void Square(int n, ParallelLoopState pls)
    {
        if (n== 5) pls.Break();
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Console.WriteLine($"Результат {n * n}");
        Thread.Sleep(1000);
    }
}