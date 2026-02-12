// Shape.cs
using System;

using System;

public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    // Virtual method that will be overridden
    public virtual double GetArea()
    {
        return 0; // Default value, will be overridden
    }
}