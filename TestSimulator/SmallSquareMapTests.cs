using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ShouldFailForMinimumBoundarySize()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(4));
    }

    [Theory]
    [InlineData(10, 10, true)]
    [InlineData(20, 20, true)]
    [InlineData(-1, -1, false)]
    [InlineData(0, 0, false)]
    public void Exist_ShouldCheckPointWithinMap(int x, int y, bool expected)
    {
        var map = new SmallSquareMap(20);
        Assert.Equal(expected, map.Exist(new Point(x, y)));
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(10, 10, Direction.Left, 9, 10)]
    [InlineData(19, 19, Direction.Down, 19, 19)]
    public void Next_ShouldHandleBoundaryCases(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var nextPoint = map.Next(new Point(x, y), d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 1)]
    [InlineData(19, 19, Direction.Up, 19, 0)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var nextPoint = map.NextDiagonal(new Point(x, y), d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}