public class WritingAssignment : Assignment
{
    // Private member variable specific to WritingAssignment
    private string _title;

    // Constructor - calls base constructor for common attributes
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)  // Call base class constructor
    {
        _title = title;
    }

    // Method to get writing information with title and student name
    public string GetWritingInformation()
    {
        // Use GetStudentName() from base class to access student name
        return $"{_title} by {GetStudentName()}";
    }
}