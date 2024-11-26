using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallTorusMapTests
{
    [Fact]
    public void Constructor_ShouldThrowForExcessiveDimensions()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallTorusMap(21, 21));
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Left, 19, 0)]
    [InlineData(19, 19, Direction.Up, 19, 0)]
    public void Next_ShouldWrapAroundEdges(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallTorusMap(20, 20);
        var nextPoint = map.Next(new Point(x, y), d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 1)]
    [InlineData(19, 19, Direction.Left, 18, 18)]
    [InlineData(0, 19, Direction.Up, 1, 0)]
    public void NextDiagonal_ShouldWrapAroundEdgesCorrectly(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallTorusMap(20, 20);
        var nextPoint = map.NextDiagonal(new Point(x, y), d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}