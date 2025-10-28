namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements power (exponentiation) operation for the calculator.
    /// </summary>
    public class PowerOperation : IOperation
    {
        public string Symbol => "^";

        public double Execute(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
