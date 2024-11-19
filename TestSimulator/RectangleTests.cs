using Simulator;
namespace TestSimulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldThrowException_WhenPointsAreCollinear()
    {
        // Współliniowe punkty
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 5, 0));
    }

    [Fact]
    public void Constructor_ShouldCorrectlyNormalizeCoordinates()
    {
        // Normalizacja współrzędnych
        var rectangle = new Rectangle(5, 5, 0, 0);

        Assert.Equal(0, rectangle.X1);
        Assert.Equal(0, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(5, rectangle.Y2);

        // Przestawienie tylko X
        rectangle = new Rectangle(5, 0, 0, 5);

        Assert.Equal(0, rectangle.X1);
        Assert.Equal(0, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(5, rectangle.Y2);

        // Przestawienie tylko Y
        rectangle = new Rectangle(0, 5, 5, 0);

        Assert.Equal(0, rectangle.X1);
        Assert.Equal(0, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(5, rectangle.Y2);
    }

    [Fact]
    public void Constructor_ShouldWorkWithPoints()
    {
        // Konstruktor z punktami
        var point1 = new Point(1, 2);
        var point2 = new Point(3, 4);

        var rectangle = new Rectangle(point1, point2);

        Assert.Equal(1, rectangle.X1);
        Assert.Equal(2, rectangle.Y1);
        Assert.Equal(3, rectangle.X2);
        Assert.Equal(4, rectangle.Y2);
    }

    [Theory]
    [InlineData(2, 2, true)]   // Punkt wewnątrz prostokąta
    [InlineData(0, 0, true)]   // Dolny-lewy narożnik
    [InlineData(5, 5, true)]   // Górny-prawy narożnik
    [InlineData(0, 5, true)]   // Lewy górny narożnik
    [InlineData(5, 0, true)]   // Prawy dolny narożnik
    [InlineData(-1, 2, false)] // Poza lewą granicą
    [InlineData(6, 2, false)]  // Poza prawą granicą
    [InlineData(2, -1, false)] // Poza dolną granicą
    [InlineData(2, 6, false)]  // Poza górną granicą
    public void Contains_ShouldReturnCorrectValue(int x, int y, bool expected)
    {
        // Test metody contains
        var rectangle = new Rectangle(0, 0, 5, 5);
        var point = new Point(x, y);

        Assert.Equal(expected, rectangle.contains(point));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Test metody ToString
        var rectangle = new Rectangle(1, 1, 4, 4);

        Assert.Equal("(1, 1); (4, 4)", rectangle.ToString());
    }

    [Fact]
    public void Contains_ShouldWorkCorrectly_WithNegativeCoordinates()
    {
        // Prostokąt z ujemnymi współrzędnymi
        var rectangle = new Rectangle(-5, -5, 0, 0);

        // Punkt wewnątrz
        Assert.True(rectangle.contains(new Point(-3, -3)));

        // Punkt na krawędzi
        Assert.True(rectangle.contains(new Point(-5, -5)));

        // Punkt poza prostokątem
        Assert.False(rectangle.contains(new Point(-6, -6)));
        Assert.False(rectangle.contains(new Point(1, 1)));
    }

    [Fact]
    public void Constructor_ShouldHandleMixedCoordinates()
    {
        // Prostokąt z mieszanymi współrzędnymi
        var rectangle = new Rectangle(-2, 1, 3, -1);

        Assert.Equal(-2, rectangle.X1);
        Assert.Equal(-1, rectangle.Y1);
        Assert.Equal(3, rectangle.X2);
        Assert.Equal(1, rectangle.Y2);
    }

    [Fact]
    public void Contains_ShouldWorkCorrectly_WithMixedCoordinates()
    {
        // Prostokąt z mieszanymi współrzędnymi
        var rectangle = new Rectangle(-3, 0, 3, -3);

        // Punkt wewnątrz
        Assert.True(rectangle.contains(new Point(0, -1)));

        // Punkt na granicy
        Assert.True(rectangle.contains(new Point(-3, 0)));

        // Punkt poza prostokątem
        Assert.False(rectangle.contains(new Point(-4, 0)));
        Assert.False(rectangle.contains(new Point(4, 4)));
    }
}