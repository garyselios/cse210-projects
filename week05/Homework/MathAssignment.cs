public class MathAssignment : Assignment
{
    // Private member variables specific to MathAssignment
    private string _textbookSection;
    private string _problems;

    // Constructor - calls base constructor for common attributes
    public MathAssignment(string studentName, string topic,
                         string textbookSection, string problems)
        : base(studentName, topic)  // Call base class constructor
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method to get homework list with section and problems
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}