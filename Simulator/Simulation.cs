using Simulator.Maps;
namespace Simulator;
public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; private set; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int _currentMoveIndex = 0;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => IMappables[_currentMoveIndex % IMappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentMoveIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
        {
            throw new ArgumentException("List of mappables cannot be empty.");
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("Number of mappables must match the number of starting positions.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        for (int i = 0; i < mappables.Count; i++)
        {
            var mappable = mappables[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");
            }
            mappable.InitMapAndPosition(map, position);
            map.Add(mappable, position);

        }
    }
    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is already finished.");
        }

        if (Moves.Length == 0)
        {
            Finished = true;
            return;
        }

        char currentMoveChar = Moves[_currentMoveIndex];
        var directions = DirectionParser.Parse(currentMoveChar.ToString());

        if (directions != null && directions.Count > 0)
        {
            var direction = directions[0];
            CurrentMappable.Go(direction);
        }

        // Advance to the next mappable and move
        _currentMoveIndex++;

        // Check if all moves are done
        if (_currentMoveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}