using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int _currentMoveIndex = 0;
    private int _currentCreatureIndex = 0;
    private List<Direction> _parsedMoves;

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
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_currentCreatureIndex];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => _parsedMoves[_currentMoveIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (creatures.Count != positions.Count)
            throw new ArgumentException("Number of creatures must match number of starting positions.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
        _parsedMoves = DirectionParser.Parse(moves);

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        var currentDirection = _parsedMoves[_currentMoveIndex];
        var currentCreature = CurrentCreature;
        var currentPosition = currentCreature.Position;
        var nextPosition = Map.Next(currentPosition, currentDirection);

        if (Map.Exist(nextPosition))
        {
            Map.Move(currentCreature, currentPosition, nextPosition);
            // Użycie metody Go do aktualizacji pozycji stworzenia
            currentCreature.Go(currentDirection);
        }

        _currentMoveIndex = (_currentMoveIndex + 1) % _parsedMoves.Count;
        _currentCreatureIndex = (_currentCreatureIndex + 1) % Creatures.Count;

        if (_currentMoveIndex == 0 && _currentCreatureIndex == 0)
        {
            Finished = true;
        }
    }
}