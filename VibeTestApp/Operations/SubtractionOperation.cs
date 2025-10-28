namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements subtraction operation for the calculator.
    /// </summary>
    public class SubtractionOperation : IOperation
    {
        public string Symbol => "-";

        public double Execute(double a, double b)
        {
            return a - b;
        }
    }
}
