namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements minimum operation for the calculator.
    /// Returns the smaller of two numbers.
    /// </summary>
    public class MinOperation : IOperation
    {
        public string Symbol => "min";

        /// <summary>
        /// Returns the minimum of two numbers.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The smaller of the two numbers</returns>
        public double Execute(double a, double b)
        {
            return Math.Min(a, b);
        }
    }
}
