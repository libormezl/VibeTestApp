using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class MinOperationTests
    {
        [Fact]
        public void Execute_SimpleMin_ReturnsSmallerNumber()
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(10, 5);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Symbol_ReturnsMin()
        {
            // Arrange
            var operation = new MinOperation();

            // Act & Assert
            Assert.Equal("min", operation.Symbol);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(5, 10, 5)]
        [InlineData(100, 50, 50)]
        [InlineData(25, 75, 25)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 1)]
        public void Execute_WithPositiveNumbers_ReturnsSmallerNumber(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-10, -5, -10)]
        [InlineData(-5, -10, -10)]
        [InlineData(-100, -50, -100)]
        [InlineData(-1, -2, -2)]
        public void Execute_WithNegativeNumbers_ReturnsSmallerNumber(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, -5, -5)]
        [InlineData(-5, 10, -5)]
        [InlineData(5, -10, -10)]
        [InlineData(-10, 5, -10)]
        [InlineData(100, -100, -100)]
        [InlineData(-100, 100, -100)]
        public void Execute_WithMixedSigns_ReturnsSmallerNumber(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(5, 0, 0)]
        [InlineData(0, -5, -5)]
        [InlineData(-5, 0, -5)]
        [InlineData(0, 0, 0)]
        public void Execute_WithZero_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

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
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(value, value);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2.5, 1.5, 1.5)]
        [InlineData(1.5, 2.5, 1.5)]
        [InlineData(10.7, 10.6, 10.6)]
        [InlineData(0.1, 0.2, 0.1)]
        [InlineData(100.001, 100.002, 100.001)]
        [InlineData(-1.5, -2.5, -2.5)]
        public void Execute_WithDecimalNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

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
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.True(double.IsNaN(result));
        }

        [Theory]
        [InlineData(double.PositiveInfinity, 5, 5)]
        [InlineData(5, double.PositiveInfinity, 5)]
        [InlineData(double.NegativeInfinity, 5, double.NegativeInfinity)]
        [InlineData(5, double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity)]
        public void Execute_WithInfinity_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_BothPositiveInfinity_ReturnsPositiveInfinity()
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(double.PositiveInfinity, double.PositiveInfinity);

            // Assert
            Assert.True(double.IsPositiveInfinity(result));
        }

        [Fact]
        public void Execute_BothNegativeInfinity_ReturnsNegativeInfinity()
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(double.NegativeInfinity, double.NegativeInfinity);

            // Assert
            Assert.True(double.IsNegativeInfinity(result));
        }

        [Theory]
        [InlineData(double.PositiveInfinity, 0, 0)]
        [InlineData(0, double.PositiveInfinity, 0)]
        [InlineData(double.NegativeInfinity, 0, double.NegativeInfinity)]
        [InlineData(0, double.NegativeInfinity, double.NegativeInfinity)]
        public void Execute_InfinityWithZero_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(double.MaxValue, 100, 100)]
        [InlineData(100, double.MaxValue, 100)]
        [InlineData(double.MinValue, -100, double.MinValue)]
        [InlineData(-100, double.MinValue, double.MinValue)]
        public void Execute_WithExtremeValues_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_MaxValueAndMinValue_ReturnsMinValue()
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(double.MaxValue, double.MinValue);

            // Assert
            Assert.Equal(double.MinValue, result);
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
            var operation = new MinOperation();

            // Act
            var result1 = operation.Execute(a, b);
            var result2 = operation.Execute(b, a);

            // Assert
            Assert.Equal(result1, result2);
        }

        [Theory]
        [InlineData(1e-300, 1e-301, 1e-301)]
        [InlineData(1e-308, 0, 0)]
        [InlineData(double.Epsilon, 0, 0)]
        public void Execute_WithVerySmallNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1e300, 1e299, 1e299)]
        [InlineData(1e308, 1e307, 1e307)]
        public void Execute_WithVeryLargeNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_MultipleOperations_MaintainsConsistency()
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result1 = operation.Execute(10, 5);   // 5
            var result2 = operation.Execute(result1, 7);   // 5
            var result3 = operation.Execute(result2, 3);  // 3
            var result4 = operation.Execute(result3, 8);  // 3

            // Assert
            Assert.Equal(5, result1);
            Assert.Equal(5, result2);
            Assert.Equal(3, result3);
            Assert.Equal(3, result4);
        }

        [Theory]
        [InlineData(-0.0, 0.0, -0.0)]
        [InlineData(0.0, -0.0, -0.0)]
        public void Execute_NegativeZeroVsPositiveZero_ReturnsNegativeZero(double a, double b, double expected)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 5, 15)]
        [InlineData(100, 50, 150)]
        [InlineData(-10, -5, -15)]
        public void Execute_MinPlusMax_RelationshipTest(double a, double b, double expectedSum)
        {
            // Arrange
            var minOp = new MinOperation();
            var maxOp = new MaxOperation();

            // Act
            var minResult = minOp.Execute(a, b);
            var maxResult = maxOp.Execute(a, b);
            var sum = minResult + maxResult;

            // Assert - min(a,b) + max(a,b) should equal a + b
            Assert.Equal(expectedSum, sum);
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(100, 50)]
        [InlineData(-10, 20)]
        public void Execute_MinIsAlwaysLessThanOrEqualToMax(double a, double b)
        {
            // Arrange
            var minOp = new MinOperation();
            var maxOp = new MaxOperation();

            // Act
            var minResult = minOp.Execute(a, b);
            var maxResult = maxOp.Execute(a, b);

            // Assert
            Assert.True(minResult <= maxResult);
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(-5, -10)]
        [InlineData(0, 100)]
        public void Execute_MinIsOneOfTheInputs(double a, double b)
        {
            // Arrange
            var operation = new MinOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert - result must be either a or b
            Assert.True(result == a || result == b);
        }
    }
}
