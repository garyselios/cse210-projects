using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    private static int _lastSelectedActivity = 0;
    private static List<string> _activityLog = new List<string>();
    private static string _logFilePath = "mindfulness_log.txt";


    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");

        // Load previous activity log if exists
        LoadActivityLog();

        // Create activity instances
        List<Activity> activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectingActivity(),
            new ListingActivity()
        };

        bool running = true;

        while (running)
        {
            DisplayMenu(activities);

            Console.Write("Select an activity (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                    int index = int.Parse(choice) - 1;
                    _lastSelectedActivity = index;

                    // Run selected activity
                    activities[index].Run();

                    // Log the activity
                    LogActivity(activities[index].GetType().Name, activities[index].GetDuration());
                    break;

                case "4":
                    // Show statistics before exiting
                    ShowStatistics();
                    running = false;
                    Console.WriteLine("Thank you for practicing mindfulness. Have a peaceful day!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowSpinner(2);
                    break;
            }
        }
    }


    static void DisplayMenu(List<Activity> activities)
    {
        Console.Clear();
        Console.WriteLine("=== MINDFULNESS ACTIVITIES ===");
        Console.WriteLine();

        for (int i = 0; i < activities.Count; i++)
        {
            string activityName = activities[i].GetType().Name.Replace("Activity", "");

            if (i == _lastSelectedActivity)
            {
                Console.WriteLine($"> {i + 1}. {activityName} Activity [LAST SELECTED]");
            }
            else
            {
                Console.WriteLine($"  {i + 1}. {activityName} Activity");
            }
        }

        Console.WriteLine("  4. Exit Program");
        Console.WriteLine();

        // Show quick stats
        Console.WriteLine($"Total sessions this run: {_activityLog.Count}");
        Console.WriteLine(new string('-', 40));
    }

    static void ShowSpinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };
        int i = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");

            i = (i + 1) % animation.Length;
        }
    }

    static void LogActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{activityName},{duration}";
        _activityLog.Add(logEntry);

        // Append to file
        try
        {
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Note: Could not save to log file: {ex.Message}");
        }
    }

    static void LoadActivityLog()
    {
        if (File.Exists(_logFilePath))
        {
            try
            {
                _activityLog = new List<string>(File.ReadAllLines(_logFilePath));
            }
            catch
            {
                _activityLog = new List<string>();
            }
        }
    }

    static void ShowStatistics()
    {
        Console.Clear();
        Console.WriteLine("=== MINDFULNESS SESSION STATISTICS ===");
        Console.WriteLine();

        if (_activityLog.Count == 0)
        {
            Console.WriteLine("No sessions recorded yet.");
            return;
        }

        // Calculate totals
        int totalSessions = _activityLog.Count;
        int totalSeconds = 0;
        var activityCounts = new Dictionary<string, int>();
        var activityDurations = new Dictionary<string, int>();

        foreach (string logEntry in _activityLog)
        {
            string[] parts = logEntry.Split(',');
            if (parts.Length >= 3)
            {
                string activityName = parts[1];
                if (int.TryParse(parts[2], out int duration))
                {
                    totalSeconds += duration;

                    // Count activities
                    if (activityCounts.ContainsKey(activityName))
                    {
                        activityCounts[activityName]++;
                        activityDurations[activityName] += duration;
                    }
                    else
                    {
                        activityCounts[activityName] = 1;
                        activityDurations[activityName] = duration;
                    }
                }
            }
        }

        // Display statistics
        Console.WriteLine($"Total sessions: {totalSessions}");
        Console.WriteLine($"Total time: {totalSeconds} seconds ({totalSeconds / 60} minutes)");
        Console.WriteLine();
        Console.WriteLine("Breakdown by activity:");
        Console.WriteLine(new string('-', 40));

        foreach (var activity in activityCounts.Keys)
        {
            string cleanName = activity.Replace("Activity", "");
            int sessions = activityCounts[activity];
            int totalDuration = activityDurations[activity];
            double averageDuration = (double)totalDuration / sessions;

            Console.WriteLine($"{cleanName}:");
            Console.WriteLine($"  Sessions: {sessions}");
            Console.WriteLine($"  Total time: {totalDuration} seconds");
            Console.WriteLine($"  Average duration: {averageDuration:F1} seconds");
            Console.WriteLine();
        }

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}