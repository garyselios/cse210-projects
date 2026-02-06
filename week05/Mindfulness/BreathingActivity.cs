using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }


    public override void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        int duration = GetDuration();
        int cycles = duration / 10; // Each breath cycle takes 10 seconds (4 in, 6 out)
        if (cycles == 0) cycles = 1; // Ensure at least one cycle

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(4);

            Console.WriteLine();
            Console.Write("Now breathe out... ");
            ShowCountdown(4);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}