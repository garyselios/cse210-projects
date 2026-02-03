using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== HOMEWORK ASSIGNMENTS DEMONSTRATION ===\n");

        // Test 1: Basic Assignment (base class)
        Console.WriteLine("Test 1 - Basic Assignment:");
        Console.WriteLine("--------------------------");
        Assignment basicAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(basicAssignment.GetSummary());
        Console.WriteLine();

        // Test 2: Math Assignment (derived class)
        Console.WriteLine("Test 2 - Math Assignment:");
        Console.WriteLine("-------------------------");
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions",
                                                          "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());      // Inherited from base class
        Console.WriteLine(mathAssignment.GetHomeworkList()); // Specific to MathAssignment
        Console.WriteLine();

        // Test 3: Writing Assignment (derived class)
        Console.WriteLine("Test 3 - Writing Assignment:");
        Console.WriteLine("----------------------------");
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters",
                                                                   "European History",
                                                                   "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());           // Inherited from base class
        Console.WriteLine(writingAssignment.GetWritingInformation()); // Specific to WritingAssignment

        Console.WriteLine("\n=== ALL TESTS COMPLETED SUCCESSFULLY ===");
    }
}