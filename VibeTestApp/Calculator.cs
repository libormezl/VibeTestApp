namespace VibeTestApp
{
    /// <summary>
    /// Calculator service that performs mathematical operations.
    /// Uses dependency injection to support different operations.
    /// </summary>
    public class Calculator
    {
        private readonly Dictionary<string, IOperation> _operations;

        /// <summary>
        /// Initializes a new instance of the Calculator with supported operations.
        /// </summary>
        /// <param name="operations">Collection of operations the calculator supports</param>
        public Calculator(IEnumerable<IOperation> operations)
        {
            if (operations == null || !operations.Any())
            {
                throw new ArgumentException("Calculator must have at least one operation.", nameof(operations));
            }

            _operations = operations.ToDictionary(op => op.Symbol, op => op);
        }

        /// <summary>
        /// Performs a calculation based on the provided operation symbol.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="operationSymbol">Operation symbol (e.g., "+", "-", "*", "/")</param>
        /// <returns>Result of the calculation</returns>
        /// <exception cref="InvalidOperationException">Thrown when operation is not supported</exception>
        public double Calculate(double a, double b, string operationSymbol)
        {
            if (string.IsNullOrWhiteSpace(operationSymbol))
            {
                throw new ArgumentException("Operation symbol cannot be null or empty.", nameof(operationSymbol));
            }

            if (!_operations.ContainsKey(operationSymbol))
            {
                throw new InvalidOperationException($"Operation '{operationSymbol}' is not supported. " +
                    $"Supported operations: {string.Join(", ", _operations.Keys)}");
            }

            return _operations[operationSymbol].Execute(a, b);
        }

        /// <summary>
        /// Gets all supported operation symbols.
        /// </summary>
        public IEnumerable<string> SupportedOperations => _operations.Keys;
    }
}
