using TransportPrice.Constants;

namespace TransportPrice.Model
{
    public class Bus : Vehicle
    {
        public Bus()
            : base(
                  BusConstants.StartPrice,
                  BusConstants.DayPricePerKm,
                  BusConstants.NightPricePerKm,
                  BusConstants.MinDistance)
        {
        }
    }
}
