namespace Patterns;

public static class Strategy
{
    public static void Run()
    {
        var car = new Car(4, "BAZ", new PertolMove());
        car.Move();
        car.Movable = new ElecticMove();
        car.Move();
    }
}

public interface IMovable
{
    void Move();
}

public class PertolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Перемещение на бензине");
    }
}

public class ElecticMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Перемещение на электичестве");
    }
}

public class Car
{
    private int passengerCount;
    private string model;
    public IMovable Movable;

    public Car(int passengerCount, string model, IMovable movable)
    {
        this.passengerCount = passengerCount;
        this.model = model;
        Movable = movable;
    }

    public void Move()
    {
        Movable.Move();
    }
}