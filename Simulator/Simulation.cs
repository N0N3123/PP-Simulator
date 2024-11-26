using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures' moves.
    /// </summary>
    public string Moves { get; private set; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int _currentMoveIndex = 0;

    /// <summary>
    /// Creature which will be moving in the current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_currentMoveIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of the direction which will be used in the current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentMoveIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Validates input and initializes the simulation.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        ValidateInput(map, creatures, positions, moves);

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        InitializeCreatures();
    }

    /// <summary>
    /// Makes one move of the current creature in the current direction.
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
    private void ValidateInput(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("List of creatures cannot be empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures must match the number of starting positions.");
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
    /// Initializes creatures by setting their starting positions and adding them to the map.
    /// </summary>
    private void InitializeCreatures()
    {
        for (int i = 0; i < Creatures.Count; i++)
        {
            var creature = Creatures[i];
            var position = Positions[i];

            if (!Map.Exist(position))
            {
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");
            }

            creature.InitMapAndPosition(Map, position);
            Map.Add(creature, position);
        }
    }

    /// <summary>
    /// Processes the current move for the current creature.
    /// </summary>
    private void ProcessCurrentMove()
    {
        char currentMoveChar = Moves[_currentMoveIndex];
        var directions = DirectionParser.Parse(currentMoveChar.ToString());

        if (directions != null && directions.Count > 0)
        {
            var direction = directions[0];
            CurrentCreature.Go(direction);
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
