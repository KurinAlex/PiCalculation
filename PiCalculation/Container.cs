namespace PiCalculation;

internal class Container
{
	public double Pi { get; set; }

	public required CountdownEvent Event { get; init; }

	public required IList<Point> Points { get; init; }

	public required int StartIndex { get; init; }

	public required int Length { get; init; }
}