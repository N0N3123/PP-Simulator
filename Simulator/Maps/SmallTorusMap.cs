namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }
    private Rectangle boundaries;
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Rozmiar musi być między 5 a 20");
        }
        Size = size;
        boundaries = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p)
    {
        return boundaries.contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return d switch
        {
            Direction.Up => Exist(nextPoint) ? nextPoint : new Point(p.X, 0),
            Direction.Right => Exist(nextPoint) ? nextPoint : new Point(0, p.Y),
            Direction.Down => Exist(nextPoint) ? nextPoint : new Point(p.X, Size - 1),
            Direction.Left => Exist(nextPoint) ? nextPoint : new Point(Size - 1, p.Y),
            _ => default,
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return d switch
        {
            Direction.Up => Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % Size, (p.Y + 1) % Size),
            Direction.Right => Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size),
            Direction.Down => Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size),
            Direction.Left => Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size),
            _ => default,
        };
    }
}