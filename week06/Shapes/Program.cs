using System;
using System.Collections.Generic;

List<Shape> shapes = new List<Shape>
{
    new Square("Red", 4),
    new Rectangle("Blue", 5, 6),
    new Circle("Green", 3)
};

foreach (Shape shape in shapes)
{
    Console.WriteLine($"Color: {shape.GetColor()}");
    Console.WriteLine($"Area: {shape.GetArea():F2}");
    Console.WriteLine();
}