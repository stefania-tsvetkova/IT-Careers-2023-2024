using TransportPrice.Constants;

namespace TransportPrice.Model
{
    public class Train : Vehicle
    {
        public Train()
            : base(
                  TrainConstants.StartPrice,
                  TrainConstants.DayPricePerKm,
                  TrainConstants.NightPricePerKm,
                  TrainConstants.MinDistance)
        {
        }
    }
}
