using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public void Go(Direction direction)
    {
        throw new NotImplementedException();
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        throw new NotImplementedException();
    }

    public override string ToString() => Info;
}