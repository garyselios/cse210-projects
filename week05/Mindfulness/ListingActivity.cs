using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    // Counter for number of items listed
    private int _count;

    // List of listing prompts
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public ListingActivity()
        : base("Listing",
              "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Method to get random prompt
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Method to get list from user
    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();

        Console.WriteLine("Start listing items (press enter after each item, type 'done' when finished):");
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item.ToLower() == "done")
                break;

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        return items;
    }

    // Main method to run the listing activity
    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();

        // Show random prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine();

        Console.Write("You will begin in: ");
        ShowCountdown(5);

        Console.WriteLine();

        // Get items from user
        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
}