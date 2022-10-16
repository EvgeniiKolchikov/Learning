namespace Learning;

public class MultiThreadingLesson
{
    public void Introduction()
    {
        Thread currentTread = Thread.CurrentThread;

        Console.WriteLine($"Имя потока: {currentTread.Name}");
        currentTread.Name = "Метод Main";
        Console.WriteLine($"Имя потока: {currentTread.Name}");

        Console.WriteLine($"Запущен ли поток: {currentTread.IsAlive}");
        Console.WriteLine($"Id потока: {currentTread.ManagedThreadId}");
        Console.WriteLine($"приоритет потока: {currentTread.Priority}");
        Console.WriteLine($"Статус потока: {currentTread.ThreadState}");

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);
            Console.WriteLine(i);
        }
    }

    public void Start()
    {
        var thread1 = new Thread(Print);
        var thread2 = new Thread(new ThreadStart(Print));
        var thread3 = new Thread(() => Console.WriteLine("Hello Threads"));

    //Для запуска потока применяем метод Start()
        thread1.Start();
        thread2.Start();
        thread3.Start();

        void Print() => Console.WriteLine("Hello Threading");
    }

    public void ThreadProgram()
    {
        var thread1 = new Thread(Print);
        thread1.Start();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Главный поток: {i}");
            Thread.Sleep(300);
        }

        void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Второй поток: {i}");
                Thread.Sleep(200);
            }
        };
    }

    public void ThreadProgram2()
    {
        var tom = new Person("Tom", 18);

        var thread = new Thread(tom.Print);

        thread.Start();
    }
    record class Person(string Name, int Age)
    {
        public void Print()
        {
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Age = {Age}");
        }
    }

    public void SyncMethod()
    {
        static void WriteSecond()
        {
   
            for (var i = 0; i < 10; i++)
            {
                lock (CRSync.block)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new string(' ',20) + "Second");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Thread.Sleep(200);
                }
            }
        }


        var thread = new Thread(WriteSecond);
        thread.Start();

        for (int i = 0; i < 10; i++)
        {
            lock (CRSync.block)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(new string("First"));
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(200);
            }
        }

    }

    public void MonitorAutoResetEvenMutex()
    {
        var x = 0;
        var locker = new object();
        var waitHandler = new AutoResetEvent(true);
        var mutex = new Mutex();


        for (int i = 0; i < 5; i++)
        {
            var thread = new Thread(LockPrint);
            thread.Name = $"Поток {i}";
            thread.Start();
        }

        Console.Read();

        void LockPrint()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                    x++;
                    Thread.Sleep(100);

                }
            }
    
        }

        void MonitorPrint()
        {
            var acquiredLock = false;
            try
            {
                Monitor.Enter(locker,ref acquiredLock);
                x = 1;
        
            }
            finally
            {
                if (acquiredLock)
                {
                    Monitor.Exit(locker);
                }
            }
        }

        void AutoResetEventPrint()
        {
            waitHandler.WaitOne();
            x = 1;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                x++;
                Thread.Sleep(100);
            }

            waitHandler.Set();
        }

        void MutexPrint()
        {
            mutex.WaitOne();
            x = 1;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                x++;
                Thread.Sleep(100);
            }
    
            mutex.ReleaseMutex();
        }
    }
}

public class CRSync
{
    static public object block = new object();

    public void Method()
    {
        var hash = Thread.CurrentThread.GetHashCode();
        lock (block)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread # {hash}: step {i}");
                Thread.Sleep(200);
            }
            
            Console.WriteLine(new string('_',20));
        }
    }
}

public class MyReader
{
    private static Semaphore sem = new Semaphore(3, 3);
    private Thread myThread;
    private int count = 2;
    private object locker = new object();
    

    public MyReader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читатель{i}";
        myThread.Start();
    }

    public void Read()
    {
       
            sem.WaitOne();
            lock (locker)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
 
                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);
 
                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
                sem.Release();

                count--;
            }
        
    }
}