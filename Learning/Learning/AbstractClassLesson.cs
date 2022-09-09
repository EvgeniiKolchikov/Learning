namespace Learning;

public class AbstractClassLesson
{
}

/*public abstract class Transport
{
    public string Name { get; }

    public Transport(string name)
    {
        Name = name;
    }
    public void Move()
    {
        Console.WriteLine($"{Name} движется");
    }
}

public class Car : Transport
{
    public Car(string name) : base(name){}
}

public class Aircraft : Transport
{
    public Aircraft(string name):base(name){}
}

public class Ship : Transport
{
    public Ship(string name): base(name){}
}*/

/*public abstract class Transport
{
    public abstract void Move();
}

public class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine("Машина движется");
    }
}

public class Aircraft : Transport
{
    public override void Move()
    {
        Console.WriteLine("Самолет летит");
    }
}

public class Ship : Transport
{
    public override void Move()
    {
        Console.WriteLine("Корабль плывет");
    }
}*/

public abstract class Shape
{
    public abstract double GetPerimeter();
    public abstract double GetArea();
}

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override double GetPerimeter()
    {
        return 2 * Width + 2 * Height;
    }

    public override double GetArea()
    {
        return Height * Width;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }
    public override double GetPerimeter()
    {
        return 2 * 3.14 * Radius;
    }

    public override double GetArea()
    {
        return 3.14 * Math.Pow(Radius,2);
    }
}