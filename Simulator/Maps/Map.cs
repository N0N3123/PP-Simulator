namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>

    private readonly Rectangle _map;
    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too small");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too small");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point Next(Point p, Direction d)
    {
        return p.Next(d);
    }

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point NextDiagonal(Point p, Direction d)
    {
        return p.NextDiagonal(d);
    }

    private Dictionary<Point, List<IMappable>> keyValuePairs = new Dictionary<Point, List<IMappable>>();
    public virtual void Add(IMappable m, Point p)
    {
        if (!Exist(p))
            throw new ArgumentException($"Punkt {p} jest poza granicami mapy.");
        if (!keyValuePairs.ContainsKey(p))
        {
            keyValuePairs[p] = new List<IMappable>();
        }
        keyValuePairs[p].Add(m);
    }
    public virtual void Remove(IMappable m, Point p)
    {
        if (keyValuePairs.ContainsKey(p))
        {
            keyValuePairs[p].Remove(m);
            if (keyValuePairs[p].Count == 0)
            {
                keyValuePairs.Remove(p);
            }
        }
    }
    public virtual void Move(IMappable m, Point point1, Point point2)
    {
        Remove(m, point1);
        Add(m, point2);
    }
    public virtual List<IMappable> At(Point p)
    {
        if (keyValuePairs.ContainsKey(p))
        {
            return keyValuePairs[p];
        }
        return new List<IMappable>();
    }
    public virtual List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}