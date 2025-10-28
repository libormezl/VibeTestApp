using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_WithNoOperations_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Calculator(new List<IOperation>()));
        }

        [Fact]
        public void Calculator_WithNullOperations_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Calculator(null!));
        }

        [Fact]
        public void Calculate_Addition_ReturnsCorrectResult()
        {
            // Arrange
            var operations = new List<IOperation> { new AdditionOperation() };
            var calculator = new Calculator(operations);

            // Act
            var result = calculator.Calculate(10, 5, "+");

            // Assert
            Assert.Equal(15, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(-5, 3, -2)]
        [InlineData(100.5, 50.3, 150.8)]
        [InlineData(-10, -20, -30)]
        public void Calculate_Addition_WithVariousInputs_ReturnsCorrectResults(double a, double b, double expected)
        {
            // Arrange
            var operations = new List<IOperation> { new AdditionOperation() };
            var calculator = new Calculator(operations);

            // Act
            var result = calculator.Calculate(a, b, "+");

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Fact]
        public void Calculate_UnsupportedOperation_ThrowsInvalidOperationException()
        {
            // Arrange
            var operations = new List<IOperation> { new AdditionOperation() };
            var calculator = new Calculator(operations);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => calculator.Calculate(10, 5, "-"));
            Assert.Contains("not supported", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Calculate_InvalidOperationSymbol_ThrowsArgumentException(string? operationSymbol)
        {
            // Arrange
            var operations = new List<IOperation> { new AdditionOperation() };
            var calculator = new Calculator(operations);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calculator.Calculate(10, 5, operationSymbol!));
        }

        [Fact]
        public void SupportedOperations_ReturnsAllRegisteredOperations()
        {
            // Arrange
            var operations = new List<IOperation> { new AdditionOperation() };
            var calculator = new Calculator(operations);

            // Act
            var supportedOps = calculator.SupportedOperations.ToList();

            // Assert
            Assert.Single(supportedOps);
            Assert.Contains("+", supportedOps);
        }
    }

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