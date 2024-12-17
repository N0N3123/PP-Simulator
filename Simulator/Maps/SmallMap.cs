using System.Collections.Generic;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public readonly List<IMappable>?[,] _fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too high");
        _fields = new List<IMappable>?[sizeX, sizeY];
    }
}