namespace PiCalculation
{
    internal class Program
    {
        static public void Run(object obj)
        {
            if(obj is not Container container)
            {
                throw new ArgumentException("Wrong object type", nameof(obj));
            }

            List<Point> points = new List<Point>();
            for (int i = 0; i < Size / ThreadNumber; i++)
            {
                Point p = GeneratePoint();
                points.Add(p);
            }

            double pi = CalcPi(points);
            container.Pi = pi;
            container.Event.Signal();
        }

        public static void Main(string[] args)
        {

            // multi threading
        }
    }
}