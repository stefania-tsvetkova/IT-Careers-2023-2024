namespace TransportPrice.Model
{
    public abstract class Vehicle
    {
        public double StartPrice { get; private set; }

        public double DayPricePerKm { get; private set; }

        public double NightPricePerKm { get; private set; }

        public int MinDistance { get; private set; }

        public Vehicle(double startPrice, double dayPricePerKm, double nightPricePerKm, int minDistance = 0)
        {
            StartPrice = startPrice;
            DayPricePerKm = dayPricePerKm;
            NightPricePerKm = nightPricePerKm;
            MinDistance = minDistance;
        }

        /// <summary>
        ///     Calculates the price of a ride with certain <paramref name="distance"/>. <br/><br/>
        ///     
        ///     <example>
        ///         An example usage:
        ///         <code>
        ///             CalculateRidePrice(50, false);
        ///         </code>
        ///     </example>
        /// </summary>
        /// <param name="distance">
        ///     The distance of the ride in <b>km</b>
        /// </param>
        /// <param name="isDay">
        ///     True if the ride is during the day, otherwise - false
        /// </param>
        /// <returns>
        ///     The price of ride in <b>lv</b>. <br/>
        ///      Throws an <see cref="ArgumentException"/> when the <paramref name="distance"/> 
        ///     is less that the minimum distance for a ride
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public double CalculateRidePrice(int distance, bool isDay)
        {
            if (distance < MinDistance)
            {
                throw new ArgumentException($"Distance should be at least {MinDistance}km!");
            }

            var pricePerKm = isDay ? DayPricePerKm : NightPricePerKm;
            var ridePrice = StartPrice + distance * pricePerKm;

            return ridePrice;
        }
    }
}
