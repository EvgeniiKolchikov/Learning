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

class Tst:IFoo
{
    public void Execute()
    {
        Console.WriteLine("Void in Tst Class");
    }

   
}

interface IScool
{
    void Study();
}

interface IUniversity
{
    void Study();
}

class StudyPerson : IScool, IUniversity
{
    void IScool.Study() => Console.WriteLine("Scool study");
    void IUniversity.Study() => Console.WriteLine("University study");
}

class TestPers : Tst, IFoo
{
    public void Execute() => Console.WriteLine("Void in TestPers Class");
}

interface IAction
{
    void Move();
}

class BaseAction : IAction
{
    public void Move()
    {
        Console.WriteLine("Move in BaseAction Class");
    }
}

class HeroAction : BaseAction, IAction
{
    public new void Move()
    {
        Console.WriteLine("Move in HeroAction Class");
    }

    void IAction.Move() => Console.WriteLine("Move in IAction Interface");
}

interface IMessage1
{
    string Text { get; set; }
}

interface IPrint1
{
    void Print();
}

class Message1: IMessage1, IPrint1
{
    public string Text { get; set; }

    public Message1(string text) => Text = text;
    public void Print()
    {
        Console.WriteLine(Text);
    }
}

class Messenger<T> where T : IMessage1, IPrint1
{
    public void Send(T message)
    {
        Console.WriteLine("Отправляется сообщение: ");
        message.Print();
    }
}

interface IPrintableMessage : IMessage1, IPrint1 {}

class PrintableMessage : IPrintableMessage
{
    public string Text { get; set; }
    public PrintableMessage(string text) => Text = text;
    public void Print() => Console.WriteLine(Text);
}

interface IUser<T>
{
    T Id { get; }
}

class User<T> : IUser<T>
{
    public T Id { get; set; }
    public User(T id) => Id = id;
}

class IntUser : IUser<int>
{
    public int Id { get; }
    public IntUser(int id) => Id = id;
}

class PPerson : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public CCompany Company { get; set; }
    public PPerson(string name, int age, CCompany company)
    {
        Name = name;
        Age = age;
        Company = company;
    }

    //public object Clone() => MemberwiseClone(); // неглубокое копирование, в нем копируются только простые поля,
    //для копирования сложных полей необходимо глубокое, при текущем копировании изменение поля Name в класса CCompany
    //в объекте, который скопирован, изменит поля копируемого объекта 
    public object Clone() => new PPerson(Name, Age, new CCompany(Company.Name)); //Глубокое копирование,

}

interface ICloneable
{
    object Clone();
}

class CCompany
{
    public string Name { get; set; }
    public CCompany(string name) => Name = name;
}

class ComparablePerson : IComparable<ComparablePerson>
{
    public string Name { get;}
    public int Age { get; set; }
    public ComparablePerson(string name, int age)
    {
        Name = name; Age = age;
    }
    
    public int CompareTo(ComparablePerson? person)
    {
        if (person is null)  throw new ArgumentException("Параметр метода null");
        return Age - person.Age;
    }
}

class Comparator : IComparer<ComparablePerson>
{
    public int Compare(ComparablePerson p1, ComparablePerson p2)
    {
        if (p1 is null || p2 is null) throw new ArgumentException("Null");
        return p1.Name.Length - p2.Name.Length;
    }
}