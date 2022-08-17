using System.Threading.Channels;

namespace Learning;

public class MethodLesson
{
    public void Hello()
    {
        Console.WriteLine("Hello");
    }

    public void SayHello() => Console.WriteLine("Hello");

    public void PrintMessage(string message) => Console.WriteLine(message);

    public void Sum(int x, int y)
    {
        int result = x + y;
        Console.WriteLine($"{x} + {y} = {result}");
    }

    public void Sum2(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");

    public void PrintPerson(string name, int age) => Console.WriteLine($"Name: {name} - {age}");

    public void PrintPersonOptional(string name = "Bob", int age = 5, string company = "Standart")
    {
        Console.WriteLine($"Name - {name}, age - {age}, Company - {company}");
    }
}