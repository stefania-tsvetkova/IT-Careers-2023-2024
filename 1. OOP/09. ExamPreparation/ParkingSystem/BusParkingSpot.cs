public class BusParkingSpot : ParkingSpot
{
    public static readonly string Type = "bus";

    public BusParkingSpot(int id, bool occupied, double price)
        : base(id, occupied, Type, price)
    { }
}
