

using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine($"\nJOURNAL ENTRIES ({_entries.Count} total):");

        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet. Start writing!\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public int GetEntryCount()
    {
        return _entries.Count;
    }

    public void SearchEntries(string keyword)
    {
        Console.WriteLine($"\nSearching for '{keyword}':");
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry._entryText.ToLower().Contains(keyword.ToLower()) ||
                entry._promptText.ToLower().Contains(keyword.ToLower()))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found with that keyword.");
        }
    }

    public void SaveToFile(string file)
    {
        if (File.Exists(file))
        {
            Console.Write($"File '{file}' already exists. Overwrite? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
            {
                Console.WriteLine("Save cancelled.");
                return;
            }
        }

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}");
            }
        }

        Console.WriteLine($"Journal saved to {file} ({_entries.Count} entries)");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry loadedEntry = new Entry();
            loadedEntry._date = parts[0];
            loadedEntry._promptText = parts[1];
            loadedEntry._entryText = parts[2];
            loadedEntry._mood = parts.Length > 3 ? parts[3] : "Not specified";

            _entries.Add(loadedEntry);
        }

        Console.WriteLine($"Loaded {_entries.Count} entries from {file}");
    }
}