using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Ask for numbers
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter numbers. Type 0 to finish.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0) numbers.Add(input);
        } while (input != 0);

        // 2. If there are no numbers, end it.
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        // 3. Calculate results
        int sum = 0, max = numbers[0];

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max) max = num;
        }

        double average = (double)sum / numbers.Count;

        // 4. Show results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}