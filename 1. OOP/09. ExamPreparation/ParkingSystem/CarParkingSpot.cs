public class CarParkingSpot : ParkingSpot
{
    public static readonly string Type = "car";

    public CarParkingSpot(int id, bool occupied, double price)
        : base(id, occupied, Type, price)
    { }
}
