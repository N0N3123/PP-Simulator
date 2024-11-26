using Simulator;
namespace TestSimulator;

public class DirectionParserTests
{
    [Fact]
    public void Parse_ShouldParseMixedCaseDirectionsCorrectly()
    {
        // Arrange
        string input = "uRdL";
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Equal(new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left }, result);
    }

    [Fact]
    public void Parse_ShouldHandleInvalidAndValidCharacters()
    {
        // Arrange
        string input = "U!R@D#L$";
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Equal(new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left }, result);
    }

    [Fact]
    public void Parse_ShouldReturnEmptyForWhitespace()
    {
        // Arrange
        string input = "    ";
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("URDLXZZ", new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left })]
    [InlineData("xxxdr lYYLtYuZ", new[] { Direction.Down, Direction.Right, Direction.Left, Direction.Left, Direction.Up })]
    public void Parse_ShouldIgnoreUnknownCharacters(string input, Direction[] expected)
    {
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Equal(expected, result);
    }
}