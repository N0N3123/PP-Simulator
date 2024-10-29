namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            value = value.Trim();
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            else if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
            }
            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            name = value;

        }
    }
    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            if (value < 0)
            {
                value = 1;
            }
            else if (value > 10)
            {
                value = 10;
            }
            level=value;
        }
    }
    public Creature() { }
    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public string Info => $"{Name} [{Level}]";
    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}!");
    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
            Console.WriteLine($"{Name} upgraded to level {Level}!");
        }
        else
        {
            Console.WriteLine($"{Name} is already at max level!");
        }

    }
    public void Go(Direction direction)
    { 
        string directionStr = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionStr}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }
    public void Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
}