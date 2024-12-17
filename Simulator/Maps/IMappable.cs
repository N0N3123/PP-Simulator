namespace Simulator.Maps;

public interface IMappable
{
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point position);
    public char Symbol { get; }
    public Point Position { get; }
    public string ToString();
}