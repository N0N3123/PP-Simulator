using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps;

public class BigMap : Map
{
    private readonly List<IMappable>?[,] _fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too high");
        _fields = new List<IMappable>[sizeX, sizeY];
    }
}