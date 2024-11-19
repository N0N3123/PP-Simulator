using Simulator;
using Simulator.Maps;
namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ShouldThrowException_ForInvalidSize()
    {
        // Rozmiar poniżej minimalnego
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(4));

        // Rozmiar powyżej maksymalnego
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(21));
    }

    [Fact]
    public void Constructor_ShouldInitializeMap_ForValidSize()
    {
        var map = new SmallSquareMap(10);

        Assert.Equal(10, map.Size);
    }

    [Theory]
    [InlineData(0, 0, true)]   // Dolny-lewy narożnik
    [InlineData(9, 9, true)]   // Górny-prawy narożnik (dla Size = 10)
    [InlineData(-1, 0, false)] // Punkt poza lewą granicą
    [InlineData(0, -1, false)] // Punkt poniżej dolnej granicy
    [InlineData(10, 0, false)] // Punkt poza prawą granicą
    [InlineData(0, 10, false)] // Punkt powyżej górnej granicy
    public void Exist_ShouldReturnCorrectValue(int x, int y, bool expected)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        Assert.Equal(expected, map.Exist(point));
    }

    [Fact]
    public void Next_ShouldMoveCorrectly_WithinBounds()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(5, 5);

        // Ruch w górę
        Assert.Equal(new Point(5, 6), map.Next(point, Direction.Up));

        // Ruch w dół
        Assert.Equal(new Point(5, 4), map.Next(point, Direction.Down));

        // Ruch w prawo
        Assert.Equal(new Point(6, 5), map.Next(point, Direction.Right));

        // Ruch w lewo
        Assert.Equal(new Point(4, 5), map.Next(point, Direction.Left));
    }

    [Fact]
    public void Next_ShouldNotMoveOutsideBounds()
    {
        var map = new SmallSquareMap(10);

        // Górna granica
        var point = new Point(5, 9);
        Assert.Equal(point, map.Next(point, Direction.Up));

        // Dolna granica
        point = new Point(5, 0);
        Assert.Equal(point, map.Next(point, Direction.Down));

        // Prawa granica
        point = new Point(9, 5);
        Assert.Equal(point, map.Next(point, Direction.Right));

        // Lewa granica
        point = new Point(0, 5);
        Assert.Equal(point, map.Next(point, Direction.Left));
    }

    [Fact]
    public void NextDiagonal_ShouldMoveCorrectly_WithinBounds()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(5, 5);

        // Ruch po skosie w górę i w prawo
        Assert.Equal(new Point(6, 6), map.NextDiagonal(point, Direction.Up));

        // Ruch po skosie w dół i w prawo
        Assert.Equal(new Point(6, 4), map.NextDiagonal(point, Direction.Right));

        // Ruch po skosie w dół i w lewo
        Assert.Equal(new Point(4, 4), map.NextDiagonal(point, Direction.Down));

        // Ruch po skosie w górę i w lewo
        Assert.Equal(new Point(4, 6), map.NextDiagonal(point, Direction.Left));
    }

    [Fact]
    public void NextDiagonal_ShouldNotMoveOutsideBounds()
    {
        var map = new SmallSquareMap(10);

        // Górna granica
        var point = new Point(9, 9);
        Assert.Equal(point, map.NextDiagonal(point, Direction.Up));

        // Dolna granica
        point = new Point(0, 0);
        Assert.Equal(point, map.NextDiagonal(point, Direction.Down));

        // Prawa granica
        point = new Point(9, 0);
        Assert.Equal(point, map.NextDiagonal(point, Direction.Right));

        // Lewa granica
        point = new Point(0, 9);
        Assert.Equal(point, map.NextDiagonal(point, Direction.Left));
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, true)]     // Ruch w granicach mapy
    [InlineData(5, 9, Direction.Up, false)]    // Próba wyjścia poza górną granicę
    [InlineData(0, 5, Direction.Left, false)] // Próba wyjścia poza lewą granicę
    public void Next_ShouldValidateBoundaryConditions(int x, int y, Direction direction, bool expectChange)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);

        if (expectChange)
        {
            Assert.NotEqual(point, nextPoint);
        }
        else
        {
            Assert.Equal(point, nextPoint);
        }
    }

    [Fact]
    public void EdgeCase_TestMapOfSize5()
    {
        // Minimalny rozmiar mapy
        var map = new SmallSquareMap(5);

        Assert.True(map.Exist(new Point(0, 0))); // Dolny-lewy narożnik
        Assert.True(map.Exist(new Point(4, 4))); // Górny-prawy narożnik
        Assert.False(map.Exist(new Point(5, 5))); // Poza granicami
    }

    [Fact]
    public void EdgeCase_TestMapOfSize20()
    {
        // Maksymalny rozmiar mapy
        var map = new SmallSquareMap(20);

        Assert.True(map.Exist(new Point(0, 0))); // Dolny-lewy narożnik
        Assert.True(map.Exist(new Point(19, 19))); // Górny-prawy narożnik
        Assert.False(map.Exist(new Point(20, 20))); // Poza granicami
    }
}