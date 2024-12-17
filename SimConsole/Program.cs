using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.OutputEncoding = Encoding.UTF8;
            BigBounceMap map = new(8, 6);
            List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 23), new Birds("Eagles", 8), new Birds("Ostriches", 15, false)];
            List<Point> points = [new(2, 2), new(3, 1), new(4, 3), new(1, 1), new(0, 4)];
            string moves = "dlruudlrrldurdlrrrrl";
            Console.Clear();

            /*
            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);
            var current_move = 1;
            mapVisualizer.Draw();
            while (simulation.Finished != true)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine();
                Console.WriteLine($"Turn: {current_move}");
                //Console.WriteLine($"{simulation.CurrentCreature.Info} {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}\n");
                simulation.Turn();
                mapVisualizer.Draw();
                current_move++;
            }
            */
            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);
            SimulationHistory history = new(simulation);
            LogVisualizer logVisualizer = new(history);
            Console.WriteLine("Turn 1: ");
            logVisualizer.Draw(0);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine("Turn 5: ");
            logVisualizer.Draw(4);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine("Turn 10: ");
            logVisualizer.Draw(9);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine("Turn 15: ");
            logVisualizer.Draw(14);
            Console.WriteLine("Press any key to continue...");
        }
    }
}
