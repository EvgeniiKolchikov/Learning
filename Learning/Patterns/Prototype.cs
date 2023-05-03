namespace Patterns;

public static class Prototype
{
    public static void Run()
    {
        IFigure circle = new Circle(4);
        IFigure clonedCircle = circle.Clone();
        clonedCircle.Info();

        IFigure rectangle = new Rectangle(3, 4);
        IFigure clonedRectangle = rectangle.Clone();
        clonedRectangle.Info();
    }
}

public interface IFigure
{
    IFigure Clone();
    void Info();
}

public class Rectangle : IFigure
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public IFigure Clone()
    {
        return new Rectangle(this.width, this.height);
    }

    public void Info()
    {
        Console.WriteLine($"Прямоугольник со сторонами {height} на {width}");
    }
}

public class Circle : IFigure
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public IFigure Clone()
    {
        return new Circle(this.radius);
    }

    public void Info()
    {
        Console.WriteLine($"Круг с радиусом - {radius}");
    }
}