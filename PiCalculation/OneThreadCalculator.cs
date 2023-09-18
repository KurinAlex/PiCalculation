using System.Diagnostics;

namespace PiCalculation
{
    public class OneThreadCalculator : PiCalculator
    {
        public OneThreadCalculator(int pointsCount) : base(pointsCount)
        {
        }

        public override PiCalculationResult CalculatePi()
        {
            Stopwatch timer = Stopwatch.StartNew();

            IList<Point> points = Point.GeneratePoints(pointsCount);
            double pi = CalculatePi(points);

            timer.Stop();
            return new PiCalculationResult(pi, timer.Elapsed);
        }

        public override string ToString()
        {
            return "One Thread";
        }
    }
}
