using System;
using System.Collections.Generic;
using System.Threading;


public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _itemCount;


    public ListingActivity()
        : base("Listing Activity",
              "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        InitializePrompts();
        _itemCount = 0;
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }


    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.WriteLine("Start listing items (press Enter after each item):");
        Console.WriteLine("(Time will automatically end when duration is complete)");

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        _itemCount = items.Count;
        return items;
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {_itemCount} items!");

        DisplayEndingMessage();
    }
}