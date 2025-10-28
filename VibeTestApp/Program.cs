using VibeTestApp.Operations;

namespace VibeTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize calculator with available operations
            // Currently only addition is implemented
            var operations = new List<IOperation>
            {
                new AdditionOperation()
                // Future operations can be added here:
                // new SubtractionOperation(),
                // new MultiplicationOperation(),
                // new DivisionOperation()
            };

            var calculator = new Calculator(operations);

            Console.WriteLine("=== Calculator Demo ===");
            Console.WriteLine($"Supported operations: {string.Join(", ", calculator.SupportedOperations)}");
            Console.WriteLine();

            // Demonstrate addition
            double num1 = 10;
            double num2 = 5;

            try
            {
                double result = calculator.Calculate(num1, num2, "+");
                Console.WriteLine($"{num1} + {num2} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Calculator is ready for future operations!");
        }
    }
}
