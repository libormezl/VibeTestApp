using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class MultiplicationOperationTests
    {
        [Fact]
        public void Execute_SimpleMultiplication_ReturnsCorrectResult()
        {
            // Arrange
            var operation = new MultiplicationOperation();

            // Act
            var result = operation.Execute(5, 3);

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void Symbol_ReturnsAsterisk()
        {
            // Arrange
            var operation = new MultiplicationOperation();

            // Act & Assert
            Assert.Equal("*", operation.Symbol);
        }
    }
}
