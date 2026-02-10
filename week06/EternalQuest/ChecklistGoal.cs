public class ChecklistGoal : Goal
{
    private int _completed;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus,
        int completed = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
            return 0;

        _completed++;

        if (_completed == _target)
            return _points + _bonus;

        return _points;
    }

    public override bool IsComplete()
    {
        return _completed >= _target;
    }

    public override string GetDisplayString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description}) -- Completed {_completed}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_target}|{_completed}";
    }
}
