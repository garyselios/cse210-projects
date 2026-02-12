using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of shapes (POLYMORPHISM)
        List<Shape> shapes = new List<Shape>();

        // Add different shapes to the same list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));
        shapes.Add(new Square("Yellow", 2.5));
        shapes.Add(new Circle("Purple", 4.2));

        // Iterate through the list (POLYMORPHISM in action)
        foreach (Shape shape in shapes)
        {
            // The same line of code calls different methods
            // depending on the actual type of the object
            double area = shape.GetArea();
            string color = shape.GetColor();
            string shapeType = shape.GetType().Name;

            Console.WriteLine($"The {color} {shapeType} has an area of {area:F2}");
        }

        // Calculate total area (more polymorphism)
        double totalArea = 0;
        foreach (Shape shape in shapes)
        {
            totalArea += shape.GetArea(); // Different code runs each time!
        }

        Console.WriteLine($"\nTotal area of all shapes: {totalArea:F2}");
    }
}