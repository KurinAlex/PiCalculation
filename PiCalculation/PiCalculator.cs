namespace PiCalculation;

public abstract class PiCalculator
{
	protected readonly int PointsCount;

	protected PiCalculator(int pointsCount)
	{
		PointsCount = pointsCount;
	}

	public abstract string Name { get; }

	public abstract double CalculatePi();

	protected static double CalculatePi(IList<Point> points)
	{
		return CalculatePi(points, 0, points.Count);
	}

	protected static double CalculatePi(IList<Point> points, int startIndex, int length)
	{
		var inside = 0;
		var endIndex = startIndex + length;
		for (var i = startIndex; i < endIndex; i++)
		{
			var point = points[i];
			if (IsInside(point))
			{
				inside++;
			}
		}

		var pi = 4.0 / length * inside;
		return pi;
	}

	private static bool IsInside(Point point)
	{
		var x = point.X;
		var y = point.Y;
		var l = Math.Sqrt(x * x + y * y);
		return l <= 1;
	}
}