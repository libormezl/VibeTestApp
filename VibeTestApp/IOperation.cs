namespace VibeTestApp
{
    /// <summary>
    /// Interface for calculator operations.
    /// Implementing this interface allows adding new operations without modifying existing code.
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Executes the operation on two operands.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of the operation</returns>
        double Execute(double a, double b);

        /// <summary>
        /// Gets the operation symbol (e.g., "+", "-", "*", "/")
        /// </summary>
        string Symbol { get; }
    }
}
