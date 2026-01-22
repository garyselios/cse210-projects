
public class Word
{
    // Private attributes
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Words start visible
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the display text (either the word or underscores)
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Create underscores equal to the length of the word
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}