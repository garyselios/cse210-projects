
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        // 2. Determine letter grade
        string letter = "";

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // 3. Display the letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        // 4. Check if passed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}