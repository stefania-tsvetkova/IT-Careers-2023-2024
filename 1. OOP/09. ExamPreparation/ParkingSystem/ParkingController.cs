using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class ParkingController
{
    private List<ParkingSpot> parkingSpots;

    public ParkingController()
    {
        parkingSpots = new List<ParkingSpot>();
    }

    public string CreateParkingSpot(List<string> args)
    {
        var id = int.Parse(args[0]);

        var idUsed = parkingSpots.Any(entity => entity.Id == id);
        if (idUsed)
        {
            return $"Parking spot {id} is already registered!";
        }

        var occupied = bool.Parse(args[1]);
        string type = args[2];
        var price = double.Parse(args[3]);

        ParkingSpot parkingSpot;
        try
        {
            if (type == SubscriptionParkingSpot.Type)
            {
                string registrationPlate = args[4];

                parkingSpot = new SubscriptionParkingSpot(id, occupied, price, registrationPlate);
            }
            else if (type == CarParkingSpot.Type)
            {
                parkingSpot = new CarParkingSpot(id, occupied, price);
            }
            else if (type == BusParkingSpot.Type)
            {
                parkingSpot = new BusParkingSpot(id, occupied, price);
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }
        }
        catch (ArgumentException)
        {
            return "Unable to create parking spot!";
        }

        parkingSpots.Add(parkingSpot);

        return $"Parking spot {id} was successfully registered in the system!";
    }

    public string ParkVehicle(List<string> args)
    {
        var parkingSpotId = int.Parse(args[0]);

        var parkingSpot = GetParkingSpotById(parkingSpotId);
        if (parkingSpot == null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        string registrationPlate = args[1];
        var hoursParked = int.Parse(args[2]);
        string type = args[3];

        var isVehicleParked = parkingSpot.ParkVehicle(registrationPlate, hoursParked, type);
        if (isVehicleParked)
        {
            return $"Vehicle {registrationPlate} parked at {parkingSpotId} for {hoursParked} hours.";
        }

        return $"Vehicle {registrationPlate} can't park at {parkingSpotId}.";
    }

    public string FreeParkingSpot(List<string> args)
    {
        var parkingSpotId = int.Parse(args[0]);

        var parkingSpot = GetParkingSpotById(parkingSpotId);
        if (parkingSpot == null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        if (!parkingSpot.Occupied)
        {
            return $"Parking spot {parkingSpotId} is not occupied.";
        }

        parkingSpot.Occupied = false;

        return $"Parking spot {parkingSpotId} is now free!";
    }

    public string GetParkingSpotById(List<string> args)
    {
        var parkingSpotId = int.Parse(args[0]);

        var parkingSpot = GetParkingSpotById(parkingSpotId);
        if (parkingSpot == null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        return parkingSpot.ToString();
    }

    public string GetParkingIntervalsByParkingSpotIdAndRegistrationPlate(List<string> args)
    {
        var parkingSpotId = int.Parse(args[0]);

        var parkingSpot = GetParkingSpotById(parkingSpotId);
        if (parkingSpot == null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        string registrationPlate = args[1];

        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Parking intervals for parking spot {parkingSpotId}:");

        var parkingIntervals = parkingSpot.GetAllParkingIntervalsByRegistrationPlate(registrationPlate);
        foreach (var parkingInterval in parkingIntervals)
        {
            stringBuilder.AppendLine(parkingInterval.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string CalculateTotal(List<string> args)
    {
        var revenueSum = parkingSpots.Sum(parkingSpot => parkingSpot.CalculateTotal());

        return $"Total revenue from the parking: {revenueSum:F2} BGN";
    }

    private ParkingSpot GetParkingSpotById(int parkingSpotId)
        => parkingSpots.FirstOrDefault(entity => entity.Id == parkingSpotId);
}

