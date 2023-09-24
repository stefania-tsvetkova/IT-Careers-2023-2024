namespace Machines
{
    public class Car : IMachine
    {
        public string Type { get; private set; }

        public Car()
        {
            Type = "Car";
        }

        public void Start()
            => Console.WriteLine("The car is starting..");

        public void Stop()
            => Console.WriteLine("The car has stopped!");
    }
}
