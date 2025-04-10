namespace PiCalculation;

public class MultiThreadingCalculator : PiCalculator
{
	private readonly int _threadsCount;

	public MultiThreadingCalculator(int pointsCount, int threadsCount) : base(pointsCount)
	{
		_threadsCount = threadsCount;
	}

	public override string Name => "Multi Threading";

	public override double CalculatePi()
	{
		var points = Point.GeneratePoints(PointsCount);

		var containers = new List<Container>(_threadsCount);
		var countdownEvent = new CountdownEvent(_threadsCount);
		var length = PointsCount / _threadsCount;

		for (var i = 0; i < _threadsCount; i++)
		{
			var container = new Container
			{
				Event = countdownEvent,
				Points = points,
				StartIndex = length * i,
				Length = length
			};
			containers.Add(container);

			var thread = new Thread(Run);
			thread.Start(container);
		}

		countdownEvent.Wait();

		var pi = containers.Sum(container => container.Pi);
		pi /= _threadsCount;
		return pi;
	}

	private static void Run(object? obj)
	{
		if (obj is not Container container)
		{
			throw new ArgumentException("Wrong object type", nameof(obj));
		}

		var pi = CalculatePi(container.Points, container.StartIndex, container.Length);
		container.Pi = pi;
		container.Event.Signal();
	}
}