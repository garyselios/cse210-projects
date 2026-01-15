

using System;

public class Entry
{
    // Campos públicos
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    // Constructor vacío
    public Entry()
    {
        _date = "";
        _promptText = "";
        _entryText = "";
        _mood = "";
    }

    // Método para mostrar la entrada
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine(); // Línea en blanco para separación
    }
}