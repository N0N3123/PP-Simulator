using static Simulator.Creature;

namespace Simulator;

internal class Program
 {
    static void Main(string[] args)
     {
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
        Lab5a();
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab5a()
    {
        Console.WriteLine("TEST PROSTOKĄTÓW\n");

        try
        {
            var rect1 = new Rectangle(4, 3, 7, 7);
            Console.WriteLine($"Prostokąt ze współrzędnymi: ({rect1.X1}, {rect1.Y1}), ({rect1.X2}, {rect1.Y2})");

            var rect2 = new Rectangle(6, 9, 2, 1);
            Console.WriteLine($"Prostokąt ze współrzędnymi: ({rect2.X1}, {rect2.Y1}), ({rect2.X2}, {rect2.Y2})");

            var rect3 = new Rectangle(new Point(2, 2), new Point(8, 8));
            Console.WriteLine($"Prostokąt ze współrzędnymi: ({rect3.X1}, {rect3.Y1}), ({rect3.X2}, {rect3.Y2})");

            var rect4 = new Rectangle(new Point(6, 1), new Point(4, 5));
            Console.WriteLine($"Prostokąt ze współrzędnymi: ({rect4.X1}, {rect4.Y1}), ({rect4.X2}, {rect4.Y2})");

            var rect5 = new Rectangle(5, 5, 5, 10); // powinien byc wyjątek
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Wykryto błąd: {ex.Message}");
        }
        try
        {
            var rect6 = new Rectangle(new Point(8, 9), new Point(8, 2)); // powinien byc wyjątek
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Wykryto błąd: {ex.Message}");
        }
        var rect = new Rectangle(0, 0, 10, 10);
        var pointInside = new Point(5, 5);
        var pointOutside = new Point(15, 15);

        Console.WriteLine($"Punkt {pointInside} w prostokącie: {rect.contains(pointInside)}");
        Console.WriteLine($"Punkt {pointOutside} w prostokącie: {rect.contains(pointOutside)}");
    }
}



