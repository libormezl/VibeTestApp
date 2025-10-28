namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements logarithm operation for the calculator.
    /// Calculates logarithm of a with base b (log_b(a)).
    /// </summary>
    public class LogarithmOperation : IOperation
    {
        public string Symbol => "log";

        /// <summary>
        /// Calculates logarithm of a with base b.
        /// </summary>
        /// <param name="a">The value (must be positive)</param>
        /// <param name="b">The base (must be positive and not equal to 1)</param>
        /// <returns>The logarithm result</returns>
        /// <exception cref="ArgumentException">Thrown when parameters are invalid</exception>
        public double Execute(double a, double b)
        {
            // Validate that the value is not NaN or Infinity (must check first)
            if (double.IsNaN(a) || double.IsInfinity(a))
            {
                throw new ArgumentException($"Logarithm argument cannot be NaN or Infinity. Got: {a}", nameof(a));
            }

            // Validate that the value is positive
            if (a <= 0)
            {
                throw new ArgumentException($"Logarithm argument must be positive. Got: {a}", nameof(a));
            }

            // Validate that the base is not NaN or Infinity (must check first)
            if (double.IsNaN(b) || double.IsInfinity(b))
            {
                throw new ArgumentException($"Logarithm base cannot be NaN or Infinity. Got: {b}", nameof(b));
            }

            // Validate that the base is positive and not equal to 1
            if (b <= 0)
            {
                throw new ArgumentException($"Logarithm base must be positive. Got: {b}", nameof(b));
            }

            if (Math.Abs(b - 1.0) < double.Epsilon)
            {
                throw new ArgumentException("Logarithm base cannot be 1.", nameof(b));
            }

            return Math.Log(a, b);
        }
    }
}
