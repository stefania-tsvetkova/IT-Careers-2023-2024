namespace Employees
{
    public abstract class BaseEmployee
    {
        protected string employeeId;

        protected string employeeName;

        protected string employeeAddress;

        public BaseEmployee(string employeeId, string employeeName, string employeeAddress)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.employeeAddress = employeeAddress;
        }

        public virtual void Show()
        {
            Console.WriteLine("-- Employee --");
            Console.WriteLine($"ID: {employeeId}");
            Console.WriteLine($"Name: {employeeName}");
            Console.WriteLine($"Address: {employeeAddress}");
        }

        public abstract double CalculateSalary(int workingHours);

        public abstract string GetDepartment();
    }
}