
using System;
using System.Collections.Generic;

public class Scripture
{
    // Private attributes
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Hide a specified number of random words
    public void HideRandomWords(int numberToHide)
    {
        // Count how many words are still visible
        int visibleCount = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                visibleCount++;
        }

        // If there are fewer visible words than requested to hide,
        // only hide the available visible words
        if (visibleCount < numberToHide)
            numberToHide = visibleCount;

        // Hide the specified number of words
        for (int i = 0; i < numberToHide; i++)
        {
            int index;

            // Keep trying random indices until we find a word that isn't hidden
            do
            {
                index = _random.Next(_words.Count);
            } while (_words[index].IsHidden());

            _words[index].Hide();
        }
    }

    // Get the complete display text (reference + scripture with hidden words)
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim(); // Remove trailing space
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }

    // Getter for word count (for statistics)
    public int GetWordCount()
    {
        return _words.Count;
    }

    // Getter for hidden word count (for statistics)
    public int GetHiddenWordCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
                count++;
        }
        return count;
    }
}