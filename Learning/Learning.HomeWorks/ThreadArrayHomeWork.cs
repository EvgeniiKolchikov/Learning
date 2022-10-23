namespace Learning.HomeWorks;

public class ThreadArrayHomeWork
{
    private int[] nArray;
    private Random rnd;
    private object locker;
    private AutoResetEvent waitHandler;

    public ThreadArrayHomeWork(int size)
    {
        waitHandler = new AutoResetEvent(true);
        locker = new object();
        rnd = new Random();
        nArray = new int[size];
        for (var i = 0; i < nArray.Length; i++)
        {
            nArray[i] = rnd.Next(1, 4);
        }
    }

    public void ThreadMethod()
    {
        lock(locker)
        {
            var thread1 = new Thread(ShowElement);
            var thread2 = new Thread(ShowElement);
            var thread3 = new Thread(ShowElement);
            
            thread1.Start(1);
            thread2.Start(2);
            thread3.Start(3);
        }
    }

    public void TaskMethod()
    {
        var task1 = new Task(() => ShowElement(nArray,1));
        var task2 = new Task(() => ShowElement(nArray,2));
        var task3 = new Task(() => ShowElement(nArray,3));
        
        task1.RunSynchronously();
        task2.RunSynchronously();
        task3.RunSynchronously();
    }
    
    private void ShowElement(int[] array, int number)
    {
        var elem = array.Where(x => x == number).ToArray();
        for (var index = 0; index < elem.Length; index++)
        {
            Console.WriteLine(elem[index]);
        }
    }

    private void ShowElement(object? obj)
    {
        if (obj is not int number) throw new ArgumentException("нужен инт");
        var elem = nArray.Where(x => x == number);
        foreach (var el in elem)
        {
            Console.WriteLine(el);
        }
    }
}