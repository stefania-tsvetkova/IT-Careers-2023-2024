using System;
using System.Text;

public class ParkingInterval
{
    private string registrationPlate;
    private int hoursParked;

    public ParkingSpot ParkingSpot { get; set; }

    public string RegistrationPlate
    {
        get => registrationPlate;

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Registration plate can’t be null or empty!");
            }

            registrationPlate = value;
        }
    }

    public int HoursParked
    {
        get => hoursParked;

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Hours parked can’t be zero or negative!");
            }

            hoursParked = value;
        }
    }

    public double Revenue
    {
        get
        {
            if (ParkingSpot.Type == SubscriptionParkingSpot.Type)
            {
                return 0;
            }

            return ParkingSpot.Price * HoursParked;
        }
    }

    public ParkingInterval(ParkingSpot parkingSpot, string registrationPlate, int hoursParked)
    {
        ParkingSpot = parkingSpot;
        RegistrationPlate = registrationPlate;
        HoursParked = hoursParked;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"> Parking Spot #{ParkingSpot.Id}");
        stringBuilder.AppendLine($"> RegistrationPlate: {RegistrationPlate}");
        stringBuilder.AppendLine($"> HoursParked: {HoursParked}");
        stringBuilder.Append($"> Revenue: {Revenue:F2} BGN");

        return stringBuilder.ToString();
    }
}