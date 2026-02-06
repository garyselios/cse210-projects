using System;
using System.Collections.Generic;
using System.Threading;


public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base("Reflecting Activity",
              "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        InitializePrompts();
        InitializeQuestions();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }

    private void InitializeQuestions()
    {
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            InitializeQuestions(); // Refresh questions if all have been used
        }

        Random random = new Random();
        int index = random.Next(_questions.Count);
        string question = _questions[index];
        _questions.RemoveAt(index);

        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
    }

    private void DisplayQuestions()
    {
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);

            // Check if time is up
            if (DateTime.Now >= endTime) break;
        }
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        DisplayPrompt();
        DisplayQuestions();

        DisplayEndingMessage();
    }
}