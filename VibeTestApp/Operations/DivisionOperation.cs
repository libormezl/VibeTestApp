namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements division operation for the calculator.
    /// </summary>
    public class DivisionOperation : IOperation
    {
        public string Symbol => "/";

        public double Execute(double a, double b)
        {
            return a / b;
        }
    }
}
