using Simulator.Maps;
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
        Lab5b();
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
    static void Lab5b()
    {
        Console.WriteLine("TEST MAP\n");
        try
        {
            var badmap = new SmallSquareMap(4);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Wykryto błąd: {ex.Message}");
        }
        var map = new SmallSquareMap(10);
        var pointInside = new Point(5, 5);
        var pointOutside = new Point(15, 15);
        Console.WriteLine($"Mapa ma rozmiar: {map.Size}");
        Console.WriteLine($"Punkt {pointInside} jest na mapie: {map.Exist(pointInside)}"); // powinno być true
        Console.WriteLine($"Punkt {pointOutside} jest na mapie: {map.Exist(pointOutside)}"); // powinno być false
        var nextPoint = map.Next(pointInside, Direction.Right);
        Console.WriteLine($"Nastepny punkt od {pointInside} na prawo: {nextPoint}");
        var nextPoint2 = map.Next(nextPoint, Direction.Up);
        Console.WriteLine($"Nastepny punkt od {nextPoint} w górę: {nextPoint2}");
        var nextPoint3 = map.Next(nextPoint2, Direction.Left);
        Console.WriteLine($"Nastepny punkt od {nextPoint2} na lewo: {nextPoint3}");
        var nextPoint4 = map.Next(nextPoint3, Direction.Down);
        Console.WriteLine($"Nastepny punkt od {nextPoint3} w dół: {nextPoint4}");
        var nextDiagonalPoint = map.NextDiagonal(pointInside, Direction.Right);
        Console.WriteLine($"Nastepny punnkt na skos od {pointInside} na prawo: {nextDiagonalPoint}");
        var nextDiagonalPoint2 = map.NextDiagonal(nextDiagonalPoint, Direction.Up);
        Console.WriteLine($"Nastepny punnkt na skos od {nextDiagonalPoint} w górę: {nextDiagonalPoint2}");
        var nextDiagonalPoint3 = map.NextDiagonal(nextDiagonalPoint2, Direction.Left);
        Console.WriteLine($"Nastepny punnkt na skos od {nextDiagonalPoint2} na lewo: {nextDiagonalPoint3}");
        var nextDiagonalPoint4 = map.NextDiagonal(nextDiagonalPoint3, Direction.Down);
        Console.WriteLine($"Nastepny punnkt na skos od {nextDiagonalPoint3} w dół: {nextDiagonalPoint4}");
        var borderPoint = new Point(map.Size -1, map.Size-1);
        var nextPoint5 = map.Next(borderPoint, Direction.Right);
        Console.WriteLine($"Nastepny punkt od {borderPoint} na prawo: {nextPoint5}"); //powinno zwrócić ten sam punkt

    }
}




