using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class DivisionOperationTests
    {
        [Fact]
        public void Execute_SimpleDivision_ReturnsCorrectResult()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(10, 2);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Symbol_ReturnsSlash()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act & Assert
            Assert.Equal("/", operation.Symbol);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(15, 3, 5)]
        [InlineData(100, 4, 25)]
        [InlineData(7, 2, 3.5)]
        [InlineData(1, 2, 0.5)]
        [InlineData(1, 3, 0.333333333333333)]
        [InlineData(22, 7, 3.14285714285714)]
        public void Execute_WithPositiveNumbers_ReturnsCorrectResults(double a, double b, double expected)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-10, 2, -5)]
        [InlineData(10, -2, -5)]
        [InlineData(-10, -2, 5)]
        [InlineData(-15, 3, -5)]
        [InlineData(15, -3, -5)]
        [InlineData(-15, -3, 5)]
        [InlineData(-7.5, 2.5, -3)]
        [InlineData(7.5, -2.5, -3)]
        public void Execute_WithNegativeNumbers_ReturnsCorrectResults(double a, double b, double expected)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(0, 5, 0)]
        [InlineData(0, -5, 0)]
        [InlineData(0, 100.5, 0)]
        [InlineData(0, -100.5, 0)]
        public void Execute_ZeroDividedByNumber_ReturnsZero(double a, double b, double expected)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, 0)]
        [InlineData(100.5, 0)]
        public void Execute_PositiveNumberDividedByZero_ReturnsPositiveInfinity(double a, double b)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.True(double.IsPositiveInfinity(result));
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(-10, 0)]
        [InlineData(-100.5, 0)]
        public void Execute_NegativeNumberDividedByZero_ReturnsNegativeInfinity(double a, double b)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.True(double.IsNegativeInfinity(result));
        }

        [Fact]
        public void Execute_ZeroDividedByZero_ReturnsNaN()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(0, 0);

            // Assert
            Assert.True(double.IsNaN(result));
        }

        [Theory]
        [InlineData(100.5, 2.5, 40.2)]
        [InlineData(99.99, 3.33, 30.027027027027)]
        [InlineData(0.1, 0.2, 0.5)]
        [InlineData(0.25, 0.5, 0.5)]
        [InlineData(1.5, 3.0, 0.5)]
        [InlineData(2.75, 1.25, 2.2)]
        public void Execute_WithDecimalNumbers_ReturnsCorrectResults(double a, double b, double expected)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Fact]
        public void Execute_DivisionResultingInOne_ReturnsOne()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act & Assert
            Assert.Equal(1, operation.Execute(5, 5));
            Assert.Equal(1, operation.Execute(100, 100));
            Assert.Equal(1, operation.Execute(-7, -7));
            Assert.Equal(1, operation.Execute(0.5, 0.5));
        }

        [Theory]
        [InlineData(double.MaxValue, 2, double.MaxValue / 2)]
        [InlineData(double.MinValue, 2, double.MinValue / 2)]
        [InlineData(1e-100, 1e-50, 1e-50)]
        public void Execute_WithLargeAndSmallNumbers_HandlesCorrectly(double a, double b, double expected)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        [Fact]
        public void Execute_WithVeryLargeExponents_HandlesCorrectly()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(1e100, 1e50);

            // Assert - verify result is in expected magnitude range
            Assert.True(result >= 9.99e49 && result <= 1.01e50);
        }

        [Theory]
        [InlineData(1, 1e308)]
        [InlineData(1e-308, 1e308)]
        public void Execute_WithVerySmallResults_HandlesCorrectly(double a, double b)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);

            // Assert
            Assert.True(result >= 0 && result < 1e-300);
        }

        [Fact]
        public void Execute_DivisionByOne_ReturnsSameNumber()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act & Assert
            Assert.Equal(5, operation.Execute(5, 1));
            Assert.Equal(100.5, operation.Execute(100.5, 1));
            Assert.Equal(-25, operation.Execute(-25, 1));
            Assert.Equal(0, operation.Execute(0, 1));
        }

        [Fact]
        public void Execute_DivisionByMinusOne_ReturnsNegatedNumber()
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act & Assert
            Assert.Equal(-5, operation.Execute(5, -1));
            Assert.Equal(-100.5, operation.Execute(100.5, -1));
            Assert.Equal(25, operation.Execute(-25, -1));
            Assert.Equal(0, operation.Execute(0, -1));
        }

        [Theory]
        [InlineData(10, 3)]
        [InlineData(7, 3)]
        [InlineData(100, 7)]
        public void Execute_DivisionWithNonTerminatingDecimal_ReturnsCorrectPrecision(double a, double b)
        {
            // Arrange
            var operation = new DivisionOperation();

            // Act
            var result = operation.Execute(a, b);
            var reverseResult = operation.Execute(result * b, b);

            // Assert
            Assert.True(result > 0);
            Assert.Equal(result, reverseResult, precision: 10);
        }

        [Fact]
        public void Execute_ConsecutiveDivisions_MaintainsPrecision()
        {
            // Arrange
            var operation = new DivisionOperation();
            double value = 1000;

            // Act
            var result1 = operation.Execute(value, 2); // 500
            var result2 = operation.Execute(result1, 2); // 250
            var result3 = operation.Execute(result2, 2); // 125
            var result4 = operation.Execute(result3, 5); // 25

            // Assert
            Assert.Equal(500, result1);
            Assert.Equal(250, result2);
            Assert.Equal(125, result3);
            Assert.Equal(25, result4);
        }
    }
}
