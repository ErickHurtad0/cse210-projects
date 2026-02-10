using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private int _raceDistance = 10000;
    private string _title = "New Adventurer";

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();
            DisplayRaceInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); Pause(); break;
                case 3: SaveGoals(); Pause(); break;
                case 4: LoadGoals(); Pause(); break;
                case 5: RecordEvent(); Pause(); break;
            }
        }
    }

    private void DisplayRaceInfo()
    {
        Console.WriteLine("~~~ ETERNAL QUEST RACE ~~~");
        Console.WriteLine($"Title: {_title}");
        DisplayRaceBar();
        Console.WriteLine($"Score: {_score}");
    }

    private void DisplayRaceBar()
    {
        int barLength = 25;
        int filled = (int)((double)_score / _raceDistance * barLength);
        filled = Math.Min(filled, barLength);

        Console.Write("[");
        Console.Write(new string('█', filled));
        Console.Write(new string('-', barLength - filled));
        Console.WriteLine($"] {_score}/{_raceDistance}");
    }

    private void UpdateRaceStatus()
    {
        if (_score >= 10000)
            _title = "[~~~ Eternal Champion ~~~]";
        else if (_score >= 7500)
            _title = "{~~ Covenant Runner ~~}";
        else if (_score >= 5000)
            _title = "~ Faithful Seeker ~";
        else if (_score >= 2500)
            _title = "-- Hopeful Traveler --";
        else
            _title = "- New Adventurer -";
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
            _goals.Add(new SimpleGoal(name, description, points));
        else if (type == 2)
            _goals.Add(new EternalGoal(name, description, points));
        else if (type == 3)
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine();
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        int earned = _goals[choice - 1].RecordEvent();
        _score += earned;

        UpdateRaceStatus();

        Console.WriteLine($"\n You earned {earned} points!");
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        UpdateRaceStatus();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(name, desc, points, bool.Parse(parts[4])));
            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(name, desc, points));
            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(
                    name,
                    desc,
                    points,
                    int.Parse(parts[5]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6])
                ));
        }

        Console.WriteLine("Goals loaded!");
    }

    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
