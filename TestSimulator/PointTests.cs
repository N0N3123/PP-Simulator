using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        var point = new Point(5, 10);

        Assert.Equal(5, point.X);
        Assert.Equal(10, point.Y);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var point = new Point(3, 7);
        Assert.Equal("(3, 7)", point.ToString());
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    public void Next_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(startX, startY);
        var result = point.Next(direction);

        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]    // Skos: góra-prawo
    [InlineData(0, 0, Direction.Right, 1, -1)] // Skos: prawo-dół
    [InlineData(0, 0, Direction.Down, -1, -1)] // Skos: dół-lewo
    [InlineData(0, 0, Direction.Left, -1, 1)]  // Skos: lewo-góra
    public void NextDiagonal_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(startX, startY);
        var result = point.NextDiagonal(direction);

        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Fact]
    public void Next_ShouldNotChangePoint_ForInvalidDirection()
    {
        var point = new Point(5, 5);
        var result = point.Next((Direction)100); // Invalid direction

        Assert.Equal(point, result);
    }

    [Fact]
    public void NextDiagonal_ShouldNotChangePoint_ForInvalidDirection()
    {
        var point = new Point(5, 5);
        var result = point.NextDiagonal((Direction)100); // Invalid direction

        Assert.Equal(point, result);
    }

    [Theory]
    [InlineData(0, 0, 1, 1)]
    [InlineData(-5, -10, -4, -9)]
    [InlineData(1000, 1000, 1001, 1001)]
    public void Equality_ShouldComparePointsCorrectly(int x1, int y1, int x2, int y2)
    {
        var point1 = new Point(x1, y1);
        var point2 = new Point(x2, y2);

        if (x1 == x2 && y1 == y2)
        {
            Assert.Equal(point1, point2);
        }
        else
        {
            Assert.NotEqual(point1, point2);
        }
    }

    [Fact]
    public void Struct_ShouldBeImmutable()
    {
        var point = new Point(10, 20);

        // Próba zmiany współrzędnych - to powinno być niemożliwe,
        // ponieważ `Point` jest readonly struct.
        // Kompilacja wymusi brak możliwości zmiany.
        Assert.Equal(10, point.X);
        Assert.Equal(20, point.Y);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, "(0, 1)")]
    [InlineData(5, 5, Direction.Left, "(4, 5)")]
    public void Next_ShouldWorkWithStringRepresentation(int x, int y, Direction direction, string expected)
    {
        var point = new Point(x, y);
        var result = point.Next(direction);

        Assert.Equal(expected, result.ToString());
    }
}
