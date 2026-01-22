
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SCRIPTURE MEMORIZER ===");
        Console.WriteLine();

        // Create a library of scriptures
        List<Scripture> scriptureLibrary = CreateScriptureLibrary();

        // Let user choose a scripture or get random one
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Use default scripture (John 3:16)");
        Console.WriteLine("2. Choose from library");
        Console.WriteLine("3. Get random scripture");
        Console.Write("Enter choice (1-3): ");

        string choice = Console.ReadLine();
        Scripture selectedScripture = null;

        switch (choice)
        {
            case "1":
                selectedScripture = scriptureLibrary[0]; // John 3:16
                break;

            case "2":
                selectedScripture = ChooseFromLibrary(scriptureLibrary);
                break;

            case "3":
                Random random = new Random();
                selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
                Console.WriteLine($"Selected: {selectedScripture.GetDisplayText().Substring(0, 50)}...");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                break;

            default:
                Console.WriteLine("Invalid choice. Using default scripture.");
                selectedScripture = scriptureLibrary[0];
                break;
        }

        // Configure difficulty
        Console.Write("\nEnter number of words to hide each time (default 3): ");
        string difficultyInput = Console.ReadLine();
        int wordsPerRound = 3;

        if (!string.IsNullOrEmpty(difficultyInput) && int.TryParse(difficultyInput, out int parsedValue))
        {
            wordsPerRound = parsedValue;
        }

        // Run the memorizer
        RunMemorizer(selectedScripture, wordsPerRound);
    }

    static void RunMemorizer(Scripture scripture, int wordsPerRound)
    {
        string userInput = "";
        int round = 1;

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            // Clear console and display
            Console.Clear();
            Console.WriteLine($"=== ROUND {round} ===");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Display statistics with progress bar
            int hidden = scripture.GetHiddenWordCount();
            int total = scripture.GetWordCount();
            double percentage = (double)hidden / total * 100;

            Console.Write($"Progress: [");
            int barLength = 20;
            int filledBars = (int)(percentage / 100 * barLength);

            for (int i = 0; i < barLength; i++)
            {
                Console.Write(i < filledBars ? "█" : "░");
            }
            Console.WriteLine($"] {percentage:F1}% ({hidden}/{total} words hidden)");
            Console.WriteLine();

            // Instructions
            Console.WriteLine("Commands:");
            Console.WriteLine("- Press Enter: Hide more words");
            Console.WriteLine("- Type 'hint': Show next word to memorize");
            Console.WriteLine("- Type 'reveal': Show all words (resets progress)");
            Console.WriteLine("- Type 'quit': Exit program");
            Console.Write("\nEnter command: ");

            userInput = Console.ReadLine()?.ToLower() ?? "";

            // Process commands
            if (userInput == "hint")
            {
                ShowHint(scripture);
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                continue;
            }
            else if (userInput == "reveal")
            {
                Console.WriteLine("\nRevealing all words... Starting over.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                // To reveal all words, we'd need to add a RevealAllWords method to Scripture
                // For now, we'll just reset by creating a new scripture
                // This is where you could add the reveal functionality
                Console.WriteLine("(Reveal functionality would be implemented here)");
                Console.ReadLine();
                continue;
            }
            else if (userInput == "quit")
            {
                break;
            }

            // Hide words and advance to next round
            scripture.HideRandomWords(wordsPerRound);
            round++;
        }

        // Completion message
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine("🎉 CONGRATULATIONS! 🎉");
            Console.WriteLine("You've memorized the entire scripture!");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Total rounds: {round - 1}");
            Console.WriteLine($"Words hidden per round: {wordsPerRound}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    static void ShowHint(Scripture scripture)
    {
        // This would highlight or give a hint about the next word to memorize
        // For now, we'll just show a simple message
        Console.WriteLine("\n💡 HINT: Focus on the words that are still visible.");
        Console.WriteLine("Try to remember the complete verse before they're all hidden!");
    }

    static List<Scripture> CreateScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        // Add multiple scriptures to the library

        // 1. John 3:16
        Reference ref1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(ref1,
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life.");
        library.Add(scripture1);

        // 2. Proverbs 3:5-6
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(ref2,
            "Trust in the Lord with all your heart and lean not on your own understanding; " +
            "in all your ways submit to him, and he will make your paths straight.");
        library.Add(scripture2);

        // 3. Philippians 4:13
        Reference ref3 = new Reference("Philippians", 4, 13);
        Scripture scripture3 = new Scripture(ref3,
            "I can do all this through him who gives me strength.");
        library.Add(scripture3);

        // 4. Psalm 23:1
        Reference ref4 = new Reference("Psalm", 23, 1);
        Scripture scripture4 = new Scripture(ref4,
            "The Lord is my shepherd, I lack nothing.");
        library.Add(scripture4);

        // 5. Matthew 11:28
        Reference ref5 = new Reference("Matthew", 11, 28);
        Scripture scripture5 = new Scripture(ref5,
            "Come to me, all you who are weary and burdened, and I will give you rest.");
        library.Add(scripture5);

        return library;
    }

    static Scripture ChooseFromLibrary(List<Scripture> library)
    {
        Console.WriteLine("\n=== SCRIPTURE LIBRARY ===");

        for (int i = 0; i < library.Count; i++)
        {
            string displayText = library[i].GetDisplayText();
            string preview = displayText.Length > 60
                ? displayText.Substring(0, 60) + "..."
                : displayText;

            Console.WriteLine($"{i + 1}. {preview}");
        }

        Console.Write($"\nSelect scripture (1-{library.Count}): ");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= library.Count)
        {
            return library[choice - 1];
        }
        else
        {
            Console.WriteLine("Invalid choice. Using first scripture.");
            return library[0];
        }
    }
}