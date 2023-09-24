using Machines;

var machineOperator = new MachineOperator();

Car car = new Car();

machineOperator.StartMachine(car);
machineOperator.StopMachine(car);

Airplane airplane = new Airplane();

machineOperator.StartMachine(airplane);
machineOperator.StopMachine(airplane);

Truck truck = new Truck();

machineOperator.StartMachine(truck);
machineOperator.StopMachine(truck);