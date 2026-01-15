

using System;

public class Entry
{
    // Public fields
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    // Empty constructor
    public Entry()
    {
        _date = "";
        _promptText = "";
        _entryText = "";
        _mood = "";
    }

    // Method for displaying the input
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine(); // Blank line for separation
    }
}