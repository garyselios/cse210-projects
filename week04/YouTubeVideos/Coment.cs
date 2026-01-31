
using System;

public class Comment
{
    // Private attributes (member variables)
    private string _commenterName;
    private string _commentText;

    // Constructor
    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }

    // Method to get formatted comment information
    public string GetCommentInfo()
    {
        return $"{_commenterName}: \"{_commentText}\"";
    }

    // Getter for commenter name (optional, but good for encapsulation)
    public string GetCommenterName()
    {
        return _commenterName;
    }

    // Getter for comment text (optional, but good for encapsulation)
    public string GetCommentText()
    {
        return _commentText;
    }
}