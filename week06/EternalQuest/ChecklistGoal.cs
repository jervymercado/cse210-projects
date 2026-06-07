using System;

public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus,
        int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;

            if (_currentCount == _targetCount)
            {
                return _points + _bonus;
            }

            return _points;
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}