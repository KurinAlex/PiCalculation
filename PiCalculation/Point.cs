namespace PiCalculation;

public record Point(double X, double Y)
{
	public static IList<Point> GeneratePoints(int count)
	{
		var points = new List<Point>(count);
		for (var i = 0; i < count; i++)
		{
			var p = GeneratePoint();
			points.Add(p);
		}

		return points;
	}

	private static Point GeneratePoint()
	{
		var random = new Random();
		var point = new Point(random.NextDouble(), random.NextDouble());
		return point;
	}
}