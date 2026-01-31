
using System;
using System.Collections.Generic;

public class Video
{
    // Private attributes (member variables)
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get video information
    public string GetVideoInfo()
    {
        return $"\"{_title}\" by {_author} ({_length} seconds)";
    }

    // Method to display all comments
    public void DisplayAllComments()
    {
        if (_comments.Count == 0)
        {
            Console.WriteLine("  No comments yet.");
            return;
        }

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  - {comment.GetCommentInfo()}");
        }
    }

    // Getter for title (optional)
    public string GetTitle()
    {
        return _title;
    }

    // Getter for author (optional)
    public string GetAuthor()
    {
        return _author;
    }

    // Getter for length (optional)
    public int GetLength()
    {
        return _length;
    }
}