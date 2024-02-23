using TransportPrice.Model;

namespace TransportPrice
{
    public class VehicleController
    {
        private IEnumerable<Vehicle> vehicles;
        private Display display;

        public VehicleController()
        {
            display = new Display();

            vehicles = new List<Vehicle>()
            {
                new Bus(),
                new Taxi(),
                new Train()
            };
        }

        public void Start()
        {
            var (distance, isDay) = display.ReadUserInput();

            double minPrice = -1;
            foreach (var vehicle in vehicles)
            {
                try
                {
                    var price = vehicle.CalculateRidePrice(distance, isDay);
                    if (minPrice == -1 || price < minPrice)
                    {
                        minPrice = price;
                    }
                }
                catch (ArgumentException)
                {
                }
            }

            display.PrintRidePrice(minPrice);
        }
    }
}
