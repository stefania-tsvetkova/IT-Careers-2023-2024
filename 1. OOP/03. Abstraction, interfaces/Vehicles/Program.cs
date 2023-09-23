using Vehicles;

var seat = new Seat("Leon", "Grey");
Console.WriteLine(seat.Model);
seat.Start();
seat.Stop();
Console.WriteLine(seat.ToString());

var tesla = new Tesla("Model 3", "Red", 2);
Console.WriteLine(tesla.Color);
Console.WriteLine(tesla.BatteryCount);
tesla.Start();
tesla.Stop();
Console.WriteLine(tesla.ToString());