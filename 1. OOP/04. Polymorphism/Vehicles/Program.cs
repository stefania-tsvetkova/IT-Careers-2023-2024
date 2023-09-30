using Vehicles;

var carInfo = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Skip(1)
    .Select(double.Parse)
    .ToArray();

var car = new Car(
    fuelQuantity: carInfo[0],
    litersPerKm: carInfo[1]);

var truckInfo = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Skip(1)
    .Select(double.Parse)
    .ToArray();

var truck = new Truck(
    fuelQuantity: truckInfo[0],
    litersPerKm: truckInfo[1]);

var commandsCount = int.Parse(Console.ReadLine());

for (int i = 0; i < commandsCount; i++)
{
    var command = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    var commandType = command[0];
    var vehicleType = command[1];
    var commandParameter = double.Parse(command[2]);

    Vehicle vehicle = vehicleType == "Car" ? car : truck;

    if (commandType == "Drive")
    {
        var isDriveSuccessful = vehicle.Drive(commandParameter);
        if (isDriveSuccessful)
        {
            Console.WriteLine($"{vehicleType} travelled {commandParameter} km");
        }
        else
        {
            Console.WriteLine($"{vehicleType} needs refueling");
        }
    }
    else
    {
        vehicle.Refuel(commandParameter);
    }
}

Console.WriteLine($"Car: {car.FuelQuantity:f2}");
Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");