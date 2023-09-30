namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double litersPerKm;

        public Vehicle(double fuelQuantity, double litersPerKm)
        {
            this.fuelQuantity = fuelQuantity;
            this.litersPerKm = litersPerKm;
        }

        public double FuelQuantity => fuelQuantity;

        public virtual void Refuel(double quantity)
            => fuelQuantity += quantity;

        public bool Drive(double distance)
        {
            var neededFuel = distance * litersPerKm;
            if (neededFuel > fuelQuantity)
            {
                return false;
            }

            fuelQuantity -= neededFuel;

            return true;
        }
    }
}
