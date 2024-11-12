namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }
    private Rectangle boundaries;
    public SmallSquareMap(int size)
    {
        if (size < 5 || size >20)
        {
            throw new ArgumentOutOfRangeException("Rozmiar musi być między 5 a 20");
        }
        Size = size;
        boundaries = new Rectangle(0, 0, size - 1, size - 1);
    }
    public override bool Exist(Point p)
    {
        return boundaries.contains(p);
    }
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return Exist(nextPoint) ? nextPoint : p;
    }
}
