namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements addition operation for the calculator.
    /// </summary>
    public class AdditionOperation : IOperation
    {
        public string Symbol => "+";

        public double Execute(double a, double b)
        {
            return a + b;
        }
    }
}
