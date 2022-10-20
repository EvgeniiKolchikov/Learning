namespace Learning;

public class TPLLesson
{
    public void TaskMethod()
    {
        var task = new Task(() => Console.WriteLine("Task"));
        task.Start();

        var taskWithFactory = Task.Factory.StartNew(() => Console.WriteLine("Task with Factory"));

        var taskWithRun = Task.Run(() => Console.WriteLine("Task with Run"));

        task.Wait();
        taskWithFactory.Wait();
        taskWithRun.Wait();
    }

    public void TaskWait()
    {
        Console.WriteLine("Main started");

        var task = new Task(() =>
        {
            Console.WriteLine("Tsk Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task Finished");
        });
        
        task.Start();
        task.Wait();

        Console.WriteLine("Main Ended");
    }
    
    public void TaskWait2()
    {
        Console.WriteLine("Main started");

        var task = new Task(() =>
        {
            Console.WriteLine("Tsk Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task Finished");
        });
        
        task.Start();
        Console.WriteLine("Main Ended");
        task.Wait();
    }
    public void TaskWaitRunSynchronously()
    {
        Console.WriteLine("Main started");

        var task = new Task(() =>
        {
            Console.WriteLine("Tsk Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task Finished");
        });
        
        task.RunSynchronously();
        Console.WriteLine("Main Ended");
    }
    
    public void TaskProperies()
    {
        var task = new Task(() =>
        {
            Console.WriteLine($"Task {Task.CurrentId} Started");
            Thread.Sleep(500);
            Console.WriteLine($"Task {Task.CurrentId} Finished");
        });
        
        task.Start();
        Console.WriteLine($"task id: {task.Id}");
        Console.WriteLine($"task is completed: {task.IsCompleted}");
        Console.WriteLine($"task status: {task.Status}");
        task.Wait();
        Console.WriteLine($"task id: {task.Id}");
        Console.WriteLine($"task is completed: {task.IsCompleted}");
        Console.WriteLine($"task status: {task.Status}");
    }

    public void TaskArray()
    {
        // Task[] taskArr = new Task[3]
        // {
        //     new Task(() => Console.WriteLine("First Task")),
        //     new Task(() => Console.WriteLine("Second Task")),
        //     new Task(() => Console.WriteLine("Third Task"))
        // };
        //
        // foreach (var task in taskArr)
        // {
        //     task.Start();
        // }

        var tasks = new Task[3];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Task{i} finished");
            });
            tasks[i].Start();
            tasks[i].Wait();
        }

        Console.WriteLine("Main finished");
    }

    public void TaskSum()
    {
        var n1 = 4; var n2 = 5;

        Task<int> task = new Task<int>(() => Sum(n1, n2));
        task.Start();
        var result = task.Result;

        Console.WriteLine($"{n1} + {n2} = {result}");

        int Sum(int a, int b) => a + b;
    }
}