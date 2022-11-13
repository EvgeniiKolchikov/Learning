using System.Transactions;

namespace Learning;

public class GarbageCollectorLesson
{
    public void Using_Method()
    {
        using (var person = new PersonGC("Tom"))
        {
            Console.WriteLine($"Name: {person.Name}");
        }

        Console.WriteLine("Конец метода");
    }
    public void DestructorCall_Method()
    {
        Test();
        GC.Collect();
        Console.Read();
    }
    public void DisposeCall_Method()
    {
        PersonGC? person = null;
        try
        {
            person = new PersonGC("Tom");
        }
        finally
        {
            person?.Dispose();
        }
    }
    private void Test()
    {
        var person = new PersonGC("Tom");
        Console.WriteLine($"{person.Name} added");
    }
}

public class PersonGC : IDisposable
{
    public string Name { get; set; }
    public PersonGC(string name)
    {
        Name = name;
        Console.WriteLine($"{Name} added");
    }
    ~PersonGC()
    {
        Console.WriteLine($"{Name} has deleted");
    }
    public void Dispose()
    {
        Console.WriteLine($"{Name} is disposed");
    }
}

