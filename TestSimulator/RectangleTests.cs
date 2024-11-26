using Simulator;
namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetProperties()
    {
        var rectangle = new Rectangle(1, 2, 3, 4);
        Assert.Equal(1, rectangle.X1);
        Assert.Equal(2, rectangle.Y1);
        Assert.Equal(3, rectangle.X2);
        Assert.Equal(4, rectangle.Y2);
    }

    [Theory]
    [InlineData(2, 3, true)]
    [InlineData(0, 0, false)]
    [InlineData(3, 4, true)]
    [InlineData(4, 4, false)]
    [InlineData(1, 2, true)] // New test case
    public void Contains_ShouldReturnCorrectValues(int x, int y, bool expected)
    {
        var rectangle = new Rectangle(1, 2, 3, 4);
        var point = new Point(x, y);
        Assert.Equal(expected, rectangle.Contains(point));
    }

    [Fact]
    public void Constructor_CollinearPoints_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 4));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var rectangle = new Rectangle(1, 2, 3, 4);
        Assert.Equal("(1, 2); (3, 4)", rectangle.ToString());
    }

    [Fact]
    public void Constructor_ValidPoints_ShouldSetProperties()
    {
        var p1 = new Point(1, 2);
        var p2 = new Point(3, 4);
        var rectangle = new Rectangle(p1, p2);
        Assert.Equal(1, rectangle.X1);
        Assert.Equal(2, rectangle.Y1);
        Assert.Equal(3, rectangle.X2);
        Assert.Equal(4, rectangle.Y2);
    }
}