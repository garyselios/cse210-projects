
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== YOUTUBE VIDEOS MANAGER ===");
        Console.WriteLine("===============================\n");

        // Step 1: Create a list to store videos
        List<Video> videos = new List<Video>();

        // Step 2: Create 3-4 Video objects (using 3 as in your design)
        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 1200);
        Video video2 = new Video("Object-Oriented Programming Explained", "TechGuru", 900);
        Video video3 = new Video("Building Games with C#", "GameDev Pro", 2400);

        // Step 3: Create 3-4 Comment objects for each video
        // Video 1 Comments
        video1.AddComment(new Comment("Gary", "Great tutorial for beginners!"));
        video1.AddComment(new Comment("Alice Clarkson", "Very clear explanations, thank you!"));
        video1.AddComment(new Comment("Bob Marley", "Helped me understand classes better."));
        video1.AddComment(new Comment("Charlie Smith", "Perfect timing, I needed this!"));

        // Video 2 Comments
        video2.AddComment(new Comment("Sarah Clark", "Best OOP explanation I've seen!"));
        video2.AddComment(new Comment("Mike Tayson", "Could you make a video about inheritance?"));
        video2.AddComment(new Comment("Emily Dawson", "Very helpful for my exam preparation."));

        // Video 3 Comments
        video3.AddComment(new Comment("Chris Evans", "Amazing game development guide!"));
        video3.AddComment(new Comment("Jessica Parker", "My game works perfectly now!"));
        video3.AddComment(new Comment("Kevin Miller", "Looking forward to part 2."));
        video3.AddComment(new Comment("Lisa Anderson", "Great examples and clear code."));

        // Step 4: Store all videos in the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Step 5: Iterate through the list and display information
        Console.WriteLine($"Total Videos in Library: {videos.Count}\n");
        Console.WriteLine(new string('=', 60));

        int videoNumber = 1;

        foreach (Video video in videos)
        {
            Console.WriteLine($"\nVIDEO #{videoNumber}");
            Console.WriteLine(new string('-', 40));

            // Display video information
            Console.WriteLine($"Title and Author: {video.GetVideoInfo()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            // Display all comments
            Console.WriteLine("\nComments:");
            video.DisplayAllComments();

            Console.WriteLine(new string('=', 60));
            videoNumber++;
        }

        // Display summary
        Console.WriteLine("\n=== SUMMARY ===");
        int totalComments = 0;

        foreach (Video video in videos)
        {
            totalComments += video.GetNumberOfComments();
        }

        Console.WriteLine($"Total videos: {videos.Count}");
        Console.WriteLine($"Total comments across all videos: {totalComments}");
        Console.WriteLine($"Average comments per video: {totalComments / (double)videos.Count:F1}");

        Console.WriteLine("\nProgram completed. Press any key to exit...");
        Console.ReadKey();
    }
}