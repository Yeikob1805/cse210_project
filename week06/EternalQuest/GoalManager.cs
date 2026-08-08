using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.Clear();

            Console.WriteLine($"You have {_score} points");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = ReadNumber("What is the amount of points associated with this goal? ");

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                int target = ReadNumber("How many times does this goal need to be completed? ");
                int bonus = ReadNumber("What is the bonus for completing it? ");

                _goals.Add(new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus));

                break;

            default:
                Console.WriteLine("Invalid goal type.");
                Console.ReadKey();
                return;
        }

        Console.WriteLine("\nGoal created successfully!");
        Console.ReadKey();
    }

    private void ListGoals()
    {
        Console.Clear();

        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()} - {_goals[i].GetDescription()}");
            }
        }

        Console.ReadKey();
    }

    private void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int choice = ReadNumber("\nWhich goal did you accomplish? ") - 1;

        if (choice < 0 || choice >= _goals.Count)
        {
            Console.WriteLine("Invalid goal.");
            Console.ReadKey();
            return;
        }

        int pointsEarned = _goals[choice].RecordEvent();

        _score += pointsEarned;

        Console.WriteLine();
        Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
        Console.WriteLine($"You now have {_score} points.");

        CheckLevelUp();

        Console.ReadKey();
    }

    private void SaveGoals()
    {
        Console.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("\nGoals saved successfully.");
        Console.ReadKey();
    }

    private void LoadGoals()
    {
        Console.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("\nThe file could not be found.");
            Console.ReadKey();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length < 2)
        {
            Console.WriteLine("\nThe file does not contain valid goal data.");
            Console.ReadKey();
            return;
        }

        _goals.Clear();

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(new SimpleGoal(
                    name,
                    description,
                    points,
                    isComplete));
            }
            else if (parts[0] == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(
                    name,
                    description,
                    points));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus,
                    amountCompleted));
            }
        }

        Console.WriteLine("\nGoals loaded successfully.");
        Console.ReadKey();
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;

            Console.WriteLine();
            Console.WriteLine($"Congratulations! You reached Level {_level}!");
        }
    }

    private int ReadNumber(string message)
    {
        int number;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a valid number.");
        }
    }
}