using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class SubtractionOperationTests
    {
        [Fact]
        public void Execute_SimpleSubtraction_ReturnsCorrectResult()
        {
            // Arrange
            var operation = new SubtractionOperation();

            // Act
            var result = operation.Execute(5, 3);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Symbol_ReturnsMinus()
        {
            // Arrange
            var operation = new SubtractionOperation();

            // Act & Assert
            Assert.Equal("-", operation.Symbol);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(5, 10, -5)]
        [InlineData(-5, 3, -8)]
        [InlineData(-5, -3, -2)]
        [InlineData(100.5, 50.3, 50.2)]
        [InlineData(-10, -20, 10)]
        public void Execute_WithVariousInputs_ReturnsCorrectResults(double a, double b, double expected)
        {
            // Arrange
            var operation = new SubtractionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(double.MaxValue, 0, double.MaxValue)]
        [InlineData(double.MinValue, 0, double.MinValue)]
        [InlineData(1e100, 1e100, 0)]
        public void Execute_EdgeCases_HandlesCorrectly(double a, double b, double expected)
        {
            // Arrange
            var operation = new SubtractionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
