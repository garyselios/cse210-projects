public class Assignment
{
    // Protected member variables - accessible by derived classes
    protected string _studentName;
    protected string _topic;

    // Constructor - initializes student name and topic
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get summary of assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Public method to get student name (for derived classes)
    public string GetStudentName()
    {
        return _studentName;
    }
}