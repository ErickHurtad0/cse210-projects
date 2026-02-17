using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();    

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name.Replace("Activity", "")} " +
               $"({_minutes} min): " +
               $"Distance {GetDistance():0.00} km, " +
               $"Speed {GetSpeed():0.00} kph, " +
               $"Pace {GetPace():0.00} min per km";
    }
}
