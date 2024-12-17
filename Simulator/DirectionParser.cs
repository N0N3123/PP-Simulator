namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        List<Direction> directions = new List<Direction>();
        input = input.ToLower();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].ToString() == "u")
            {
                directions.Add(Direction.Up);
            }
            else if (input[i].ToString() == "r")
            {
                directions.Add(Direction.Right);
            }
            else if (input[i].ToString() == "d")
            {
                directions.Add(Direction.Down);
            }
            else if (input[i].ToString() == "l")
            {
                directions.Add(Direction.Left);
            }
        }
        return directions;
    }
}
