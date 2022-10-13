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
}