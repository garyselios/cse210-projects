
using System;

class Program
{
    // 1. Welcome display function
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // 2. Function that requests and returns a name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // 3. Function that requests and returns a number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    // 4. Function that calculates square
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // 5. Function that shows result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }

    // MAIN FUNCTION (Main)
    static void Main()
    {
        // LCall functions in order:
        DisplayWelcome();                    // 1. Show welcome

        string userName = PromptUserName();  // 2. Ask for name
        int userNumber = PromptUserNumber(); // 3. Request number

        int squared = SquareNumber(userNumber); // 4. Calculate square

        DisplayResult(userName, squared);    // 5. Show result
    }
}