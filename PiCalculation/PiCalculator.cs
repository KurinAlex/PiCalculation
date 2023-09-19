namespace PiCalculation
{
    public abstract class PiCalculator
    {
        protected readonly int pointsCount;

        protected PiCalculator(int pointsCount)
        {
            this.pointsCount = pointsCount;
        }

        public abstract PiCalculationResult CalculatePi();

        public abstract override string ToString();

        protected static double CalculatePi(IList<Point> points)
        {
            return CalculatePi(points, 0, points.Count);
        }

        protected static double CalculatePi(IList<Point> points, int startIndex, int length)
        {
            int inside = 0;
            int endIndex = startIndex + length;
            for (int i = startIndex; i < endIndex; i++)
            {
                Point point = points[i];
                if (IsInside(point))
                {
                    inside++;
                }
            }
            double pi = 4.0 / length * inside;
            return pi;
        }

        private static bool IsInside(Point point)
        {
            double x = point.X;
            double y = point.Y;
            double l = Math.Sqrt(x * x + y * y);
            return l <= 1;
        }
    }
}
