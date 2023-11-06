using System;

internal class SubscriptionParkingSpot : ParkingSpot
{
    public static readonly string Type = "subscription";

    private string registrationPlate;

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

    public SubscriptionParkingSpot(int id, bool occupied, double price, string registrationPlate)
        : base(id, occupied, Type, price)
    {
        RegistrationPlate = registrationPlate;
    }

    public override bool ParkVehicle(string registrationPlate, int hoursParked, string type)
    {
        if (registrationPlate != RegistrationPlate)
        {
            return false;
        }

        return base.ParkVehicle(registrationPlate, hoursParked, type);
    }

    public override double CalculateTotal()
        => 0;
}

