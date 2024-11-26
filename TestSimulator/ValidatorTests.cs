using Simulator;
namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-5, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    public void Limiter_ShouldLimitValueCorrectly(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("Test", 2, 10, '#', "Test")]
    [InlineData("T", 2, 10, '#', "T#")]
    [InlineData("This is a very long string", 2, 10, '#', "This is a")]
    [InlineData("", 5, 10, '#', "#####")]
    [InlineData("   abc", 5, 10, '#', "Abc##")]
    [InlineData("A             B", 3, 10, '#', "A##")]
    public void Shortener_ShouldAdjustStringCorrectly(string value, int min, int max, char placeholder, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(value, min, max, placeholder));
    }
}