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
    /// Cyclic list of mappables' moves.
    /// </summary>
    public string Moves { get; private set; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int _currentMoveIndex = 0;

    /// <summary>
    /// IMappable which will be moving in the current turn.
    /// </summary>
    public IMappable CurrentIMappable => IMappables[_currentMoveIndex % IMappables.Count];

    /// <summary>
    /// Lowercase name of the direction which will be used in the current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentMoveIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Validates input and initializes the simulation.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        ValidateInput(map, mappables, positions, moves);

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        InitializeIMappables();
    }

    /// <summary>
    /// Makes one move of the current mappable in the current direction.
    /// Throws an error if the simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is already finished.");
        }

        if (Moves.Length == 0)
        {
            FinishSimulation();
            return;
        }

        ProcessCurrentMove();
        AdvanceToNextMove();

        if (_currentMoveIndex >= Moves.Length)
        {
            FinishSimulation();
        }
    }

    /// <summary>
    /// Validates the input parameters for the simulation.
    /// </summary>
    private void ValidateInput(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
        {
            throw new ArgumentException("List of mappables cannot be empty.");
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("Number of mappables must match the number of starting positions.");
        }

        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        if (string.IsNullOrWhiteSpace(moves))
        {
            throw new ArgumentNullException(nameof(moves));
        }
    }

    /// <summary>
    /// Initializes mappables by setting their starting positions and adding them to the map.
    /// </summary>
    private void InitializeIMappables()
    {
        for (int i = 0; i < IMappables.Count; i++)
        {
            var mappable = IMappables[i];
            var position = Positions[i];

            if (!Map.Exist(position))
            {
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");
            }

            mappable.InitMapAndPosition(Map, position);
            Map.Add(mappable, position);
        }
    }

    /// <summary>
    /// Processes the current move for the current mappable.
    /// </summary>
    private void ProcessCurrentMove()
    {
        char currentMoveChar = Moves[_currentMoveIndex];
        var directions = DirectionParser.Parse(currentMoveChar.ToString());

        if (directions != null && directions.Count > 0)
        {
            var direction = directions[0];
            CurrentIMappable.Go(direction);
        }
    }

    /// <summary>
    /// Advances to the next move and updates the current move index.
    /// </summary>
    private void AdvanceToNextMove()
    {
        _currentMoveIndex++;
    }

    /// <summary>
    /// Marks the simulation as finished.
    /// </summary>
    private void FinishSimulation()
    {
        Finished = true;
    }
}
