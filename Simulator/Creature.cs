namespace Simulator;

using Simulator.Maps;
public abstract class Creature : IMappable
{

    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }

    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');

        }

    }
    public int Level
    {
        get { return level; }
        init
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }
    public abstract string Info { get; }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }
    public abstract string Greeting();
    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
    public void Go(Direction directions)
    {
        if (Map != null)
        {
            var nextPosition = Map.Next(Position, directions);
            Map.Move(this, Position, nextPosition);
            Position = nextPosition;
        }
    }
    public abstract int Power { get; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public abstract char Symbol { get; }
}
