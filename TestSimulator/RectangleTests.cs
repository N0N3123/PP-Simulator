using Simulator;
namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldThrowForNegativeDimensions()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(-1, -2, -3, -4));
    }

    [Theory]
    [InlineData(5, 5, true)]
    [InlineData(0, 0, false)]
    [InlineData(3, 3, true)]
    [InlineData(10, 10, false)]
    public void Contains_ShouldVerifyPointsInsideOrOutsideRectangle(int x, int y, bool expected)
    {
        var rectangle = new Rectangle(1, 1, 9, 9);
        var point = new Point(x, y);
        Assert.Equal(expected, rectangle.Contains(point));
    }

    [Fact]
    public void ToString_ShouldIncludeNegativeCoordinates()
    {
        var rectangle = new Rectangle(-5, -5, 5, 5);
        Assert.Equal("(-5, -5); (5, 5)", rectangle.ToString());
    }
}