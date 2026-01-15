

using System;
using System.Collections.Generic;

public class PromptGenerator
{
    //List of general prompts
    private List<string> _prompts = new List<string>
    {
        "What was the most interesting thing that happened today?",
        "What are you grateful for today?",
        "What challenged you today and how did you overcome it?",
        "What did you learn today?",
        "Who made you smile today and why?",
        "What are you looking forward to tomorrow?",
        "What was a small victory you had today?",
        "How did you take care of yourself today?",
        "What would you do differently if you could relive today?",
        "What made you feel proud today?",
        "Describe a conversation that stuck with you today.",
        "What was the most beautiful thing you saw today?",
        "What made you laugh today?",
        "What is something new you tried or learned today?",
        "How did you help someone today, or how did someone help you?"
    };

    // Prompts organized by mood
    private Dictionary<string, List<string>> _moodPrompts = new Dictionary<string, List<string>>
    {
        {
            "happy", new List<string>
            {
                "What made you feel exceptionally happy today?",
                "Share a moment of pure joy from your day",
                "What are you celebrating or appreciating right now?",
                "What positive energy are you bringing into your life?",
                "Who or what brought sunshine to your day?"
            }
        },
        {
            "sad", new List<string>
            {
                "What's weighing on your heart today?",
                "How can you be kinder to yourself right now?",
                "What do you need to release or let go of?",
                "What comfort are you seeking today?",
                "What small thing could lift your spirits right now?"
            }
        },
        {
            "neutral", new List<string>
            {
                "Describe your day in detail from start to finish",
                "What was the most ordinary moment of your day?",
                "What routines or habits brought you comfort today?",
                "What did you notice about your surroundings today?",
                "How did you spend your quiet moments today?"
            }
        }
    };

    // Get a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Get prompts based on mood
    public string GetPromptByMood(string mood)
    {
        string moodLower = mood.ToLower();

        if (_moodPrompts.ContainsKey(moodLower))
        {
            List<string> prompts = _moodPrompts[moodLower];
            Random random = new Random();
            int index = random.Next(prompts.Count);
            return prompts[index];
        }

        // If the mood is not on the list, use a random prompt
        return GetRandomPrompt();
    }

    // Method to display all available prompts 
    public void ShowAllPrompts()
    {
        Console.WriteLine("\n=== AVAILABLE PROMPTS ===");
        Console.WriteLine("\nGeneral Prompts:");
        for (int i = 0; i < _prompts.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_prompts[i]}");
        }

        Console.WriteLine("\nMood-Based Prompts:");
        foreach (var mood in _moodPrompts.Keys)
        {
            Console.WriteLine($"\n  {mood.ToUpper()}:");
            for (int i = 0; i < _moodPrompts[mood].Count; i++)
            {
                Console.WriteLine($"    - {_moodPrompts[mood][i]}");
            }
        }
        Console.WriteLine(new string('=', 30));
    }
}