namespace PiCalculation;

public class OneThreadCalculator : PiCalculator
{
	public OneThreadCalculator(int pointsCount) : base(pointsCount)
	{
	}

	public override string Name => "One Thread";

	public override double CalculatePi()
	{
		var points = Point.GeneratePoints(PointsCount);
		var pi = CalculatePi(points);
		return pi;
	}
}