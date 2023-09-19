using System.Diagnostics;

namespace PiCalculation
{
    internal class MultiThreadingCalculator : PiCalculator
    {
        private const int ThreadNumber = 4;

        public MultiThreadingCalculator(int pointsCount) : base(pointsCount)
        {
        }

        public override PiCalculationResult CalculatePi()
        {
            var timer = Stopwatch.StartNew();

            var containers = new List<Container>(ThreadNumber);
            var countdownEvent = new CountdownEvent(ThreadNumber);
            for (int i = 0; i < ThreadNumber; i++)
            {
                var container = new Container
                {
                    Event = countdownEvent
                };
                containers.Add(container);

                var thread = new Thread(new ParameterizedThreadStart(Run));
                thread.Start(container);
            }

            countdownEvent.Wait();

            double pi = 0.0;
            foreach (Container c in containers)
            {
                pi += c.Pi;
            }
            pi /= ThreadNumber;

            timer.Stop();
            return new PiCalculationResult(pi, timer.Elapsed);
        }
    }
}
