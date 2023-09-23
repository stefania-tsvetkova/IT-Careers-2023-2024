namespace Vehicles
{
    public class Tesla : Car, IElectricCar
    {
        public int BatteryCount { get; private set; }

        public Tesla(string model, string color, int batteryCount)
        {
            Brand = "Tesla";
            Model = model;
            Color = color;
            BatteryCount = batteryCount;
        }

        public override string ToString()
        {
            return base.ToString() + $" with {BatteryCount} batteries";
        }
    }
}
