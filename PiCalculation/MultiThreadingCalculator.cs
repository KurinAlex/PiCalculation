using System.Diagnostics;

namespace PiCalculation
{
    public class MultiThreadingCalculator : PiCalculator
    {
        private readonly int threadsCount;

        public MultiThreadingCalculator(int pointsCount, int threadsCount) : base(pointsCount)
        {
            this.threadsCount = threadsCount;
        }

        public override PiCalculationResult CalculatePi()
        {
            Stopwatch timer = Stopwatch.StartNew();

            IList<Point> points = Point.GeneratePoints(pointsCount);

            var containers = new List<Container>(threadsCount);
            var countdownEvent = new CountdownEvent(threadsCount);
            for (int i = 0; i < threadsCount; i++)
            {
                var container = new Container
                {
                    Event = countdownEvent,
                    Points = points,
                    StartIndex = i * pointsCount / threadsCount,
                    Length = pointsCount / threadsCount,
                };
                containers.Add(container);

                var thread = new Thread(new ParameterizedThreadStart(Run));
                thread.Start(container);
            }

            countdownEvent.Wait();

            double pi = 0.0;
            foreach (Container container in containers)
            {
                pi += container.Pi;
            }
            pi /= threadsCount;

            timer.Stop();
            return new PiCalculationResult(pi, timer.Elapsed);
        }

        public override string ToString()
        {
            return "Multi Threading";
        }

        private void Run(object? obj)
        {
            if (obj is not Container container)
            {
                throw new ArgumentException("Wrong object type", nameof(obj));
            }

            double pi = CalculatePi(container.Points, container.StartIndex, container.Length);
            container.Pi = pi;
            container.Event.Signal();
        }
    }
}
