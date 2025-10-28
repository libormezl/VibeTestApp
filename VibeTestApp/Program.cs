using VibeTestApp.Operations;

namespace VibeTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize calculator with available operations
            var operations = new List<IOperation>
            {
                new AdditionOperation(),
                new SubtractionOperation(),
                new MultiplicationOperation(),
                new DivisionOperation(),
                new PowerOperation()
            };

            var calculator = new Calculator(operations);

            Console.WriteLine("=== Calculator Demo ===");
            Console.WriteLine($"Supported operations: {string.Join(", ", calculator.SupportedOperations)}");
            Console.WriteLine();

            // Demonstrate operations
            double num1 = 10;
            double num2 = 5;

            try
            {
                double addResult = calculator.Calculate(num1, num2, "+");
                Console.WriteLine($"{num1} + {num2} = {addResult}");

                double subResult = calculator.Calculate(num1, num2, "-");
                Console.WriteLine($"{num1} - {num2} = {subResult}");

                double mulResult = calculator.Calculate(num1, num2, "*");
                Console.WriteLine($"{num1} * {num2} = {mulResult}");

                double divResult = calculator.Calculate(num1, num2, "/");
                Console.WriteLine($"{num1} / {num2} = {divResult}");

                double powResult = calculator.Calculate(num1, num2, "^");
                Console.WriteLine($"{num1} ^ {num2} = {powResult}");
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
