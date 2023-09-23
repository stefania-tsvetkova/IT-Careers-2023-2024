namespace Vehicles
{
    public abstract class Car
    {
        protected string Brand;

        public string Model { get; protected set; }

        public string Color { get; protected set; }

        public void Start()
        {
            Console.WriteLine("Starting..");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping..");
        }

        public override string ToString()
        {
            return $"{Color} {Brand} {Model}";
        }
    }
}
