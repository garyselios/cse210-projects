using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    // Protected member variables - accessible by derived classes
    protected string _name;
    protected string _description;
    protected int _duration; // in seconds

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Method to display starting message for all activities
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name.ToUpper()} ===");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        // Ask for duration
        Console.Write("How many seconds would you like for this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    // Method to display ending message for all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed {_duration} seconds of {_name}.");
        ShowSpinner(3);
    }

    // Method to show spinner animation
    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string> { "|", "/", "-", "\\" };
        int i = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            string frame = animation[i];
            Console.Write(frame);
            Thread.Sleep(200);
            Console.Write("\b \b"); // Erase the character

            i++;
            if (i >= animation.Count) i = 0;
        }
    }

    // Method to show countdown
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the number
        }
    }
}