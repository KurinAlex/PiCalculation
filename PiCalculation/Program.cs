namespace PiCalculation
{
    internal static class Program
    {
        static int EnterInt32(string name)
        {
            int res;
            string? input;
            do
            {
                Console.Write($"Enter {name}: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out res));
            return res;
        }

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int pointsCount = EnterInt32("points count");
            int threadsCount = EnterInt32("threads count");

            PiCalculator[] calculators = {
                new OneThreadCalculator(pointsCount),
                new MultiThreadingCalculator(pointsCount, threadsCount)
            };

            foreach (var calculator in calculators)
            {
                PiCalculationResult result = calculator.CalculatePi();

                double pi = result.Pi;
                double error = Math.Abs((Math.PI - result.Pi) / Math.PI) * 100.0;

                Console.WriteLine();
                Console.WriteLine($"{calculator}:");
                Console.WriteLine($"- Elapsed Time:   {result.Elapsed.TotalSeconds} seconds");
                Console.WriteLine($"- Computed pi:    {pi}");
                Console.WriteLine($"- Relative error: {error} %");
            }
        }
    }
}