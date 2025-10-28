namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements logarithm operation for the calculator.
    /// Calculates logarithm of a with base b (log_b(a)).
    /// </summary>
    public class LogarithmOperation : IOperation
    {
        public string Symbol => "log";

        public double Execute(double a, double b)
        {
            return Math.Log(a, b);
        }
    }
}
