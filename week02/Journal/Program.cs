

using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        string choice = "";

        Console.WriteLine("=== PERSONAL JOURNAL ===");

        while (choice != "6")
        {
            Console.WriteLine("\n------------------------");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry newEntry = new Entry();

                DateTime currentTime = DateTime.Now;
                newEntry._date = currentTime.ToShortDateString();


                Console.Write("\nHow are you feeling? (happy/sad/neutral/other): ");
                string mood = Console.ReadLine();
                newEntry._mood = mood;


                if (mood.ToLower() == "happy" || mood.ToLower() == "sad" || mood.ToLower() == "neutral")
                {
                    newEntry._promptText = promptGen.GetPromptByMood(mood);
                }
                else
                {
                    newEntry._promptText = promptGen.GetRandomPrompt();
                }

                Console.WriteLine($"\nPrompt: {newEntry._promptText}");
                Console.Write("Your response: ");
                newEntry._entryText = Console.ReadLine();

                journal.AddEntry(newEntry);
                Console.WriteLine($"Entry saved! Total entries: {journal.GetEntryCount()}");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
            }
            else if (choice == "5")
            {
                Console.Write("Enter keyword to search: ");
                string keyword = Console.ReadLine();
                journal.SearchEntries(keyword);
            }
            else if (choice == "6")
            {
                Console.WriteLine("\nGoodbye! Keep journal!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1-6.");
            }
        }
    }
}

