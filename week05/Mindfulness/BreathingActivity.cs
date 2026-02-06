using System;

public class BreathingActivity : Activity
{
    // Constructor - calls base constructor with specific name and description
    public BreathingActivity()
        : base("Breathing",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Main method to run the breathing activity
    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Begin...");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        // Alternate between "Breathe in" and "Breathe out"
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(4); // 4 seconds to breathe in

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(4); // 4 seconds to breathe out
        }

        DisplayEndingMessage();
    }
}