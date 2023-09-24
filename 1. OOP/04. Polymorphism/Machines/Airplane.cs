namespace Machines
{
    public class Airplane : IMachine
    {
        public string Type { get; private set; }

        public Airplane()
        {
            Type = "Airplane";
        }

        public void Start()
            => Console.WriteLine("The airplane is starting..");

        public void Stop()
            => Console.WriteLine("The airplane has stooped!");
    }
}
