using Simulator.Maps;

namespace Simulator;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        DrawTopBorder();
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            DrawRow(y);
            if (y > 0)
            {
                DrawMiddleBorder();
            }
        }
        DrawBottomBorder();
    }

    private void DrawTopBorder()
    {
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);
    }

    private void DrawRow(int y)
    {
        Console.Write(Box.Vertical);
        for (int x = 0; x < _map.SizeX; x++)
        {
            DrawCellContent(x, y);
            if (x < _map.SizeX - 1)
            {
                Console.Write(Box.Vertical);
            }
        }
        Console.WriteLine(Box.Vertical);
    }

    private void DrawCellContent(int x, int y)
    {
        var creatures = _map.At(new Point(x, y));
        if (creatures.Count > 1)
        {
            Console.Write('X');
        }
        else if (creatures.Count == 1)
        {
            var creature = creatures[0];
            Console.Write(creature is Elf ? 'E' : creature is Orc ? 'O' : '?');
        }
        else
        {
            Console.Write(' ');
        }
    }

    private void DrawMiddleBorder()
    {
        Console.Write(Box.MidLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.Cross);
        }
        Console.WriteLine(Box.MidRight);
    }

    private void DrawBottomBorder()
    {
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}