namespace Machines
{
    public class Truck : IMachine
    {
        public string Type { get; private set; }

        public Truck()
        {
            Type = "Truck";
        }

        public void Start()
            => Console.WriteLine("The truck is starting..");

        public void Stop()
            => Console.WriteLine("The truck has stopped!");
    }
}
