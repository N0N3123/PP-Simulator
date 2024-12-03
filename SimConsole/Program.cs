using Simulator;
using Simulator.Maps;

namespace SimConsole;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 8), new Birds("Eagle", 14, true), new Birds("Ostrich", 2, false) };
        List<Point> points = new() { new(2, 2), new(3, 1), new(4, 4), new(2, 5), new(0, 0) };
        string moves = "druldxxuldruxxdruld";

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