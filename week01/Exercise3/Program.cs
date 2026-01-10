using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Generate random number (1-100)
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = 0;  // Initialize guess

        // 2. Loop while NOT guessing
        while (guess != magicNumber)
        {
            // 3. Request attempt
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // 4. Give clue
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}