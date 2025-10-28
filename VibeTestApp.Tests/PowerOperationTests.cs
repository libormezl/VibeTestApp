using VibeTestApp.Operations;

namespace VibeTestApp.Tests
{
    public class PowerOperationTests
    {
        [Fact]
        public void Execute_SimplePower_ReturnsCorrectResult()
        {
            // Arrange
            var operation = new PowerOperation();

            // Act
            var result = operation.Execute(2, 3);

            // Assert
            Assert.Equal(8, result);
        }
    }
}
