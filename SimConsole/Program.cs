using Simulator;
using Simulator.Maps;

namespace SimConsole;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SmallSquareMap map = new(7);
        List<IMappable> creatures = new() { new Orc("DisStream"), new Elf("Legolas") };
        List<Point> points = new() { new(2, 1), new(1, 2) };
        string moves = "urrlududrlurd";


        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();

            Console.WriteLine("\nPress any key to make a move...");
            Console.ReadKey(true);
            Console.Write($"Mappable goes {simulation.CurrentMoveName}\n");


            simulation.Turn();

        }
        mapVisualizer.Draw();
        Console.WriteLine("\nSimulation finished!");
    }
}