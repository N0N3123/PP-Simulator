using Simulator.Maps;
using Simulator;
using SimConsole;

public class SimulationHistory
{
    private readonly List<SimulationState> _states = new();
    private readonly Simulation _simulation;

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation;
        SaveState();
    }

    public void Run()
    {
        while (!_simulation.Finished)
        {
            _simulation.Turn();
            SaveState();
        }
    }

    public void SaveState()
    {
        _states.Add(_simulation.GetState());
    }

    public SimulationState GetStateAtTurn(int turn)
    {
        if (turn < 0 || turn >= _states.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turn), "Invalid turn number.");
        }
        return _states[turn];
    }
}