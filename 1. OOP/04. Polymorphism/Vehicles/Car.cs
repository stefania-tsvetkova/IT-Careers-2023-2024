namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm + Constants.CarAirConditioningFuelUsage)
        { }
    }
}
