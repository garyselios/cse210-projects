

using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What lesson did I learn today?",
        "What am I grateful for today?",  
        "What challenged me today?",  
        "Who could I serve tomorrow?"  
    };
    
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    
    public string GetPromptByMood(string mood)
    {
        Dictionary<string, List<string>> moodPrompts = new Dictionary<string, List<string>>
        {
            {"happy", new List<string> {"What made today awesome?", "What are you excited about?"}},
            {"sad", new List<string> {"What support do you need?", "What small win happened today?"}},
            {"neutral", new List<string> {"What surprised you today?", "What are you looking forward to?"}}
        };
        
        if (moodPrompts.ContainsKey(mood.ToLower()))
        {
            Random random = new Random();
            int index = random.Next(moodPrompts[mood.ToLower()].Count);
            return moodPrompts[mood.ToLower()][index];
        }
        
        return GetRandomPrompt();
    }
}