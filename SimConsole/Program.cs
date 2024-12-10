using Simulator;
using Simulator.Maps;

namespace SimConsole;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        BigBounceMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 8), new Birds("Eagle", 14, true), new Birds("Ostrich", 2, false) };
        List<Point> points = new() { new(0, 2), new(7, 5), new(4, 3), new(6, 1), new(3, 5) };
        string moves = "duluxxldldxxaz12213uldlduldl";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();

            Console.WriteLine("\nPress any key to make a move...");
            Console.ReadKey(true);
            //Console.Write($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}\n");
            simulation.Turn();
            Console.Clear();
        }
        mapVisualizer.Draw();
        Console.WriteLine("\nSimulation finished!");
    }
}