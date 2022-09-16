using System.Reflection.Metadata.Ecma335;

namespace Learning;

public interface InterfaceLesson
{
}

public interface IMovable
{
    public const int MIN_SPEED = 0;
    private static int maxSpeed = 65;
    string Name { get; set; }
    void Move();

    delegate void MoveHandler(string message);

    event MoveHandler MoveEvent;

    static int MaxSpeed
    {
        get => maxSpeed;
        set
        {
            if (value > 0)
            {
                maxSpeed = value;
            }
        }
    }

    static double GetTime(double distance, double speed) => distance / speed;
}

public class Runner:IMovable
{
    public string Name { get; set; }
    public void Move()
    {
        
    }

    public event IMovable.MoveHandler? MoveEvent;
}

interface IMovabl
{
    void Move() => Console.WriteLine("Moving"); // Метод по умолчанию, в классе необязательно объявлять
}

public class Bike : IMovabl
{
   //Класс move не обяъвлен, поэтому по умолчанию.
}

struct Car : IMovabl
{
    public void Move()
    {
        Console.WriteLine("Car moving");
    }
}

interface IMessage
{
    string Text { get; set; }
}

interface IPrint
{
    void Print();
}

class Message : IMessage, IPrint
{
    public string Text { get; set; }

    public Message(string text)
    {
        Text = text;
    }
    public void Print()
    {
        Console.WriteLine(Text);
    }
}

interface INew
{
    void Neew();
}

interface INewToo : INew
{
    new void Neew();
}

interface INewest : INewToo
{
    void Newest();
}

class Toy : INewest
{
    public void Neew()
    {
        throw new NotImplementedException();
    }
    
    public void Newest()
    {
        throw new NotImplementedException();
    }
}

interface IFoo
{
    void Execute();
}

interface IBar
{
    void Execute();
}

class Tst:IFoo,IBar
{
    void IFoo.Execute()
    {
        Console.WriteLine("f");
    }

    void IBar.Execute()
    {
        Console.WriteLine("b");
    }
}