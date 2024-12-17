using Simulator.Maps;
namespace Simulator;

public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; set; }

    private string description = "Unknown";
    public string Description
    {
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    public Animals(string description, uint size)
    {
        Description = description;
        Size = size;
    }
    public uint Size { get; set; } = 3;
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

    public virtual void Go(Direction direction)
    {
        if (Map != null)
        {
            var nextPosition = Map.Next(Position, direction);
            Map.Move(this, Position, nextPosition);
            Position = nextPosition;
        }
    }
    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public virtual char Symbol => 'A';

}
