using Simulator;
namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(0, 1, 5, 1)]
    [InlineData(7, 1, 5, 5)]
    public void Limiter_ShouldHandleEdgeCases(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("Hello", 5, 10, '_', "Hello_____")]
    [InlineData("Hi", 4, 6, '*', "Hi**")]
    [InlineData("Very long text", 3, 5, '-', "Very-")]
    public void Shortener_ShouldAddOrTrimCorrectly(string value, int min, int max, char placeholder, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(value, min, max, placeholder));
    }
}