using System.Diagnostics;

namespace PiCalculation;

internal static class Program
{
	private static int EnterInt32(string name)
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

		var pointsCount = EnterInt32("points count");
		var threadsCount = EnterInt32("threads count");

		PiCalculator[] calculators =
		{
			new OneThreadCalculator(pointsCount),
			new MultiThreadingCalculator(pointsCount, threadsCount)
		};

		foreach (var calculator in calculators)
		{
			var stopwatch = Stopwatch.StartNew();
			var pi = calculator.CalculatePi();
			stopwatch.Stop();

			var error = Math.Abs((Math.PI - pi) / Math.PI) * 100.0;

			Console.WriteLine();
			Console.WriteLine($"{calculator.Name}:");
			Console.WriteLine($"- Elapsed Time:   {stopwatch.Elapsed.TotalSeconds} seconds");
			Console.WriteLine($"- Computed pi:    {pi}");
			Console.WriteLine($"- Relative error: {error} %");
		}
	}
}