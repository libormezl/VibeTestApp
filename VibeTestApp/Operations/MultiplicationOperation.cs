namespace VibeTestApp.Operations
{
    /// <summary>
    /// Implements multiplication operation for the calculator.
    /// </summary>
    public class MultiplicationOperation : IOperation
    {
        public string Symbol => "*";

        public double Execute(double a, double b)
        {
            return a * b;
        }
    }
}
