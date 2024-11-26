using Simulator;
namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldInitializeNegativeCoordinates()
    {
        var point = new Point(-3, -4);
        Assert.Equal(-3, point.X);
        Assert.Equal(-4, point.Y);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    public void Next_ShouldWorkWithZeroCoordinates(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 2, 2)]
    [InlineData(-1, -1, Direction.Right, 0, -2)]
    [InlineData(2, -2, Direction.Down, 1, -3)]
    [InlineData(-2, 2, Direction.Left, -3, 3)]
    public void NextDiagonal_ShouldHandleNegativeCoordinates(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(d);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}