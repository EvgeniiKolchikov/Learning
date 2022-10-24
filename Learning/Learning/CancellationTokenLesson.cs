namespace Learning;

public class CancellationTokenLesson
{
    public void Run()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var token = cancellationTokenSource.Token;

        var task = new Task(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                Thread.Sleep(500);
            }
        }, token);

        task.Start();
        
        Thread.Sleep(5000);
        cancellationTokenSource.Cancel();
        Thread.Sleep(2000);

        Console.WriteLine($"Task status: {task.Status}");
        cancellationTokenSource.Dispose();
    }
}

public class CancellationTokenExceptionLesson
{
    public void Run()
    {
        var cancelTokenSource = new CancellationTokenSource();
        var token = cancelTokenSource.Token;

        var task = new Task(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
                Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                Thread.Sleep(200);
            }
        }, token);

        try
        {
            task.Start();
            Thread.Sleep(1000);
            cancelTokenSource.Cancel();

            task.Wait(); // если нет метода Wait то исключение не будет вызвано, прекратится выполнение потока со статусом Canceled
        }
        catch (AggregateException ae)
        {
            foreach (var exception in ae.InnerExceptions)
            {
                Console.WriteLine(exception is TaskCanceledException ? "Операция прервана" : ae.Message);
            }
            
        }
        finally
        {
            cancelTokenSource.Dispose();
        }
        Thread.Sleep(1000);
        Console.WriteLine($"Task status: {task.Status}");
    }
}

public class CancellationTokenRegisterLesson
{
    public void Run()
    {
        var cancelTokenSource = new CancellationTokenSource();
        var token = cancelTokenSource.Token;

        var task = new Task(() =>
        {
            var i = 0;

            token.Register(() =>
            {
                Console.WriteLine("Операция прервана");
                i = 10;
            });

            for (; i < 10; i++)
            {
                Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                Thread.Sleep(400);
            }

        }, token);

        task.Start();
        Thread.Sleep(1000);      
        
        cancelTokenSource.Cancel();
        
        Thread.Sleep(3000);
        Console.WriteLine($"Task Status: {task.Status}");
        cancelTokenSource.Dispose();
        
    }
}

public class CancellationTokenExternalMethodLesson
{
    public void Run()
    {
        var cancelTokenSource = new CancellationTokenSource();
        var token = cancelTokenSource.Token;

        var task = new Task(() => PrintSquare(token), token);

        try
        {
            task.Start();
            
            Thread.Sleep(1000);
            
            cancelTokenSource.Cancel();
            task.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var exc in ae.InnerExceptions)
            {
                Console.WriteLine(exc is TaskCanceledException ? "Операция прервана" : ae.Message);
            }
        }
        finally
        {
            cancelTokenSource.Dispose();
        }
        
        Console.WriteLine($"Task Status: {task.Status}");

    }

    void PrintSquare(CancellationToken token)
    {
        for (int i = 0; i < 100; i++)
        {
            if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(200); 
        }
    }
}

public class ParallelCancelLesson
{
    public void Run()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;

        new Task(() =>
        {
            Thread.Sleep(1000);
            cancelTokenSource.Cancel();
        }).Start();

        try
        {
            Parallel.For(1, 25, new ParallelOptions { CancellationToken = token }, Square);
        }
        catch (Exception e)
        {
            Console.WriteLine("Операция отменена");
            
        }
        finally
        {
            cancelTokenSource.Dispose();
        }
        void Square(int n)
        {
            Thread.Sleep(400);
            Console.WriteLine($"Квадрат числа {n} равен {n * n}");
        }
    }
}