namespace Simulator.Maps;

public interface IMappable
{
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
}
