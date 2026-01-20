

public class Fraction
{
    // Private attributes - ENCAPSULATION
    private int _top;       // Numerator
    private int _bottom;    // Denominator

    // === CONSTRUCTORS ===

    // Constructor 1: No parameters - creates 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: One parameter (top) - creates top/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: Two parameters - creates top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // === GETTERS (Accessors) ===

    // Get the numerator
    public int GetTop()
    {
        return _top;
    }

    // Get the denominator
    public int GetBottom()
    {
        return _bottom;
    }

    // === SETTERS (Mutators) ===

    // Set the numerator
    public void SetTop(int top)
    {
        _top = top;
    }

    // Set the denominator
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // === PUBLIC METHODS ===

    // Returns the fraction as a string "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value of the fraction
    public double GetDecimalValue()
    {
        // Convert to double for precise division
        return (double)_top / _bottom;
    }
}