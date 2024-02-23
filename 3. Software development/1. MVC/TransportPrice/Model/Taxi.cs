using TransportPrice.Constants;

namespace TransportPrice.Model
{
    public class Taxi : Vehicle
    {
        public Taxi()
            : base(
                  TaxiConstants.StartPrice,
                  TaxiConstants.DayPricePerKm,
                  TaxiConstants.NightPricePerKm)
        {
        }
    }
}
