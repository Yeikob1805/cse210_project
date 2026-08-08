public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _target;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted >= _target)
            return 0;

        _amountCompleted++;

        if (_amountCompleted == _target)
            return GetPoints() + _bonus;

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStatus()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_amountCompleted}";
    }
}