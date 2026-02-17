using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    // Abstract methods - each derived class must implement these
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method - can be overridden but not required
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} ({_minutes} min) - " +
               $"Distance: {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }
}