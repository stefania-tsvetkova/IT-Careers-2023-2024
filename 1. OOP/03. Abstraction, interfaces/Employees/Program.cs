using Employees;


var fullTimeEmployee = new FullTimeEmployee(
    Guid.NewGuid().ToString(),
    "Pesho Ivanov",
    "Bulgaria, Sofia",
    "developer",
    "IT");

fullTimeEmployee.Show();

Console.WriteLine($"CalculateSalary for 10h: {fullTimeEmployee.CalculateSalary(10)}");
Console.WriteLine($"GetDepartment: {fullTimeEmployee.GetDepartment()}");

var contractEmployee = new ContractEmployee(
    Guid.NewGuid().ToString(),
    "Maria Ilianova",
    "Bulgaria, Varna",
    "penetration testing",
    "IT");

contractEmployee.Show();

Console.WriteLine($"CalculateSalary for 10h: {contractEmployee.CalculateSalary(10)}");
Console.WriteLine($"GetDepartment: {contractEmployee.GetDepartment()}");