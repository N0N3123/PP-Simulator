using SimConsole;

namespace Simulator.Maps;

public class TempMap : Map
{
    private readonly List<IMappable>?[,] _fields;

    public TempMap(int sizeX, int sizeY, List<MappableState> mappableStates) : base(sizeX, sizeY)
    {
        _fields = new List<IMappable>?[sizeX, sizeY];
        foreach (var state in mappableStates)
        {
            var position = state.Position;
            _fields[position.X, position.Y] ??= new List<IMappable>();
            _fields[position.X, position.Y]?.Add(state.Mappable);
        }
    }

    protected override List<IMappable>?[,] Fields => _fields;

    public override Point Next(Point p, Direction d) => throw new NotImplementedException();
    public override Point NextDiagonal(Point p, Direction d) => throw new NotImplementedException();
}