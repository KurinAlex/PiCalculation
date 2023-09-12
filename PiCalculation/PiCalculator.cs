namespace PiCalculation
{
    public abstract class PiCalculator
    {
        protected int pointsCount;
        protected Random random;

        protected PiCalculator(int pointsCount)
        {
            this.pointsCount = pointsCount;
            this.random = new Random();
        }

        public abstract PiCalculationResult CalculatePi();

        protected static bool IsInside(double x, double y)
        {
            double l = Math.Sqrt(x * x + y * y);
            return l <= 1;
        }

        protected Point GeneratePoint()
        {
            var point = new Point(random.NextDouble(), random.NextDouble());
            return point;
        }
    }
}
