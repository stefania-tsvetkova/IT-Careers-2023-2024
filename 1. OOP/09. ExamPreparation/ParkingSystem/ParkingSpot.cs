using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class ParkingSpot
{
    private double price;
    protected List<ParkingInterval> parkingIntervals;

    public int Id { get; set; }

    public bool Occupied { get; set; }

    public string Type { get; set; }

    public double Price
    {
        get => price;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Parking price cannot be less or equal to 0!");
            }

            price = value;
        }
    }

    public ParkingSpot(int id, bool occupied, string type, double price)
    {
        Id = id;
        Occupied = occupied;
        Type = type;
        Price = price;
        parkingIntervals = new List<ParkingInterval>();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"> Parking Spot #{Id}");
        stringBuilder.AppendLine($"> Occupied: {Occupied}");
        stringBuilder.AppendLine($"> Type: {Type}");
        stringBuilder.Append($"> Price per hour: {Price:F2} BGN");

        return stringBuilder.ToString();
    }

    public virtual bool ParkVehicle(string registrationPlate, int hoursParked, string type)
    {
        if (Occupied || type != Type)
        {
            return false;
        }

        var parkingInterval = new ParkingInterval(this, registrationPlate, hoursParked);
        parkingIntervals.Add(parkingInterval);

        Occupied = true;

        return true;
    }

    public List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate)
        => parkingIntervals
            .Where(parkingInterval => parkingInterval.RegistrationPlate == registrationPlate)
            .ToList();

    public virtual double CalculateTotal()
        => parkingIntervals.Sum(parkingInterval => parkingInterval.Revenue);
}
