namespace Employees
{
    public class FullTimeEmployee : BaseEmployee
    {
        private string employeePosition;

        private string employeeDepartment;

        public FullTimeEmployee(
            string employeeId,
            string employeeName,
            string employeeAddress,
            string employeePosition,
            string employeeDepartment)
            : base(employeeId, employeeName, employeeAddress)
        {
            this.employeePosition = employeePosition;
            this.employeeDepartment = employeeDepartment;
        }

        public override void Show()
        {
            base.Show();

            Console.WriteLine($"Position: {employeePosition}");
            Console.WriteLine($"Department: {employeeDepartment}");
        }

        public override double CalculateSalary(int workingHours)
            => 250 + workingHours * 10.8;
        // { return 250 + workingHours * 10.8; }

        public override string GetDepartment()
            => employeeDepartment;
    }
}
