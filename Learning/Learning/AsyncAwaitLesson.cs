namespace Learning;

public class AsyncAwaitLesson
{
   
    public async Task ShowMessageAsync()
    {
        Console.WriteLine(DateTime.Now);
        
        await Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"First methd - {i} element ");
                Thread.Sleep(100);
            }
        });
        Console.WriteLine("Первый метод закончился " + DateTime.Now);
    }

    public async Task ShowMessage2Async()
    {
        
        await Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Second methd - {i} element ");
                Thread.Sleep(100);
            }
        });
        Console.WriteLine("Второй метод закончился: " + DateTime.Now);
    }
}


// Если тип возвращаемого значения метода void то мы не можем использовать await для методов void,