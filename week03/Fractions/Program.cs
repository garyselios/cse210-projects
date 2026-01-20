
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== FRACTION CLASS TEST ===");
        Console.WriteLine("Testing Encapsulation Principle");
        Console.WriteLine("===============================\n");

        // Test 1: Creating fractions using different constructors
        Console.WriteLine("TEST 1: Creating Fractions");
        Console.WriteLine("--------------------------");

        Fraction f1 = new Fraction();        // 1/1 using first constructor
        Console.WriteLine($"Fraction 1: {f1.GetFractionString()}");

        Fraction f2 = new Fraction(5);       // 5/1 using second constructor  
        Console.WriteLine($"Fraction 2: {f2.GetFractionString()}");

        Fraction f3 = new Fraction(3, 4);    // 3/4 using third constructor
        Console.WriteLine($"Fraction 3: {f3.GetFractionString()}");

        Fraction f4 = new Fraction(1, 3);    // 1/3 using third constructor
        Console.WriteLine($"Fraction 4: {f4.GetFractionString()}");

        Console.WriteLine();

        // Test 2: GetFractionString and GetDecimalValue methods
        Console.WriteLine("TEST 2: String and Decimal Representations");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine($"{f1.GetFractionString()} = {f1.GetDecimalValue()}");
        Console.WriteLine($"{f2.GetFractionString()} = {f2.GetDecimalValue()}");
        Console.WriteLine($"{f3.GetFractionString()} = {f3.GetDecimalValue()}");
        Console.WriteLine($"{f4.GetFractionString()} = {f4.GetDecimalValue()}");

        Console.WriteLine();

        // Test 3: Testing getters and setters
        Console.WriteLine("TEST 3: Testing Getters and Setters");
        Console.WriteLine("------------------------------------");

        // Get current values
        Console.WriteLine($"Fraction 1 - Original: {f1.GetFractionString()}");
        Console.WriteLine($"  Numerator: {f1.GetTop()}, Denominator: {f1.GetBottom()}");

        // Set new values
        f1.SetTop(7);
        f1.SetBottom(8);
        Console.WriteLine($"Fraction 1 - Modified: {f1.GetFractionString()}");
        Console.WriteLine($"  New Numerator: {f1.GetTop()}, New Denominator: {f1.GetBottom()}");

        Console.WriteLine();

        // Test 4: Additional examples
        Console.WriteLine("TEST 4: Additional Examples");
        Console.WriteLine("---------------------------");

        Fraction f5 = new Fraction();  // Default 1/1
        f5.SetTop(2);
        f5.SetBottom(5);
        Console.WriteLine($"Fraction 5: {f5.GetFractionString()} = {f5.GetDecimalValue()}");

        Fraction f6 = new Fraction(0, 7);  // 0/7
        Console.WriteLine($"Fraction 6: {f6.GetFractionString()} = {f6.GetDecimalValue()}");

        Console.WriteLine("\n=== ALL TESTS COMPLETED ===");
    }
}