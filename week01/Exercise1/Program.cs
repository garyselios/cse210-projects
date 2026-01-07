
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Ask for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // 2. ask for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // 3. Show "last name, fist name last name"
        Console.WriteLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}

