using Simulator;
using Simulator.Maps;
using Xunit;
namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        var map = new SmallSquareMap(10);
        Assert.Equal(10, map.SizeX);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(5, 5, true)]
    [InlineData(-1, 0, false)]
    [InlineData(0, 10, false)]
    [InlineData(9, 9, true)]
    public void Exist_ShouldReturnCorrectValues(int x, int y, bool expected)
    {
        var map = new SmallSquareMap(10);
        Assert.Equal(expected, map.Exist(new Point(x, y)));
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    public void Next_ShouldReturnCorrectValues(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var nextPoint = map.Next(new Point(x, y), d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
    [Theory]
    [InlineData(9, 0, Direction.Up, 9, 0)]
    [InlineData(9, 0, Direction.Left, 8, 1)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(5, 5, Direction.Down, 4, 4)]

    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);
        var result = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}