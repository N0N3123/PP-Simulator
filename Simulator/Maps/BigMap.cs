
using System.ComponentModel;

namespace Simulator.Maps;

public class BigMap : Map
{
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Szerokość mapy musi wynosić maksymalnie 1000.");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Długość mapy musi wynosić maksymalnie 1000.");
    }

    protected override List<IMappable>?[,] Fields => throw new NotImplementedException();

    private Dictionary<Point, List<IMappable>> keyValuePairs = new Dictionary<Point, List<IMappable>>();

    public override Point Next(Point p, Direction d)
    {
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return p.NextDiagonal(d);
    }

    public override void Add(IMappable mappable, Point point)
    {
        if (!Exist(point))
            throw new ArgumentException($"Punkt {point} jest poza granicami mapy.");
        if (!keyValuePairs.ContainsKey(point))
        {
            keyValuePairs[point] = new List<IMappable>();
        }
        keyValuePairs[point].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point point)
    {
        if (keyValuePairs.ContainsKey(point))
        {
            keyValuePairs[point].Remove(mappable);
            if (keyValuePairs[point].Count == 0)
            {
                keyValuePairs.Remove(point);
            }
        }
    }
    public override List<IMappable> At(Point point)
    {
        if (keyValuePairs.ContainsKey(point))
        {
            return keyValuePairs[point];
        }
        return new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}