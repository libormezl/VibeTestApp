using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class AdditionOperationTests
    {
        [Fact]
        public void Execute_SimpleAddition_ReturnsCorrectResult()
        {
            // Arrange
            var operation = new AdditionOperation();

            // Act
            var result = operation.Execute(5, 3);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Symbol_ReturnsPlus()
        {
            // Arrange
            var operation = new AdditionOperation();

            // Act & Assert
            Assert.Equal("+", operation.Symbol);
        }

        [Theory]
        [InlineData(double.MaxValue, 0, double.MaxValue)]
        [InlineData(double.MinValue, 0, double.MinValue)]
        [InlineData(1e100, 1e100, 2e100)]
        public void Execute_EdgeCases_HandlesCorrectly(double a, double b, double expected)
        {
            // Arrange
            var operation = new AdditionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
