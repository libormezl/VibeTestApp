using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class LogarithmOperationTests
    {
        [Fact]
        public void Execute_ValidLogarithm_ReturnsCorrectResult()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(100, 10);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Symbol_ReturnsLog()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            Assert.Equal("log", operation.Symbol);
        }

        [Theory]
        [InlineData(8, 2, 3)]
        [InlineData(1000, 10, 3)]
        [InlineData(16, 2, 4)]
        [InlineData(27, 3, 3)]
        [InlineData(625, 5, 4)]
        [InlineData(1, 10, 0)]
        [InlineData(10, 10, 1)]
        public void Execute_WithVariousValidInputs_ReturnsCorrectResults(double a, double b, double expected)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-100)]
        [InlineData(-0.5)]
        public void Execute_NegativeArgument_ThrowsArgumentException(double a)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(a, 10));
            Assert.Contains("must be positive", exception.Message);
            Assert.Equal("a", exception.ParamName);
        }

        [Fact]
        public void Execute_ZeroArgument_ThrowsArgumentException()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(0, 10));
            Assert.Contains("must be positive", exception.Message);
            Assert.Equal("a", exception.ParamName);
        }

        [Fact]
        public void Execute_NaNArgument_ThrowsArgumentException()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(double.NaN, 10));
            Assert.Contains("cannot be NaN or Infinity", exception.Message);
            Assert.Equal("a", exception.ParamName);
        }

        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void Execute_InfinityArgument_ThrowsArgumentException(double a)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(a, 10));
            Assert.Contains("cannot be NaN or Infinity", exception.Message);
            Assert.Equal("a", exception.ParamName);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-100)]
        [InlineData(-0.5)]
        public void Execute_NegativeBase_ThrowsArgumentException(double b)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(100, b));
            Assert.Contains("must be positive", exception.Message);
            Assert.Equal("b", exception.ParamName);
        }

        [Fact]
        public void Execute_ZeroBase_ThrowsArgumentException()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(100, 0));
            Assert.Contains("must be positive", exception.Message);
            Assert.Equal("b", exception.ParamName);
        }

        [Fact]
        public void Execute_BaseEqualsOne_ThrowsArgumentException()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(100, 1));
            Assert.Contains("cannot be 1", exception.Message);
            Assert.Equal("b", exception.ParamName);
        }

        [Fact]
        public void Execute_BaseVeryCloseToOne_ThrowsArgumentException()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert - Test value very close to 1
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(100, 1.0 + double.Epsilon / 2));
            Assert.Contains("cannot be 1", exception.Message);
        }

        [Fact]
        public void Execute_NaNBase_ThrowsArgumentException()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(100, double.NaN));
            Assert.Contains("cannot be NaN or Infinity", exception.Message);
            Assert.Equal("b", exception.ParamName);
        }

        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void Execute_InfinityBase_ThrowsArgumentException(double b)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => operation.Execute(100, b));
            Assert.Contains("cannot be NaN or Infinity", exception.Message);
            Assert.Equal("b", exception.ParamName);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(10, 10, 1)]
        [InlineData(5, 5, 1)]
        [InlineData(100, 100, 1)]
        [InlineData(0.5, 0.5, 1)]
        public void Execute_ArgumentEqualsBase_ReturnsOne(double value, double baseValue, double expected)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(value, baseValue);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(0.5, 2, -1)]
        [InlineData(0.1, 10, -1)]
        [InlineData(0.25, 2, -2)]
        [InlineData(0.01, 10, -2)]
        public void Execute_ArgumentLessThanOne_ReturnsNegativeResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(2.718281828459045, Math.E, 1)]
        [InlineData(7.389056098930650, Math.E, 2)]
        public void Execute_WithNaturalBase_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        [Theory]
        [InlineData(1000000, 10, 6)]
        [InlineData(0.000001, 10, -6)]
        [InlineData(1024, 2, 10)]
        [InlineData(1048576, 2, 20)]
        public void Execute_WithLargeAndSmallValues_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(100, 2)]
        [InlineData(100, 5)]
        [InlineData(1000, 2)]
        [InlineData(50, 7)]
        public void Execute_WithNonIntegerResults_HandlesCorrectly(double a, double b)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert - Verify result is valid and can be reversed
            var reversed = Math.Pow(b, result);
            Assert.Equal(a, reversed, precision: 10);
        }

        [Theory]
        [InlineData(0.5, 0.5)]
        [InlineData(0.1, 0.1)]
        [InlineData(0.25, 0.75)]
        public void Execute_WithDecimalBase_HandlesCorrectly(double a, double b)
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert - Verify result is valid
            Assert.False(double.IsNaN(result));
            Assert.False(double.IsInfinity(result));
        }

        [Fact]
        public void Execute_MultipleOperations_MaintainsPrecision()
        {
            // Arrange
            var operation = new LogarithmOperation();

            // Act - Perform multiple logarithm operations
            var result1 = operation.Execute(100, 10);  // 2
            var result2 = operation.Execute(1000, 10); // 3
            var result3 = operation.Execute(8, 2);     // 3
            var result4 = operation.Execute(16, 2);    // 4

            // Assert - Use precision tolerance for floating point comparison
            Assert.Equal(2, result1, precision: 10);
            Assert.Equal(3, result2, precision: 10);
            Assert.Equal(3, result3, precision: 10);
            Assert.Equal(4, result4, precision: 10);
        }
    }
}
