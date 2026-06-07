using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {_score / 1000 + 1}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == 3)
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus));
        }
    }

    public void ListGoals()
    {
        Console.WriteLine();

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("\nWhich goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        int points = _goals[choice - 1].RecordEvent();

        _score += points;

        Console.WriteLine($"You earned {points} points!");
    }

    public void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(file);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    bool.Parse(parts[4])));
            }
            else if (parts[0] == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6])));
            }
        }
    }
}