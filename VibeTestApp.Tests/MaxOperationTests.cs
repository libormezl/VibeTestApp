using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class MaxOperationTests
    {
        [Fact]
        public void Execute_SimpleMax_ReturnsLargerNumber()
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(10, 5);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Symbol_ReturnsMax()
        {
            // Arrange
            var operation = new MaxOperation();

            // Act & Assert
            Assert.Equal("max", operation.Symbol);
        }

        [Theory]
        [InlineData(10, 5, 10)]
        [InlineData(5, 10, 10)]
        [InlineData(100, 50, 100)]
        [InlineData(25, 75, 75)]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        public void Execute_WithPositiveNumbers_ReturnsLargerNumber(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-10, -5, -5)]
        [InlineData(-5, -10, -5)]
        [InlineData(-100, -50, -50)]
        [InlineData(-1, -2, -1)]
        public void Execute_WithNegativeNumbers_ReturnsLargerNumber(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, -5, 10)]
        [InlineData(-5, 10, 10)]
        [InlineData(5, -10, 5)]
        [InlineData(-10, 5, 5)]
        [InlineData(100, -100, 100)]
        [InlineData(-100, 100, 100)]
        public void Execute_WithMixedSigns_ReturnsLargerNumber(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 5, 5)]
        [InlineData(5, 0, 5)]
        [InlineData(0, -5, 0)]
        [InlineData(-5, 0, 0)]
        [InlineData(0, 0, 0)]
        public void Execute_WithZero_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(-5, -5)]
        [InlineData(0, 0)]
        [InlineData(100.5, 100.5)]
        public void Execute_WithEqualNumbers_ReturnsSameNumber(double value, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(value, value);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2.5, 1.5, 2.5)]
        [InlineData(1.5, 2.5, 2.5)]
        [InlineData(10.7, 10.6, 10.7)]
        [InlineData(0.1, 0.2, 0.2)]
        [InlineData(100.001, 100.002, 100.002)]
        [InlineData(-1.5, -2.5, -1.5)]
        public void Execute_WithDecimalNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(double.NaN, 5)]
        [InlineData(5, double.NaN)]
        [InlineData(double.NaN, double.NaN)]
        public void Execute_WithNaN_ReturnsNaN(double a, double b)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.True(double.IsNaN(result));
        }

        [Theory]
        [InlineData(double.PositiveInfinity, 5, double.PositiveInfinity)]
        [InlineData(5, double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 5, 5)]
        [InlineData(5, double.NegativeInfinity, 5)]
        [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.PositiveInfinity)]
        public void Execute_WithInfinity_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_BothPositiveInfinity_ReturnsPositiveInfinity()
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(double.PositiveInfinity, double.PositiveInfinity);

            // Assert
            Assert.True(double.IsPositiveInfinity(result));
        }

        [Fact]
        public void Execute_BothNegativeInfinity_ReturnsNegativeInfinity()
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(double.NegativeInfinity, double.NegativeInfinity);

            // Assert
            Assert.True(double.IsNegativeInfinity(result));
        }

        [Theory]
        [InlineData(double.PositiveInfinity, 0, double.PositiveInfinity)]
        [InlineData(0, double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 0, 0)]
        [InlineData(0, double.NegativeInfinity, 0)]
        public void Execute_InfinityWithZero_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(double.MaxValue, 100, double.MaxValue)]
        [InlineData(100, double.MaxValue, double.MaxValue)]
        [InlineData(double.MinValue, -100, -100)]
        [InlineData(-100, double.MinValue, -100)]
        public void Execute_WithExtremeValues_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_MaxValueAndMinValue_ReturnsMaxValue()
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(double.MaxValue, double.MinValue);

            // Assert
            Assert.Equal(double.MaxValue, result);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(10, 5)]
        [InlineData(-5, 10)]
        [InlineData(10, -5)]
        [InlineData(2.5, 7.5)]
        public void Execute_Commutativity_ResultIsIndependentOfOrder(double a, double b)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result1 = operation.Execute(a, b);
            var result2 = operation.Execute(b, a);

            // Assert
            Assert.Equal(result1, result2);
        }

        [Theory]
        [InlineData(1e-300, 1e-301, 1e-300)]
        [InlineData(1e-308, 0, 1e-308)]
        [InlineData(double.Epsilon, 0, double.Epsilon)]
        public void Execute_WithVerySmallNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1e300, 1e299, 1e300)]
        [InlineData(1e308, 1e307, 1e308)]
        public void Execute_WithVeryLargeNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_MultipleOperations_MaintainsConsistency()
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result1 = operation.Execute(10, 5);   // 10
            var result2 = operation.Execute(result1, 7);   // 10
            var result3 = operation.Execute(result2, 15);  // 15
            var result4 = operation.Execute(result3, 12);  // 15

            // Assert
            Assert.Equal(10, result1);
            Assert.Equal(10, result2);
            Assert.Equal(15, result3);
            Assert.Equal(15, result4);
        }

        [Theory]
        [InlineData(-0.0, 0.0, 0.0)]
        [InlineData(0.0, -0.0, 0.0)]
        public void Execute_NegativeZeroVsPositiveZero_ReturnsPositiveZero(double a, double b, double expected)
        {
            // Arrange
            var operation = new MaxOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
