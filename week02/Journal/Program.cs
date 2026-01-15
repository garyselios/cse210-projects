

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
                // Crear nueva entrada
                Entry newEntry = new Entry();

                // Obtener fecha actual
                DateTime currentTime = DateTime.Now;
                newEntry._date = currentTime.ToShortDateString();

                // Obtener estado de ánimo
                Console.Write("\nHow are you feeling? (happy/sad/neutral/other): ");
                string mood = Console.ReadLine();
                newEntry._mood = mood;

                // Obtener prompt según el estado de ánimo
                if (mood.ToLower() == "happy" || mood.ToLower() == "sad" || mood.ToLower() == "neutral")
                {
                    newEntry._promptText = promptGen.GetPromptByMood(mood);
                }
                else
                {
                    newEntry._promptText = promptGen.GetRandomPrompt();
                }

                // Obtener respuesta del usuario
                Console.WriteLine($"\nPrompt: {newEntry._promptText}");
                Console.Write("Your response: ");
                newEntry._entryText = Console.ReadLine();

                // Agregar entrada al diario
                journal.AddEntry(newEntry);
                Console.WriteLine($"\n✓ Entry saved! Total entries: {journal.GetEntryCount()}");
            }
            else if (choice == "2")
            {
                // Mostrar todas las entradas
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Guardar en archivo
                Console.Write("Enter filename to save (e.g., myjournal.txt): ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
            }
            else if (choice == "4")
            {
                // Cargar desde archivo
                Console.Write("Enter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
            }
            else if (choice == "5")
            {
                // Buscar entradas
                Console.Write("Enter keyword to search: ");
                string keyword = Console.ReadLine();
                journal.SearchEntries(keyword);
            }
            else if (choice == "6")
            {
                // Salir
                Console.WriteLine("\nGoodbye! Keep writing!");
            }
            else
            {
                Console.WriteLine("\n❌ Invalid choice. Please select 1-6.");
            }
        }
    }
}