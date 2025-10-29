namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements maximum operation for the calculator.
    /// Returns the larger of two numbers.
    /// </summary>
    public class MaxOperation : IOperation
    {
        public string Symbol => "max";

        /// <summary>
        /// Returns the maximum of two numbers.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The larger of the two numbers</returns>
        public double Execute(double a, double b)
        {
            return Math.Max(a, b);
        }
    }
}
