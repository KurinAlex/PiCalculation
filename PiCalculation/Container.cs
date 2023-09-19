namespace PiCalculation
{
    internal class Container
    {
        public double Pi
        {
            get;
            set;
        }

        public required CountdownEvent Event
        {
            get;
            init;
        }
    }
}
