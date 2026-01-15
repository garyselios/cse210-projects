

using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Ready to store entries
    private List<Entry> _entries = new List<Entry>();

    // Add a new entry
    public void AddEntry(Entry newEntry)
    {
        if (newEntry != null)
        {
            _entries.Add(newEntry);
        }
    }

    // Show all entries
    public void DisplayAll()
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine($"JOURNAL ENTRIES ({_entries.Count} total):");
        Console.WriteLine(new string('=', 50));

        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet. Start by writing a new entry!");
            Console.WriteLine(new string('=', 50) + "\n");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\nENTRY #{i + 1}:");
            Console.WriteLine(new string('-', 30));
            _entries[i].Display();
        }

        Console.WriteLine(new string('=', 50) + "\n");
    }

    // Get number of entries
    public int GetEntryCount()
    {
        return _entries.Count;
    }

    // Search entries by keyword
    public void SearchEntries(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("\nPlease enter a valid keyword to search.");
            return;
        }

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine($"SEARCH RESULTS for '{keyword}':");
        Console.WriteLine(new string('=', 50));

        List<Entry> foundEntries = new List<Entry>();
        string searchTerm = keyword.ToLower();

        foreach (Entry entry in _entries)
        {
            bool matches = (entry._entryText != null && entry._entryText.ToLower().Contains(searchTerm)) ||
                          (entry._promptText != null && entry._promptText.ToLower().Contains(searchTerm)) ||
                          (entry._mood != null && entry._mood.ToLower().Contains(searchTerm)) ||
                          (entry._date != null && entry._date.ToLower().Contains(searchTerm));

            if (matches)
            {
                foundEntries.Add(entry);
            }
        }

        if (foundEntries.Count == 0)
        {
            Console.WriteLine($"No entries found containing '{keyword}'");
        }
        else
        {
            Console.WriteLine($"Found {foundEntries.Count} matching entries:\n");

            foreach (Entry entry in foundEntries)
            {
                entry.Display();
                Console.WriteLine(new string('-', 30));
            }
        }

        Console.WriteLine(new string('=', 50) + "\n");
    }

    // Save to file
    public void SaveToFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("\n❌ Invalid filename.");
            return;
        }

        try
        {
            // Check if the file already exists
            if (File.Exists(file))
            {
                Console.Write($"\nFile '{file}' already exists. Overwrite? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    Console.WriteLine("Save cancelled.");
                    return;
                }
            }

            // Save all entries
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    // Replace line breaks to maintain formatting
                    string safeEntryText = entry._entryText?.Replace("\n", "\\n").Replace("\r", "\\r");
                    string safePromptText = entry._promptText?.Replace("\n", "\\n").Replace("\r", "\\r");

                    outputFile.WriteLine($"{entry._date}|{safePromptText}|{safeEntryText}|{entry._mood}");
                }
            }

            Console.WriteLine($"\n✅ Journal saved to '{file}' ({_entries.Count} entries)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error saving file: {ex.Message}");
        }
    }

    // Load from file
    public void LoadFromFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("\n❌ Invalid filename.");
            return;
        }

        try
        {
            // Check if the file exists
            if (!File.Exists(file))
            {
                Console.WriteLine($"\n❌ File '{file}' not found.");
                return;
            }

            // Ask if current entries should be retained
            if (_entries.Count > 0)
            {
                Console.Write($"\nYou have {_entries.Count} unsaved entries in memory. Loading will replace them. Continue? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    Console.WriteLine("Load cancelled.");
                    return;
                }
            }

            // Clear current entries
            _entries.Clear();

            // Read all lines of the file
            string[] lines = File.ReadAllLines(file);
            int loadedCount = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split('|');

                if (parts.Length >= 4)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts[0];

                    // Restore line breaks
                    loadedEntry._promptText = parts[1]?.Replace("\\n", "\n").Replace("\\r", "\r");
                    loadedEntry._entryText = parts[2]?.Replace("\\n", "\n").Replace("\\r", "\r");
                    loadedEntry._mood = parts[3];

                    _entries.Add(loadedEntry);
                    loadedCount++;
                }
            }

            Console.WriteLine($"\n✅ Loaded {loadedCount} entries from '{file}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error loading file: {ex.Message}");
        }
    }
}