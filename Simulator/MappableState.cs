using Simulator;
using Simulator.Maps;
namespace SimConsole
{
    public class MappableState
    {
        public IMappable Mappable { get; }
        public Point Position { get; }

        public MappableState(IMappable mappable, Point position)
        {
            Mappable = mappable;
            Position = position;
        }
    }
}