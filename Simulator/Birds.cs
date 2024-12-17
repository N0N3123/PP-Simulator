namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public Birds(string description, uint size, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }
    public override string Info => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";
    public override void Go(Direction direction)
    {
        if (Map != null)
        {
            Point nextPosition = CanFly ? Map.Next(Map.Next(Position, direction), direction) : Map.NextDiagonal(Position, direction);
            Map.Move(this, Position, nextPosition);
            Position = nextPosition;
        }
    }
    public override char Symbol => CanFly ? 'B' : 'b';
}
