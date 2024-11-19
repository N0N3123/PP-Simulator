using Simulator;
namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]  // wartość w zakresie
    [InlineData(0, 1, 10, 1)]  // poniżej zakresu
    [InlineData(15, 1, 10, 10)] // powyżej zakresu
    public void Limiter_ShouldLimitValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Test", 5, 10, '.', "Test.")]
    [InlineData("TooLongString", 5, 10, '.', "TooLongStr")]
    [InlineData("  Short ", 3, 10, '.', "Short")]
    [InlineData("   ", 5, 10, '.', ".....")] // Pusty ciąg po Trim
    public void Shortener_ShouldAdjustStringCorrectly(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_ShouldHandleEmptyInput()
    {
        // Arrange
        string value = "";
        int min = 5;
        int max = 10;
        char placeholder = '.';

        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(".....", result);
    }

    [Fact]
    public void Shortener_ShouldHandleExactLengthInput()
    {
        // Arrange
        string value = "Exact";
        int min = 5;
        int max = 10;
        char placeholder = '.';

        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal("Exact", result);
    }

    [Fact]
    public void Shortener_ShouldHandleWhitespaceOnlyInput()
    {
        // Arrange
        string value = "   ";
        int min = 3;
        int max = 5;
        char placeholder = '.';

        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal("...", result);
    }
}