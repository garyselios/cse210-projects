using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Exercise Tracking Program ===\n");

        // Create a list of activities (POLYMORPHISM)
        List<Activity> activities = new List<Activity>();

        // Create activities of each type
        // Using kilometers as the unit of measurement

        // Running: 5 km in 30 minutes
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 5.0));

        // Cycling: speed of 20 kph for 45 minutes
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 20.0));

        // Swimming: 20 laps in the pool (20 * 50m = 1000m = 1km) for 60 minutes
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 60, 20));

        // Additional activities to show variety
        activities.Add(new Running(new DateTime(2022, 11, 4), 25, 3.2));
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 30, 18.5));
        activities.Add(new Swimming(new DateTime(2022, 11, 4), 45, 15));

        // Iterate through the list and display the summary for each activity
        // POLYMORPHISM in action - each activity calls its own implementation
        Console.WriteLine("Activities Summary:");
        Console.WriteLine("===================");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}