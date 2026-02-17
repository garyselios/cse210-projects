using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_KM = 50.0 / 1000; // 50 meters = 0.05 km

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (km) = swimming laps * 50 / 1000
        return _laps * LAP_LENGTH_KM;
    }

    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace = minutes / distance
        return GetMinutes() / GetDistance();
    }
}