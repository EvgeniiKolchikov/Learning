using System.Text.Json.Nodes;
using Learning;

var rect = new Rectangle(32, 43);
var circle = new Circle(54);

Console.WriteLine(rect.GetPerimeter());
Console.WriteLine(rect.GetArea());

Console.WriteLine(circle.GetPerimeter());
Console.WriteLine(circle.GetArea());

PrintShape(rect);
PrintShape(circle);

void PrintShape(Shape shape)
{
    Console.WriteLine($"Perimeter : {shape.GetPerimeter()} \t Area: {shape.GetArea()}");
}


Console.Read();