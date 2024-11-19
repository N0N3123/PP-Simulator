namespace Simulator;
public abstract class Creature
{
    private string name;
    private int level;

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public Creature() : this("Unknown", 1) { }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public void Upgrade()
    {
        if (Level < 10)
        {
            level++;
        }
    }
    public abstract string Greeting();
    public abstract int Power { get; }
    public abstract string Info { get; }
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public string[] Go(Direction[] directions)
    {
        string[] results = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            results[i] = Go(directions[i]);
        }

        return results;

    }
    public string[] Go(string directionsString)
    {
        Direction[] directions = DirectionParser.Parse(directionsString);
        return Go(directions);
    }
}
