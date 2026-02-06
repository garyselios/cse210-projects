using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    // Private member variables - following _underscoreCamelCase convention
    private string _name;
    private string _description;
    private int _duration; // in seconds

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name.ToUpper()} ===");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        // Get duration with input validation
        bool validInput = false;
        while (!validInput)
        {
            Console.Write("How many seconds would you like for this activity? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                _duration = seconds;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed {_duration} seconds of {_name}.");
        ShowSpinner(3);
    }

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
            Console.Write("\b \b"); // Erase the character using backspace

            i++;
            if (i >= animation.Count) i = 0;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the number using backspace
        }
    }

    public int GetDuration()
    {
        return _duration;
    }

    public virtual void Run()
    {
        // Base implementation - derived classes will override
        DisplayStartingMessage();
        DisplayEndingMessage();
    }
}