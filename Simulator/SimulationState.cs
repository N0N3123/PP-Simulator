
namespace SimConsole
{
    public class SimulationState
    {
        public int MoveIndex { get; }
        public List<MappableState> MappableStates { get; }

        public SimulationState(int moveIndex, List<MappableState> mappableStates)
        {
            MoveIndex = moveIndex;
            MappableStates = mappableStates;
        }
    }
}