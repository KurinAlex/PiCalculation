using System.Diagnostics;
using System.Drawing;

namespace PiCalculation
{
    internal class OneThreadCalculator : PiCalculator
    {
        public OneThreadCalculator(int pointsCount) : base(pointsCount)
        {
        }

        public override PiCalculationResult CalculatePi()
        {
            Stopwatch timer = Stopwatch.StartNew();

            var points = new List<Point>(pointsCount);
            for (int i = 0; i < pointsCount; i++)
            {
                Point p = GeneratePoint();
                points.Add(p);
            }

            double pi = CalculatePi(points);
            timer.Stop();

            return new PiCalculationResult(pi, timer.Elapsed);
        }
        
        private static double CalculatePi(ICollection<Point> points)
        {
            int inside = 0;
            foreach (Point p in points)
            {
                if (IsInside(p.X, p.Y))
                {
                    inside++;
                }
            }
            double pi = 4.0 / points.Count * inside;
            return pi;
        }
    }
}
