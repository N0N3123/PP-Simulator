namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    private Rectangle boundaries;
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return boundaries.Contains(p);
    }


    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    // Add(Creature, Point)

    // Remove(Creature, Point)

    // Move()

    // At(Point) albo x, y
    public Map(int sizeX, int sizeY)
    {
        if (sizeX <= 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Szerokość mapy musi wynosić co najmniej 5.");
        if (sizeY <= 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Długość mapy musi wynosić co najmniej 5.");

        SizeX = sizeX;
        SizeY = sizeY;
        boundaries = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
}