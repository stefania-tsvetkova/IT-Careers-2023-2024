namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm + Constants.TruckAirConditioningFuelUsage)
        { }

        public override void Refuel(double quantity)
            => base.Refuel(Constants.TruckRefuelPercentage * quantity);
    }
}
