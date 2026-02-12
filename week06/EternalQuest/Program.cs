using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
    static int goalsCompleted = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("=== Eternal Quest Program ===");
        Console.WriteLine("Welcome to your personal goal tracker!");
        Console.WriteLine("Every step forward counts on your journey.\n");

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine($"\nYou have {score} points.");
            if (goalsCompleted > 0)
            {
                Console.WriteLine($"Goals Completed: {goalsCompleted}");
            }

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine($"\n=== Session Summary ===");
                    Console.WriteLine($"Total Points: {score}");
                    Console.WriteLine($"Goals Completed: {goalsCompleted}");
                    Console.WriteLine($"Total Goals: {goals.Count}");
                    Console.WriteLine("\nKeep up the good work! See you next time.");
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1-6.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        // VALIDATION ADDED: Safe number input for points
        int points = 0;
        bool validPoints = false;
        while (!validPoints)
        {
            Console.Write("What is the amount of points? ");
            string pointsInput = Console.ReadLine();

            if (int.TryParse(pointsInput, out points) && points > 0)
            {
                validPoints = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number for points.");
            }
        }

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            // VALIDATION ADDED: Safe number input for target
            int target = 0;
            bool validTarget = false;
            while (!validTarget)
            {
                Console.Write("How many times for bonus? ");
                string targetInput = Console.ReadLine();

                if (int.TryParse(targetInput, out target) && target > 0)
                {
                    validTarget = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }

            // VALIDATION ADDED: Safe number input for bonus
            int bonus = 0;
            bool validBonus = false;
            while (!validBonus)
            {
                Console.Write("What is the bonus? ");
                string bonusInput = Console.ReadLine();

                if (int.TryParse(bonusInput, out bonus) && bonus >= 0)
                {
                    validBonus = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number (0 or higher).");
                }
            }

            goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type. Returning to menu.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create your first goal!");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available. Create a goal first!");
            return;
        }

        Console.WriteLine("\nSelect a goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        // VALIDATION ADDED: Safe number input for goal selection
        int index = -1;
        bool validSelection = false;

        while (!validSelection)
        {
            Console.Write("Which goal did you accomplish? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out index))
            {
                index--; // Convert to 0-based index
                if (index >= 0 && index < goals.Count)
                {
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine($"Please enter a number between 1 and {goals.Count}.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        bool wasComplete = goals[index].IsComplete();
        int points = goals[index].RecordEvent();
        score += points;

        Console.WriteLine($"\nCongratulations! You earned {points} points!");

        if (!wasComplete && goals[index].IsComplete())
        {
            goalsCompleted++;
            Console.WriteLine("Goal Completed!");
        }

        if (score >= 1000)
        {
            Console.WriteLine("Amazing! You reached 1000 points!");
        }
        else if (score >= 500)
        {
            Console.WriteLine("Great job! You passed 500 points!");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename (default: goals.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
            filename = "goals.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"Score:{score}");
                writer.WriteLine($"Completed:{goalsCompleted}");
                foreach (Goal goal in goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename (default: goals.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
            filename = "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} not found.");
            return;
        }

        try
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                if (parts[0] == "Score")
                {
                    score = int.Parse(parts[1]);
                }
                else if (parts[0] == "Completed")
                {
                    goalsCompleted = int.Parse(parts[1]);
                }
                else if (parts[0] == "SimpleGoal")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4]))
                    {
                        goal.RecordEvent();
                    }
                    goals.Add(goal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                               int.Parse(parts[5]), int.Parse(parts[6]));
                    goals.Add(goal);
                }
            }

            Console.WriteLine($"Loaded {goals.Count} goals.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }
    }
}