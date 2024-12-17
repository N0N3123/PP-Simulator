namespace Simulator.Maps;
public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = new Point((p.Next(d).X + SizeX) % SizeX, (p.Next(d).Y + SizeY) % SizeY);
        return nextPoint;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = new Point((p.NextDiagonal(d).X + SizeX) % SizeX, (p.NextDiagonal(d).Y + SizeY) % SizeY);
        return nextPoint;
    }
}